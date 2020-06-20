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
                                int coordY, Square[,] playerArray)
        {
            Square square = playerArray[coordX, coordY];
            square.Sign = "S "; // please leave this space after sign
            square.IsItFree = false;
        }

        public static bool Shoot(int coordX,
                          int coordY, Square[,] enemyEmptyBoard, Square[,] enemyShipsBoard)
        {
            Square square = enemyEmptyBoard[coordX, coordY];
            Square enemySquare = enemyShipsBoard[coordX, coordY];

            if (enemySquare.Sign == "S ") // please leave this space after sign
            {
                square.Sign = "X ";// please leave this space after sign
                return true;
            }
            else
            {
                square.Sign = "O ";// please leave this space after sign
                return false;
            }
        }
    }
}