
using System;
using System.Collections.Generic;
using System.Linq;


namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {

        public static bool KeepGoing = false;
        //public int CoordX = Square.CoordX;
        public string Name;
        public Dictionary<int, int> Ships;


        public Player(string name)
        {
            Name = name;
            Dictionary<int, int> ships = new Dictionary<int, int>
            {
                // lengthOfShip, availableShipsOfThatLength
                { 2, 1 },
                { 3, 2 },
                { 4, 1 },
                { 5, 1 }
            };
            Ships = ships;
        }

        public static string GetTheInput(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }

        public static Player CreateNewPlayer()
        {
            string userInput = GetTheInput("Type in your name:");
            return new Player(userInput);
        }

        public static void PlayerMove(Player player)
        {
            var coordinates = GetTheCoords();
            int shipLength = ShipLength(player.Ships);
            bool direction = ShipDirection();
            SHIP.Ship.PlaceShip(coordinates.coordX,
                                coordinates.coordY,
                                shipLength,
                                direction);
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
                if (userInput.Length > 3)
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

        private static int ShipLength(Dictionary<int, int> availableShips)
        {
            Dictionary<int, int> remainingShips = availableShips;
            int shipLength = 0;
            bool validInput = false;
            var lengthRange = Enumerable.Range(2, 4);

            while (!validInput)
            {
                string userInput = GetTheInput("Set ship length:");
                if (userInput.Length > 1)
                {
                    continue;
                }
                validInput = int.TryParse(userInput, out shipLength);
                if (!lengthRange.Contains(shipLength) || remainingShips[shipLength] == 0)
                {
                    validInput = false;
                    Console.WriteLine("The ship has unavailable length.");
                    continue;
                }
                else if (remainingShips[shipLength] > 0)
                {
                    remainingShips[shipLength]--;
                    return shipLength;
                }
            }
            return 0;
        }
    }
}