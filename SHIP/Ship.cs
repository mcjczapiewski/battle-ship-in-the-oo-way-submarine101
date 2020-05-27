using battle_ship_in_the_oo_way_submarine101;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    public abstract class Ship
    {
        public string Name;
        public int Length;
        public bool isHorizontal;
        public bool isVertical;
        public int Hits;
        public int positionXY(int x, int y);
        public bool isSink
        {
            get
            { 
                return Hits >= Lenght; 
            }
        }
    }
}