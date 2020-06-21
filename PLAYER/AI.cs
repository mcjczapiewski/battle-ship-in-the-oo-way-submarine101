using battle_ship_in_the_oo_way_submarine101.SHIP;
using System;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class AI
    {
        public static List<string> shipTypes = new List<string> { "D", "C", "S", "B", "R" };

        public static bool AiGenerateShipDirection()
        {
            Random random = new Random();
            var randomBool = random.Next(2) == 1;
            if (randomBool == true)
            {
                return true;
            }
            return false;
        }

        public static (int coordX, int coordY) AiGetCoords()
        {
            Random random = new Random();
            int coordX = random.Next(0, 10);
            int coordY = random.Next(0, 10);
            return (coordX, coordY);
        }

        public static Ship AiGetShipType(Dictionary<string, Ship> AiShips)
        {
            Random random = new Random();
            string randomShip;
            var randomIndex = random.Next(shipTypes.Count);
            randomShip = shipTypes[randomIndex];
            return Ship.CreateShip(randomShip);
        }
    }
}