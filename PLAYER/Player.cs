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
        public Dictionary<string, Ship> PlayerShips;

        public Player(string name)
        {
            Name = name;
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
            if (this.PlayerShips.Count != 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool placed;
                    do
                    {
                        var (coordX, coordY) = GetTheCoords();
                        (string shipType, Ship newShip) = ShipNumber();
                        this.PlayerShips.Add(newShip.ShipSign, newShip);
                        bool direction = ShipDirection();
                        placed = SHIP.Ship.PlaceShip(coordX,
                                                     coordY,
                                                     shipType,
                                                     direction,
                                                     playerBoard.ArrayOfSquares,
                                                     newShip);
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("THIS ONE IS DOWN!");
                        Console.ResetColor();
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
                string userInputX;
                string userInputY;
                try
                {
                    userInputX = regex.Split(userInput)[1];
                    userInputY = regex.Split(userInput)[2];
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
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

        private (string, Ship) ShipNumber()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("\nShips list (only one per each available):\n" +
                    "(D)  Destroyer - 2 squares\n" +
                    "(C)  Cruiser - 3 squares\n" +
                    "(S)  Submarine - 3 squares\n" +
                    "(B)  Battleship - 4 squares\n" +
                    "(R)  Carrier - 5 squares\n");
                string shipType = GetTheInput("Choose ship number:").ToUpper();
                if (shipType.Length > 1)
                {
                    continue;
                }
                if (this.PlayerShips.ContainsKey(shipType)
                    || !(new[] { "D", "C", "S", "B", "R" }.Contains(shipType)))
                {
                    validInput = false;
                    Console.WriteLine("Unavailable choice.");
                    continue;
                }
                return (shipType, Ship.CreateShip(shipType));
            }
            throw new Exception("Something went bad...");
        }
    }
}