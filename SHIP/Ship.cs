using System;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {

        public string Name;
        public int Life;
        public int CoordX;
        public int CoordY;

        public bool IsSunk
        {
            get
            {
                return Life == 0;
            }
        }

        public Ship(ShipEnum shipType, int life)

        {
            
            this.Life = life;
        }

        public void PlaceShipHorizontal(int coordX, int coordY, Ship newShip)
        {
            var maxY = coordY + newShip.Life;

            for (var i = coordY; i < maxY; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(coordX, i);
        }

        public static void PlaceShipVertical(int coordX, int coordY, Ship newShip)
        {
            var maxX = coordX + newShip.Life;

            for (var i = coordX; i < maxX; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(i, coordY);
        }

        public static void PlaceShipHorizontal(int coordX, int coordY, int life)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxY = coordY + life;
            if (square.IsItFree == true)
            {
                for (int i = coordY; i < maxY; i++)

                    //check if coordinates is valid

                    Square.UpdateOccupationToShip(coordX, i);
            }
            else
            {
                Console.Write("Cant place there is ship");
            }
        }
        public static void PlaceShipVertical(int coordX, int coordY, int life)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxX = coordX + life;
            if (square.IsItFree == true)
            {
                for (int i = coordX; i < maxX; i++)
                    //check if coordinates is valid
                    Square.UpdateOccupationToShip(i, coordY);
            }
            else
            {
                Console.Write("Cant place there is ship");
            }
        }
        public static void PlaceShip(int coordX, int coordY, int life, bool Horizontal)
        {
            if (Horizontal == true)

            {
                PlaceShipHorizontal(coordX, coordY, life);
            }
            else
            {
                PlaceShipVertical(coordX, coordY, life);
            }
        }

    }
}