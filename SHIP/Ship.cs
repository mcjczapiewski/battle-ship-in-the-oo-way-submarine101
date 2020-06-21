using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Collections.Generic;

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

        public Ship()
        { }
        
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
                                     bool Horizontal,
                                     Square[,] playerArray,
                                     Ship newShip)
        {
            if (Horizontal == true)
            {
                return PlaceShipOnBoard(coordX,
                                           coordY,
                                           playerArray,
                                           newShip,
                                           coordX,
                                           Horizontal);
            }
            else
            {
                return PlaceShipOnBoard(coordX,
                                           coordY,
                                           playerArray,
                                           newShip,
                                           coordY,
                                           Horizontal);
            }
        }

        public static bool PlaceShipOnBoard(int coordX,
                                             int coordY,
                                             Square[,] playerArray,
                                             Ship newShip,
                                             int mainCoord,
                                             bool horizontal)
        {
            Square[,] square = playerArray;
            int maxValue = mainCoord + newShip.Life;
            bool reverseMainCoord = false;
            if (maxValue > 1 && maxValue <= 9)
            {
                if (mainCoord == 0)
                {
                    mainCoord++;
                    reverseMainCoord = true;
                }
                bool allFree = AreAllSquaresFree(coordX,
                                                 coordY,
                                                 mainCoord,
                                                 horizontal,
                                                 square,
                                                 maxValue);
                if (allFree == true)
                {
                    if (reverseMainCoord)
                    {
                        mainCoord--;
                    }
                    for (int i = mainCoord; i < maxValue; i++)
                    {
                        if (horizontal)
                        {
                            Square.UpdateOccupationToShip(i,
                                                          coordY,
                                                          playerArray,
                                                          newShip.ShipSign);
                        }
                        else
                        {
                            Square.UpdateOccupationToShip(coordX,
                                                          i,
                                                          playerArray,
                                                          newShip.ShipSign);
                        }
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

        private static bool AreAllSquaresFree(int coordX, int coordY, int mainCoord, bool horizontal, Square[,] square, int maxValue)
        {
            for (int i = mainCoord - 1; i > -1 && i < maxValue + 1 && i < 10; i++)
            {
                if (horizontal)
                {
                    for (int j = coordY - 1; j > -1 && j < coordY + 2 && j < 10; j++)
                    {
                        if (square[i, j].IsItFree != true)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int j = coordX - 1; j > -1 && j < coordX + 2 && j < 10; j++)
                    {
                        if (square[j, i].IsItFree != true)
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}