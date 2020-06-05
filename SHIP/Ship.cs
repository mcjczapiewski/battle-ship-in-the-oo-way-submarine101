using battle_ship_in_the_oo_way_submarine101;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    public class Ship
    {
        public string Name;
        public int Length;
        public int Shots;
        public  OccupationType  OccupationType {get; set;}
        public int Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool IsSink
        {
            get
            { 
                return Hits >= Lenght; 
            }

        }
    }
}