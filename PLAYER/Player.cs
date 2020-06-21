using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

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

        public static (Player, Ocean, Ocean) CreateNewPlayer(string playerName)
        {
            {
                if (playerName == "")
                {
                    playerName = "AI";
                }
                Square[,] ArrayOfSquares = new Square[10, 10];
                Square[,] EmptyArrayOfSquares = new Square[10, 10];
                Ocean playerBoard = new Ocean($"{playerName} Board",
                    ArrayOfSquares);
                Ocean emptyPlayerBoard = new Ocean($"Empty {playerName} Board",
                    EmptyArrayOfSquares);
                return (new Player(playerName), playerBoard, emptyPlayerBoard);
            }
        }

        public static (int coordX, int coordY) GetTheCoords(string message, Ocean playerEmptyBoard)
        {
            int coordX = 0;
            int coordY = 0;
            bool validInput = false;
            string pattern = @"([a-zA-Z])([0-9].*)";
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            var coordsRange = Enumerable.Range(0, 10);

            while (!validInput)
            {
                string userInput = GetTheInput(message
                    + "\nGive XY as letter + number:");
                if (!(new[] { 2, 3 }.Contains(userInput.Length)))
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
                if (playerEmptyBoard.ArrayOfSquares[coordX, coordY].AlreadyShooted)
                {
                    continue;
                }
                else if (coordX == 10 || !coordsRange.Contains(coordY))
                {
                    validInput = false;
                    continue;
                }
            }
            return (coordX, coordY);
        }

        public static string GetTheInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.Write("> ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public void Move(Ocean playerBoard,
                         Ocean playerEmptyBoard,
                         Ocean enemyShipsBoard,
                         Dictionary<string, Ship> enemyShips)
        {
            int coordX = 0;
            int coordY = 0;
            if (this.PlayerShips.Count != 5 && AI.ShipTypes.Count != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool placed;
                    do
                    {
                        Ship newShip;
                        bool direction;
                        if (this.Name != "AI")
                        {
                            (coordX, coordY) = GetTheCoords("Place your ships!", playerEmptyBoard);
                            newShip = ShipType();
                            direction = ShipDirection();
                        }
                        else
                        {
                            (coordX, coordY) = AI.AiGetCoords();
                            newShip = AI.AiGetShipType();
                            direction = AI.AiGenerateShipDirection();
                        }
                        placed = SHIP.Ship.PlaceShip(coordX,
                                                     coordY,
                                                     direction,
                                                     playerBoard.ArrayOfSquares,
                                                     newShip);
                        if (placed)
                        {
                            this.PlayerShips.Add(newShip.ShipSign, newShip);
                            if (this.Name == "AI")
                            {
                                AI.ShipTypes.Remove(newShip.ShipSign.Trim());
                            }
                        }
                    } while (placed is false);
                    Console.Clear();
                    MainLogic.AsciiArt();
                    Console.WriteLine($"This is {this.Name} turn.");
                    if (this.Name != "AI")
                    {
                        Ocean.PrintBoard(playerBoard, playerEmptyBoard);
                    }
                }
            }
            else
            {
                bool wasItHit = false;
                bool isItSunk = false;
                bool firstLoop = true;
                do
                {
                    if (this.Name != "AI")
                    {
                        (coordX, coordY) = GetTheCoords("FIRE!");
                    }
                    else
                    {
                        if (!AI.WasItHit || isItSunk)
                        {
                            AI.WasItHit = false;
                            (coordX, coordY) = AI.AiGetCoords();
                            (AI.CoordX, AI.CoordY) = (coordX, coordY);
                        }
                        else if ((wasItHit || AI.WasItHit) && !isItSunk)
                        {
                            if (!AI.WasItHit)
                            {
                                firstLoop = false;
                            }
                            (coordX, coordY) = AI.AiGetCoordsToKill();
                        }
                    }
                    (wasItHit, isItSunk) = Square.Shoot(coordX,
                                                        coordY,
                                                        playerEmptyBoard.ArrayOfSquares,
                                                        enemyShipsBoard.ArrayOfSquares,
                                                        enemyShips);
                    if (AI.WasItHit && wasItHit && !isItSunk && this.Name == "AI")
                    {
                        if (AI.CoordX < coordX)
                        {
                            AI.AiSinkShipHits.Clear();
                            AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX + 1, coordY),
                                    };
                        }
                        else if (AI.CoordX > coordX)
                        {
                            AI.AiSinkShipHits.Clear();
                            AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX - 1, coordY),
                                    };
                        }
                        else if (AI.CoordY < coordY)
                        {
                            AI.AiSinkShipHits.Clear();
                            AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX, coordY + 1),
                                    };
                        }
                        else
                        {
                            AI.AiSinkShipHits.Clear();
                            AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX, coordY - 1),
                                    };
                        }
                    }
                    if (firstLoop && wasItHit && this.Name == "AI")
                    {
                        AI.WasItHit = true;
                        AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX, coordY - 1),
                                        (coordX - 1, coordY),
                                        (coordX + 1, coordY),
                                        (coordX, coordY + 1)
                                    };
                    }
                    Console.Clear();
                    MainLogic.AsciiArt();
                    if (this.Name != "AI")
                    {
                        Ocean.PrintBoard(playerBoard, playerEmptyBoard);
                        if (isItSunk)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("THIS ONE IS DOWN!");
                            Console.ResetColor();
                        }
                    }
                } while (wasItHit && enemyShips.Count != 0);
            }
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

        private Ship ShipType()
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
                string shipType = GetTheInput("Choose ship type:").ToUpper();
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
                return Ship.CreateShip(shipType);
            }
            throw new Exception("Something went bad...");
        }
    }
}