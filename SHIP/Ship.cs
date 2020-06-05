using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public abstract class Ship
    {
        public string Name;
        public int Length;
        public int Shots;
        public char OccupationType();
        public bool IsSink
        {
            get
            { 
                return Hits >= Lenght; 
            }

        }
    }
}