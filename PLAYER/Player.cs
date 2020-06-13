using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SHIP;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        public string Player1;
        public string Player2;
        //public int RandomStart;

        public static string[] GetNameFromPlayer()
        {
            Console.Write("Player 1 name: ");
            Player1 = Console.ReadLine();
            Console.WriteLine("Ok " + Player1 + ", get ready for game!");
            Console.Write("Plater 2 name: ");
            Player2 = Console.ReadLine();
            Console.WriteLine("Ok " + Player2 + ", get ready for game!");
            return new string[] { Player1, Player2 };
        }

        //public int WhoStartFirst()
        //{
        //    RandomStart = new Random().Next(0, 2);
        //    string[] firstPlayer = GetNameFromPlayer();
        //    return firstPlayer[RandomStart];
        //}

        //public string Name { get; set; }
        //public Ocean Ocean { get; set; }
        //// public EnemyBoard EnemyBoard { get; set; }
        //public List<Ship> Ships { get; set; }
        //public bool HasLost
        //{
        //    get
        //    {
        //        return Ships.All(x => x.IsSink);
        //    }
        //}

        //public Player(string name)
        //{
        //    Name = name;
        //    Ships = new List<Ship>()
        //    {
        //        new Ship("Destroyer", 2,0,'D', false),
        //        new Ship("Carrier", 5,0,'R',false),
        //        new Ship("Cruiser", 3,0,'C',false),
        //        new Ship("Submarine", 3,0,'S',false),
        //        new Ship("Battleship", 4,0,'B',false),
        //    };
        //    Ocean = new Ocean();
        //    Ocean EnemyBoard = new Ocean();
        //}

        public static ShipPlacement PlayerPlaceShip(string Ships)
        {
            ShipPlacement result = null;
            do
            {
                Console.Write("Where to place " + Ships + ": ");
                result = GetPosition(Console.ReadLine());
                if (result is null) ;
                else return result;
                Console.WriteLine("Wrong input. Please choose position and direction.");
            } while (result is null);
            return result;
        }

        public static ShipPlacement GetPosition(string position)
        {
            string strX, strY, strDirection;
            int x, y;

            if (position.Split(",").Length == 2)
            {
                if (position.Split(",")[0].Trim().Length > 1)
                {
                    strX = position.Split(",")[0].Trim().Substring(0, 1);
                    strY = position.Split(",")[0].Trim().Substring(1);
                    strDirection = position.Split(",")[1].ToLower().Trim();

                    x = LetterToNumber(strX);
                    if (x > 0
                        && x < 11
                        && int.TryParse(strY, out y)
                        && y > 0
                        && y < 11
                        && (strDirection == "u" || strDirection == "d" || strDirection == "l" || strDirection == "r"))
                    {
                        ShipPlacement ShipLocation = new ShipPlacement();
                        ShipLocation.Direction = GetDirection(strDirection);
                        ShipLocation.Coordinate = new Coordinates(x, y);
                        return ShipLocation;
                    }
                }
            }
            return null;
        }
        public static ShipDirection GetDirection(string direction)
        {
            switch (direction.ToLower())
            {
                case "u":
                    return ShipDirection.Up;
                    break;
                default:
                    return ShipDirection.Down;
                    break;
                case "l":
                    return ShipDirection.Left;
                    break;
                case "r":
                    return ShipDirection.Right;
                    break;
            }
        }
        private static int LetterToNumber(string letter)
        { 
            int result = -1;
            switch (letter.ToLower())
            {
                case "a":
                    result = 1;
                    break;
                case "b":
                    result = 2;
                    break;
                case "c":
                    result = 3;
                    break;
                case "d":
                    result = 4;
                    break;
                case "e":
                    result = 5;
                    break;
                case "f":
                    result = 6;
                    break;
                case "g":
                    result = 7;
                    break;
                case "h":
                    result = 8;
                    break;
                case "i":
                    result = 9;
                    break;
                case "j":
                    result = 10;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}