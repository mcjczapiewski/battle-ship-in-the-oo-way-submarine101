using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class AI
    {
        public static string AiGenerateShipDirection()
        {
            Random random = new Random();
            var randomBool = random.Next(2) == 1;
            if (randomBool == true)
            {
                return "h";
            }
            else
            {
                return "v";
            }
        }
        public static int AiGenerateShipLenght()
        {
            Random random = new Random();
            int randomInt = random.Next(0, 6);
            return randomInt;
        }
        public static (int coordX, int coordY) AiGetCoords()
        {
            Random random = new Random();
            int coordX = random.Next(0, 10);
            int coordY = random.Next(0, 10);
            return (coordX, coordY);
        }
    }
}
