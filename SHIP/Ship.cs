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

        public static bool PlaceShipHorizontal(int coordX,
                                               int coordY,
                                               int life,
                                               Square[,] playerArray)
        {
            Square[,] square = playerArray;
            int maxX = coordX + life;
            bool allFree = true;
            if (maxX > 1 && maxX <= 10)
            {
                for (int i = coordX; i < maxX; i++)
                {
                    if (square[i, coordY].IsItFree != true)
                    {
                        allFree = false;
                        break;
                    }
                }
                if (allFree == true)
                {
                    for (int j = coordX; j < maxX; j++)
                    {
                        Square.UpdateOccupationToShip(j, coordY, playerArray);
                    }
                    return true;
                }
                //check if coordinates is valid
                else
                {
                    Console.WriteLine("Cant place there is ship");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Cant place, border");
                return false;
            }
        }

        public static bool PlaceShipVertical(int coordX,
                                             int coordY,
                                             int life,
                                             Square[,] playerArray)
        {
            Square[,] square = playerArray;
            int maxY = coordY + life;
            bool allFree = true;
            if (maxY > 1 && maxY <= 10)
            {
                for (int i = coordY; i < maxY; i++)
                {
                    if (square[coordX, i].IsItFree != true)
                    {
                        allFree = false;
                        break;
                    }
                }
                if (allFree == true)
                {
                    for (int j = coordY; j < maxY; j++)
                    {
                        Square.UpdateOccupationToShip(coordX, j, playerArray);
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Cant place there is ship");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Cant place, border");
                return false;
            }
        }

        public static bool PlaceShip(int coordX,
                                     int coordY,
                                     int life,
                                     bool Horizontal,
                                     Square[,] playerArray)
        {
            if (Horizontal == true)
            {
                return PlaceShipHorizontal(coordX, coordY, life, playerArray);
            }
            else
            {
                return PlaceShipVertical(coordX, coordY, life, playerArray);
            }
        }

    }
}