using battle_ship_in_the_oo_way_submarine101.OCEAN;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square
    {
        public int CoordX;
        public int CoordY;
        public string Sign;
        public bool AlreadyShooted;
        public bool IsItFree;

        public Square(int coordX,
                      int coordY,
                      string sign = " ",
                      bool alreadyShooted = false,
                      bool isItFree = true)
        {
            CoordX = coordX;
            CoordY = coordY;
            Sign = sign;
            AlreadyShooted = alreadyShooted;
            IsItFree = isItFree;
        }

        public static void UpdateOccupationToShip(int coordX,
                                int coordY,
                                List<List<string>> tableName)
        {
            Square square = Ocean.tableName[coordX][coordY];
            square.Sign = "S"; // S for Ship
        }

        public void Shoot(int coordX,
                          int coordY,
                          string tableName)
        {
            Square square = Ocean.tableName[coordX][coordY];
            if (square.Sign == "S")
            {
                square.Sign = "X";
            }
            else
            {
                square.Sign = "O";
            }
        }
    }
}