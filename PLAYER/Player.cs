using System;
using System.Collections.Generic;
using System.Linq;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using battle_ship_in_the_oo_way_submarine101.OCEAN;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        public string Name;
        public Dictionary<int, int> Ships;

        public Player(string name)
        {
            Name = name;
            Dictionary<int, int> ships = new Dictionary<int, int>
            {
                // { lengthOfShip, availableShipsOfThatLength }
                { 2, 1 },
                { 3, 2 },
                { 4, 1 },
                { 5, 1 }
            };
            Ships = ships;
        }

        public static (Player, Ocean, Ocean) CreateNewPlayer()
        {
            Square[,] ArrayOfSquares = new Square[10, 10];
            Square[,] EmptyArrayOfSquares = new Square[10, 10];
            string userInput = GetTheInput("Type in your name:");
            Ocean playerBoard = new Ocean($"{userInput} Board",
                                          ArrayOfSquares);
            Ocean emptyPlayerBoard = new Ocean($"Empty {userInput} Board",
                                               EmptyArrayOfSquares);
            return (new Player(userInput), playerBoard, emptyPlayerBoard);
        }

        public static string GetTheInput(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }

        public void Move(Ocean playerBoard,
                         Ocean enemyEmptyBoard,
                         Ocean enemyShipsBoard)
        {
            if (this.Ships.Count != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool placed;
                    do
                    {
                        var (coordX, coordY) = GetTheCoords();
                        int shipLength = ShipLength();
                        bool direction = ShipDirection();
                        placed = SHIP.Ship.PlaceShip(coordX,
                                                     coordY,
                                                     shipLength,
                                                     direction,
                                                     playerBoard.ArrayOfSquares);
                        if (placed)
                        {
                            this.Ships[shipLength]--;
                            if (this.Ships[shipLength] == 0)
                            {
                                this.Ships.Remove(shipLength);
                            }
                        }
                    } while (placed is false);
                    Console.Clear();
                    MainLogic.AsciiArt();
                    Console.WriteLine($"This is {this.Name} turn.");
                    Ocean.PrintBoard(playerBoard, enemyEmptyBoard);
                }
            }
            else
            {
                bool wasItHit;
                do
                {
                    var (coordX, coordY) = GetTheCoords();
                    wasItHit = Square.Shoot(coordX,
                                            coordY,
                                            enemyEmptyBoard.ArrayOfSquares,
                                            enemyShipsBoard.ArrayOfSquares);
                    Console.Clear();
                    MainLogic.AsciiArt();
                    Ocean.PrintBoard(playerBoard, enemyEmptyBoard);
                } while (wasItHit is true);
            }
        }

        private static (int coordX, int coordY) GetTheCoords()
        {
            int coordX = 0;
            int coordY = 0;
            bool validInput = false;
            string pattern = @"([a-zA-Z])([0-9].*)";
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            var coordsRange = Enumerable.Range(0, 10);

            while (!validInput)
            {
                string userInput = GetTheInput("Give XY as letter + number:");
                if (userInput.Length > 3 || userInput.Length < 2)
                {
                    continue;
                }
                string userInputX = regex.Split(userInput)[1];
                string userInputY = regex.Split(userInput)[2];
                coordX = UTILS.Utils.LetterToNumber(userInputX);
                validInput = int.TryParse(userInputY, out coordY);
                coordY--;
                if (coordX == 10 || !coordsRange.Contains(coordY))
                {
                    validInput = false;
                    continue;
                }
            }
            return (coordX, coordY);
        }

        private static bool ShipDirection()
        {
            bool direction = false;
            bool validInput = false;
            string userInput = "";

            while (!validInput)
            {
                userInput = GetTheInput("Do you want to place ship horizontal (h) " +
                    "or vertical (v)?").ToLower();
                if (userInput.Length > 1
                    || (userInput != "h" && userInput != "v"))
                {
                    continue;
                }
                validInput = true;
            }
            if (userInput == "h")
            {
                direction = true;
                return direction;
            }
            return direction;
        }

        private int ShipLength()
        {
            bool validInput = false;
            var lengthRange = Enumerable.Range(2, 4);

            while (!validInput)
            {
                string userInput = GetTheInput("Set ship length:");
                if (userInput.Length > 1)
                {
                    continue;
                }
                _ = int.TryParse(userInput, out int shipLength);
                if (!this.Ships.ContainsKey(shipLength)
                    || !lengthRange.Contains(shipLength)
                    || this.Ships[shipLength] == 0)
                {
                    validInput = false;
                    Console.WriteLine("The ship has unavailable length.");
                    continue;
                }
                return shipLength;
            }
            return 0;
        }
    }
}