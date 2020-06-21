using battle_ship_in_the_oo_way_submarine101.SHIP;
using System.Collections.Generic;
using System.Linq;

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

        public static (bool, bool) Shoot(int coordX,
                                         int coordY,
                                         Square[,] playerEmptyBoard,
                                         Square[,] enemyShipsBoard,
                                         Dictionary<string, SHIP.Ship> enemyShips)
        {
            Square square = playerEmptyBoard[coordX, coordY];
            Square enemySquare = enemyShipsBoard[coordX, coordY];
            if (enemyShips.ContainsKey(enemySquare.Sign))
            {
                MarkAsHit(enemyShips, square, enemySquare);
                if (enemyShips[enemySquare.Sign].Life == 0)
                {
                    enemyShips.Remove(enemySquare.Sign);
                    enemySquare.Sign = "X ";
                    List<(int, int)> thoseWereMarked = new List<(int, int)>();
                    MarkAroundSunkShip(coordX - 1,
                                       coordY - 1,
                                       playerEmptyBoard,
                                       enemyShipsBoard,
                                       thoseWereMarked);
                    return (true, true);
                }
                enemySquare.Sign = "X ";
                return (true, false);
            }
            else
            {
                square.Sign = "O ";// please leave this space after sign
                square.AlreadyShooted = true;
                enemySquare.Sign = "O ";
                return (false, false);
            }
        }

        public static void UpdateOccupationToShip(int coordX,
                                                  int coordY,
                                                  Square[,] playerArray,
                                                  string shipSign)
        {
            Square square = playerArray[coordX, coordY];
            square.Sign = shipSign;
            square.IsItFree = false;
        }

        private static void ChangeSignAndAlreadyShooted(Square[,] playerEmptyBoard,
                                                        Square[,] enemyShipsBoard,
                                                        int i,
                                                        int j)
        {
            playerEmptyBoard[i, j].Sign = "O ";
            playerEmptyBoard[i, j].AlreadyShooted = true;
            enemyShipsBoard[i, j].Sign = "O ";
        }

        private static void MarkAroundSunkShip(int coordX,
                                               int coordY,
                                               Square[,] playerEmptyBoard,
                                               Square[,] enemyShipsBoard,
                                               List<(int, int)> thoseWereMarked)
        {
            for (int i = coordX; i < coordX + 3; i++)
            {
                for (int j = coordY; j < coordY + 3; j++)
                {
                    if (Enumerable.Range(0, 10).Contains(i)
                        && Enumerable.Range(0, 10).Contains(j)
                        && !thoseWereMarked.Contains((i, j)))
                    {
                        switch (playerEmptyBoard[i, j].Sign)
                        {
                            case ". ":
                                thoseWereMarked.Add((i, j));
                                ChangeSignAndAlreadyShooted(playerEmptyBoard,
                                                            enemyShipsBoard,
                                                            i,
                                                            j);
                                break;
                            case "X " when !thoseWereMarked.Contains((i, j)):
                                thoseWereMarked.Add((i, j));
                                MarkAroundSunkShip(i - 1,
                                                   j - 1,
                                                   playerEmptyBoard,
                                                   enemyShipsBoard,
                                                   thoseWereMarked);
                                break;
                        }
                    }
                }
            }
        }

        private static void MarkAsHit(Dictionary<string, Ship> enemyShips,
                                      Square square,
                                      Square enemySquare)
        {
            square.Sign = "X ";// please leave this space after sign
            square.AlreadyShooted = true;
            enemyShips[enemySquare.Sign].Life--;
        }
    }
}