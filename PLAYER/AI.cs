using battle_ship_in_the_oo_way_submarine101.SHIP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class AI
    {
        public static List<(int, int)> AiSinkShipHits;

        public static int CoordXFirstHit;

        public static int CoordYFirstHit;

        public static int CoordXStored;

        public static int CoordYStored;

        public static List<string> ShipTypes
                                    = new List<string> { "D", "C", "S", "B", "R" };

        public static bool WasItHit = false;

        public static bool AiGenerateShipDirection()
        {
            Random random = new Random();
            var randomBool = random.Next(2) == 1;
            if (randomBool == true)
            {
                return true;
            }
            return false;
        }

        public static (int coordX, int coordY) AiGetCoords(OCEAN.Ocean playerEmptyBoard)
        {
            int coordX, coordY;
            do
            {
                Random random = new Random();
                coordX = random.Next(0, 10);
                coordY = random.Next(0, 10);
            } while (playerEmptyBoard.ArrayOfSquares[coordX, coordY].AlreadyShooted);
            return (coordX, coordY);
        }

        public static (int coordX, int coordY) AiGetCoordsToKill(OCEAN.Ocean playerEmptyBoard,
                                                                  bool isItSunk)
        {
            Random random = new Random();
            int coordX;
            int coordY;
            do
            {
                if (AiSinkShipHits.Count == 0)
                {
                    ShipHitsListIsEmpty(isItSunk);
                }
                int index = random.Next(AiSinkShipHits.Count);
                (coordX, coordY) = AiSinkShipHits[index];
                AiSinkShipHits.RemoveAt(index);
            } while (!Enumerable.Range(0, 10).Contains(coordX)
                     || !Enumerable.Range(0, 10).Contains(coordY)
                     || playerEmptyBoard.ArrayOfSquares[coordX, coordY].AlreadyShooted);
            return (coordX, coordY);
        }

        private static void ShipHitsListIsEmpty(bool isItSunk)
        {
            if (WasItHit && !isItSunk)
            {
                if (CoordXFirstHit < CoordXStored && CoordYFirstHit == CoordYStored)
                {
                    AiSinkShipHits.Clear();
                    AiSinkShipHits = new List<(int, int)>
                                    {
                                        (CoordXFirstHit - 1, CoordYStored),
                                    };
                }
                else if (CoordXFirstHit > CoordXStored && CoordYFirstHit == CoordYStored)
                {
                    AiSinkShipHits.Clear();
                    AiSinkShipHits = new List<(int, int)>
                                    {
                                        (CoordXFirstHit + 1, CoordYStored),
                                    };
                }
                else if (CoordYFirstHit < CoordYStored && CoordXFirstHit == CoordXStored)
                {
                    AiSinkShipHits.Clear();
                    AiSinkShipHits = new List<(int, int)>
                                    {
                                        (CoordXStored, CoordYFirstHit - 1),
                                    };
                }
                else
                {
                    AiSinkShipHits.Clear();
                    AiSinkShipHits = new List<(int, int)>
                                    {
                                        (CoordXStored, CoordYFirstHit + 1),
                                    };
                }
            }
        }

        public static Ship AiGetShipType()
        {
            Random random = new Random();
            string randomShip;
            var randomIndex = random.Next(ShipTypes.Count);
            randomShip = ShipTypes[randomIndex];
            return Ship.CreateShip(randomShip);
        }
    }
}