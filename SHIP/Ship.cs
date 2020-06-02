using battle_ship_in_the_oo_way_submarine101;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    public class Ship
    {
        public string name;
        public int length;
        public bool isHorizontal;
        public int shots;
        /// should be able to bring value of enum but doesnt work - public Shipmark = etc... TODO ///
        public int X, Y;
        public int Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool isSink
        {
            get
            { 
                return Hits >= Lenght; 
            }

        }
    }
}