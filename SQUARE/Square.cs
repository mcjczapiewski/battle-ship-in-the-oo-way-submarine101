using System;
using battle_ship_in_the_oo_way_submarine101.OCEAN;

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
                      string sign = ". ",
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
                                int coordY)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            square.Sign = "S "; // please leave this space after sign
            square.IsItFree = false;
        }

        public static void Shoot(int coordX,
                          int coordY)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            if (square.Sign == "S ") // please leave this space after sign
            {
                Console.ForegroundColor = ConsoleColor.Red;
                square.Sign = "X ";// please leave this space after sign
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                square.Sign = "O ";// please leave this space after sign
            }
        }
    }
}