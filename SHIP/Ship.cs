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
        public Ship(string name, int life)
        {
            this.Name = name;
            this.Life = life;
        }
        //instances of ships and their corresponding lifes
        //Ship Ship1 = new Ship("Destroyer", 2);
        //Ship Ship2 = new Ship("Cruiser", 3);
        //Ship Ship3 = new Ship("Submarine", 3);
        //Ship Ship4 = new Ship("Battleship", 4);
        //Ship Ship5 = new Ship("Carrier", 5);

        public static void PlaceShipHorizontal(int coordX, int coordY, int life)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxY = coordY + life;
            bool allFree = true;
            if (maxY > 0 && maxY < 10)
            {
                for (int i = coordX; i < maxY; i++)
                {
                    if (square.IsItFree != true)
                    {
                        allFree = false;
                        break;
                    }
                }
                if (allFree == true)
                {
                    for (int j = coordX; j < maxY; j++)
                    {
                        Square.UpdateOccupationToShip(j, coordY);
                    }
                }
                //check if coordinates is valid
                else
                {
                    Console.Write("Cant place there is ship");
                }
            }
            else
            {
                Console.Write("Cant place, border");
            }
        }

        public static void PlaceShipVertical(int coordX, int coordY, int life)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxX = coordX + life;
            bool allFree = true;
            if (maxX > 0 && maxX < 10)
            {
                for (int i = coordX; i < maxX; i++)
                {
                    if (square.IsItFree == true)
                    {
                        allFree = false;
                        break;
                    }
                }
                if (allFree == true)
                {
                    for (int j = coordX; j < maxX; j++)
                    {
                        Square.UpdateOccupationToShip(coordX, j);
                    }
                }
                else
                {
                    Console.Write("Cant place there is ship");
                }
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