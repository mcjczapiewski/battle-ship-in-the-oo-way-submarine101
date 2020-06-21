using battle_ship_in_the_oo_way_submarine101.SHIP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class AI
    {
        public static List<string> ShipTypes
            = new List<string> { "D", "C", "S", "B", "R" };
        public static List<(int, int)> AiSinkShipHits;
        public static int CoordX;
        public static int CoordY;
        public static bool WasItHit = false;

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

        public static (int coordX, int coordY) AiGetCoordsToKill()
        {
            Random random = new Random();
            int coordX;
            int coordY;
            do
            {
                int index = random.Next(AiSinkShipHits.Count);
                (coordX, coordY) = AiSinkShipHits[index];
                AiSinkShipHits.RemoveAt(index);
            } while (!Enumerable.Range(0, 10).Contains(coordX)
                     && !Enumerable.Range(0, 10).Contains(coordY));
            return (coordX, coordY);
        }

        public static Ship AiGetShipType()
        {
            Random random = new Random();
            string randomShip;
            var randomIndex = random.Next(ShipTypes.Count);
            randomShip = ShipTypes[randomIndex];
            return Ship.CreateShip(randomShip);
        }
    }
}