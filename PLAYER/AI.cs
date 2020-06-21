using System;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class AI
    {
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

        //public static int AiGenerateShipLenght()
        //{
        //    Random random = new Random();
        //    int randomInt = random.Next(0, 6);
        //    return randomInt;
        //}

        public static (int coordX, int coordY) AiGetCoords()
        {
            Random random = new Random();
            int coordX = random.Next(0, 10);
            int coordY = random.Next(0, 10);
            return (coordX, coordY);
        }

        public static void PlaceAIShips(int coordX, int coordY)
        {
            Random random = new Random();
            coordX = random.Next(0, 10);
            coordY = random.Next(0, 10);
            
            Ship.PlaceShip(coordX, coordY, false, new Square[,] {}, Ship.CreateShip("D"));
            Ship.PlaceShip(coordX, coordY, false, new Square[,] {}, Ship.CreateShip("C"));
            Ship.PlaceShip(coordX, coordY, false, new Square[,] {}, Ship.CreateShip("S"));
            Ship.PlaceShip(coordX, coordY, false, new Square[,] {}, Ship.CreateShip("B"));
            Ship.PlaceShip(coordX, coordY, false, new Square[,] {}, Ship.CreateShip("R"));
            
        }
        
        
    }
}