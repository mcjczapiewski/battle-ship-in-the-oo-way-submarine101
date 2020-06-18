
using battle_ship_in_the_oo_way_submarine101.OCEAN;


namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square
    {
        public bool AlreadyShooted;
        public int CoordX;


        public int CoordY;
        public bool IsItFree;
        public string Sign;

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
            var square = Ocean.arrayOfSquares[coordX, coordY];
            square.Sign = "S";
            square.IsItFree = false;
        }

        public static void Shoot(int coordX,
            int coordY)
        {
            var square = Ocean.arrayOfSquares[coordX, coordY];

            if (square.Sign == "S")
                square.Sign = "X";
            else
                square.Sign = "O";
        }
    }
}