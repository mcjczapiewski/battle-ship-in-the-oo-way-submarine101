using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square
    {

        public Coordinates Coordinates;
        public char OccupationType;


        public Square(int CoordinateX, int CoordinateY, char occupationType='e', bool isShoot=false)
        {
            this.Coordinates = new Coordinates(CoordinateX, CoordinateY);
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
                return false;
            }
        }

        public bool IsShoot
        {
            get
            {
                if (OccupationType == 'X')
                    return true;
                return false;

            }
            set => throw new NotImplementedException();
        }
    }
}