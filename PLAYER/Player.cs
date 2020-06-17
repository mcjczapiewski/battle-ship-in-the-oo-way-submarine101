using System;
using System.Linq;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        public static bool KeepGoing = false;
        //public int CoordX = Square.CoordX;

        //public Player(bool keepGoing, int coordX)
        //{
        //    KeepGoing = keepGoing;
        //    CoordX = coordX;
        //}

        public static void GetTheCoords()
        {
            int coordX;
            bool validInput = false;
            string pattern = @"([a-zA-Z])([0-9].*)";
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            var coordsRange = Enumerable.Range(0, 10);

            while (!validInput)
            {
                Console.WriteLine("Give XY");
                string userInput = Console.ReadLine();
                if (userInput.Length > 3)
                {
                    continue;
                }
                string userInputX = regex.Split(userInput)[1];
                string userInputY = regex.Split(userInput)[2];
                coordX = UTILS.Utils.LetterToNumber(userInputX);
                validInput = int.TryParse(userInputY, out int coordY);
                coordY--;
                if (coordX == 10 || !coordsRange.Contains(coordY))
                {
                    validInput = false;
                    continue;
                }

                Console.WriteLine(coordX);
                Console.WriteLine(coordY);

                Console.ReadKey();
            }
        }
    }
}