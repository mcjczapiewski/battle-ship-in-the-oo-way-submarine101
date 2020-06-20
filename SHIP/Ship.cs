using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public int CoordX;
        public int CoordY;
        public int Life;
        public string Name;
        public bool Sunk;
        public string ShipSign;

        public Ship(string name,
                    int life,
                    string shipSign,
                    bool sunk = false)
        {
            Name = name;
            Life = life;
            ShipSign = shipSign;
            Sunk = sunk;
        }

        public bool IsSunk
        {
            get
            {
                return Life == 0;
            }
        }

        public static Ship CreateShip(string shipNumber)
        {
            return shipNumber switch
            {
                "D" => new Ship("Destroyer", 2, "D ", false),
                "C" => new Ship("Cruiser", 3, "C ", false),
                "S" => new Ship("Submarine", 3, "S ", false),
                "B" => new Ship("Battleship", 4, "B ", false),
                "R" => new Ship("Carrier", 5, "R ", false),
                _ => throw new Exception("Wrong ship type. Select one from list."),
            };
        }

        public static bool PlaceShip(int coordX,
                                     int coordY,
                                     string shipType,
                                     bool Horizontal,
                                     Square[,] playerArray,
                                     Ship newShip)
        {
            if (Horizontal == true)
            {
                return PlaceShipHorizontal(coordX,
                                           coordY,
                                           playerArray,
                                           newShip);
            }
            else
            {
                return PlaceShipVertical(coordX,
                                         coordY,
                                         playerArray,
                                         newShip);
            }
        }

        public static bool PlaceShipHorizontal(int coordX,
                                               int coordY,
                                               Square[,] playerArray,
                                               Ship newShip)
        {
            Square[,] square = playerArray;

            int maxX = coordX + newShip.Life;
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
                        Square.UpdateOccupationToShip(j,
                                                      coordY,
                                                      playerArray,
                                                      newShip.ShipSign);
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
                                             Square[,] playerArray,
                                             Ship newShip)
        {
            Square[,] square = playerArray;
            int maxY = coordY + newShip.Life;
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
                        Square.UpdateOccupationToShip(coordX,
                                                      j,
                                                      playerArray,
                                                      newShip.ShipSign);
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
    }
}