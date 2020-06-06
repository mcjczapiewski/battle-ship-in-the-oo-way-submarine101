using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using static battle_ship_in_the_oo_way_submarine101.SQUARE.OccupationType;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square
    {

        public Coordinates Coordinates;
        public char OccupationType;
        public bool IsShoot;
    
        
        public Square(int row, int column, char occupationType='e', bool isShoot=false)
        {
            this.Coordinates = new Coordinates(row, column);
            this.OccupationType = occupationType;
            this.IsShoot = isShoot;
        }
        
        public string Status
        {
            get
            {
                return OccupationType.ToString();
            }
        }

        public bool IsOccupied
        {
            get
            {
                if (OccupationType == 'B' ||
                    OccupationType == 'C' ||
                    OccupationType == 'R' ||
                    OccupationType == 'D' ||
                    OccupationType == 'S' ||
                    OccupationType == 'X' ||
                    OccupationType == 'O')
                    return true;
            }
        }
    }
}