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
        public bool PlaceShipsStage = true;
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

        public static (int coordX, int coordY) GetTheCoords(string message,
                                                            Ocean playerEmptyBoard)
        {
            int coordX = 0;
            int coordY = 0;
            bool validInput = false;
            string pattern = @"([a-zA-Z])([0-9].*)";
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            var coordsRange = Enumerable.Range(0, 10);

            while (!validInput)
            {
                string userInput = PrintMessageToGetInput(message
                    + "\nGive XY as letter + number:");
                if (!new[] { 2, 3 }.Contains(userInput.Length))
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
                    validInput = false;
                    Console.WriteLine("Already shooted...");
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

        public static string PrintMessageToGetInput(string message)
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
            if (PlaceShipsStage)
            {
                Place5Ships(playerBoard,
                            playerEmptyBoard,
                            ref coordX,
                            ref coordY);
                PlaceShipsStage = false;
            }
            else
            {
                ShootingMechanizm(playerBoard,
                                  playerEmptyBoard,
                                  enemyShipsBoard,
                                  enemyShips,
                                  ref coordX,
                                  ref coordY);
            }
        }

        private static bool GetShipDirection()
        {
            bool horizontal = false;
            bool validInput = false;
            string userInput = "";

            while (!validInput)
            {
                userInput = PrintMessageToGetInput("Do you want to place ship" +
                    " horizontal (h) or vertical (v)?").ToLower();
                if (userInput.Length > 1
                    || !(new[] { "v", "h" }.Contains(userInput)))
                {
                    continue;
                }
                validInput = true;
            }
            if (userInput == "h")
            {
                horizontal = true;
                return horizontal;
            }
            return horizontal;
        }

        private void ChooseShipTypeAndPlacement(Ocean playerEmptyBoard,
                                                out int coordX,
                                                out int coordY,
                                                out Ship newShip,
                                                out bool horizontal)
        {
            if (Name == "AI")
            {
                (coordX, coordY) = AI.AiGetCoords(playerEmptyBoard);
                newShip = AI.AiGetShipType();
                horizontal = AI.AiGenerateShipDirection();
            }
            else
            {
                (coordX, coordY) = GetTheCoords("Place your ships!", playerEmptyBoard);
                newShip = GetShipType();
                horizontal = GetShipDirection();
            }
        }

        private Ship GetShipType()
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
                string shipType = PrintMessageToGetInput("Choose ship type:").ToUpper();
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

        private void Place5Ships(Ocean playerBoard,
                                 Ocean playerEmptyBoard,
                                 ref int coordX,
                                 ref int coordY)
        {
            for (int i = 0; i < 5; i++)
            {
                bool shipPlaced;
                do
                {
                    ChooseShipTypeAndPlacement(playerEmptyBoard,
                                               out coordX,
                                               out coordY,
                                               out Ship newShip,
                                               out bool horizontal);
                    shipPlaced = Ship.PlaceShip(coordX,
                                                coordY,
                                                horizontal,
                                                playerBoard.ArrayOfSquares,
                                                newShip);
                    if (shipPlaced)
                    {
                        UpdatePlayerShipList(newShip);
                    }
                } while (!shipPlaced);
                Console.Clear();
                UTILS.AsciiArt.Battleship();
                Console.WriteLine($"This is {Name} turn.");
                if (Name != "AI")
                {
                    Ocean.PrintBoard(playerBoard, playerEmptyBoard);
                }
            }
        }

        private void ShootingMechanizm(Ocean playerBoard,
                                       Ocean playerEmptyBoard,
                                       Ocean enemyShipsBoard,
                                       Dictionary<string, Ship> enemyShips,
                                       ref int coordX,
                                       ref int coordY)
        {
            bool wasItHit = false;
            bool isItSunk = false;
            bool firstLoop = true;
            do
            {
                if (Name == "AI")
                {
                    if (!AI.WasItHit || isItSunk)
                    {
                        AI.WasItHit = false;
                        firstLoop = true;
                        (coordX, coordY) = AI.AiGetCoords(playerEmptyBoard);
                        (AI.CoordXFirstHit, AI.CoordYFirstHit) = (coordX, coordY);
                    }
                    else if ((wasItHit || AI.WasItHit) && !isItSunk)
                    {
                        if (AI.WasItHit)
                        {
                            firstLoop = false;
                        }
                        (coordX, coordY) = AI.AiGetCoordsToKill(playerEmptyBoard,
                                                                isItSunk);
                    }
                }
                else
                {
                    (coordX, coordY) = GetTheCoords("FIRE!", playerEmptyBoard);
                }
                (wasItHit, isItSunk) = Square.Shoot(coordX,
                                                    coordY,
                                                    playerEmptyBoard.ArrayOfSquares,
                                                    enemyShipsBoard.ArrayOfSquares,
                                                    enemyShips);

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
                else if (AI.WasItHit && wasItHit && !isItSunk && this.Name == "AI")
                {
                    if (AI.CoordXFirstHit < coordX && AI.CoordYFirstHit == coordY)
                    {
                        AI.AiSinkShipHits.Clear();
                        AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX + 1, coordY),
                                        (AI.CoordXFirstHit - 1, coordY)
                                    };
                    }
                    else if (AI.CoordXFirstHit > coordX && AI.CoordYFirstHit == coordY)
                    {
                        AI.AiSinkShipHits.Clear();
                        AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX - 1, coordY),
                                        (AI.CoordXFirstHit + 1, coordY)
                                    };
                    }
                    else if (AI.CoordYFirstHit < coordY && AI.CoordXFirstHit == coordX)
                    {
                        AI.AiSinkShipHits.Clear();
                        AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX, coordY + 1),
                                        (coordX, AI.CoordYFirstHit - 1)
                                    };
                    }
                    else
                    {
                        AI.AiSinkShipHits.Clear();
                        AI.AiSinkShipHits = new List<(int, int)>
                                    {
                                        (coordX, coordY - 1),
                                        (coordX, AI.CoordYFirstHit + 1)
                                    };
                    }
                }
                if (!wasItHit && AI.WasItHit && AI.AiSinkShipHits.Count == 0)
                {
                    AI.CoordXStored = coordX;
                    AI.CoordYStored = coordY;
                }
                

                Console.Clear();
                UTILS.AsciiArt.Battleship();
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

        private void UpdatePlayerShipList(Ship newShip)
        {
            PlayerShips.Add(newShip.ShipSign, newShip);
            if (Name == "AI")
            {
                AI.ShipTypes.Remove(newShip.ShipSign.Trim());
            }
        }
    }
}