using System;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public class Coordinates
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Coordinates(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
    }
}