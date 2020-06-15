using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square : IShoot
    {

        public Coordinates Coordinates;
        public bool isShoot;

        public char OccupationType
        {
            get
            {
                return OccupationType;
            }
            set
            {
                
            };
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
                if (OccupationType == 'e')
                    return false;
                return false;
            }


        public Square(int row, int column)
        {
            this.Coordinates = new Coordinates(row, column);
            char occupationType;
            this.IsShoot = isShoot;
        }
        
        public string Status
        {
            get
            {
                return OccupationType.ToString();
            }
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