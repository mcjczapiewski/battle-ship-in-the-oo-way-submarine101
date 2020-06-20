using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        public string Name;
        public List<int> AvailableShipsNumbers;
        public Dictionary<string, Ship> PlayerShips;

        public Player(string name)
        {
            Name = name;
            List<int> availableShipsNumbers = new List<int> { 1, 2, 3, 4, 5 };
            //Dictionary<int, int> ships = new Dictionary<int, int>
            //{
            //    // { lengthOfShip, availableShipsOfThatLength }
            //    { 2, 1 },
            //    { 3, 2 },
            //    { 4, 1 },
            //    { 5, 1 }
            //};
            AvailableShipsNumbers = availableShipsNumbers;
            Dictionary<string, Ship> playerShips = new Dictionary<string, Ship>();
            PlayerShips = playerShips;
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
                         Ocean enemyShipsBoard,
                         Dictionary<string, Ship> enemyShips)
        {
            if (this.AvailableShipsNumbers.Count != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool placed;
                    do
                    {
                        var (coordX, coordY) = GetTheCoords();
                        (int shipNumber, Ship newShip) = ShipNumber();
                        this.PlayerShips.Add(newShip.ShipSign, newShip);
                        bool direction = ShipDirection();
                        placed = SHIP.Ship.PlaceShip(coordX,
                                                     coordY,
                                                     shipNumber,
                                                     direction,
                                                     playerBoard.ArrayOfSquares,
                                                     newShip);
                        if (placed)
                        {
                            this.AvailableShipsNumbers.Remove(shipNumber);
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
                bool isItSunk;
                do
                {
                    var (coordX, coordY) = GetTheCoords();
                    (wasItHit, isItSunk) = Square.Shoot(coordX,
                                            coordY,
                                            enemyEmptyBoard.ArrayOfSquares,
                                            enemyShipsBoard.ArrayOfSquares,
                                            enemyShips);
                    Console.Clear();
                    MainLogic.AsciiArt();
                    Ocean.PrintBoard(playerBoard, enemyEmptyBoard);
                    if (isItSunk)
                    {
                        Console.WriteLine("THIS ONE IS DOWN!");
                    }
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

        private (int, Ship) ShipNumber()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("\nShips list (only one per each available):\n" +
                    "(1)  [D] Destroyer - 2 squares\n" +
                    "(2)  [C] Cruiser - 3 squares\n" +
                    "(3)  [S] Submarine - 3 squares\n" +
                    "(4)  [B] Battleship - 4 squares\n" +
                    "(5)  [R] Carrier - 5 squares\n");
                string userInput = GetTheInput("Choose ship number:");
                if (userInput.Length > 1)
                {
                    continue;
                }
                _ = int.TryParse(userInput, out int shipNumber);
                if (!this.AvailableShipsNumbers.Contains(shipNumber))
                {
                    validInput = false;
                    Console.WriteLine("The ship has unavailable number.");
                    continue;
                }
                return (shipNumber, Ship.CreateShip(shipNumber));
            }
            throw new Exception("Something went bad...");
        }
    }
}