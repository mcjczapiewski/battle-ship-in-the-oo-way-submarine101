
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101.Square
{
    public class Square
    {
 
        public Coordinates Coordinates { get; set; }
        public OccupationType OccupationType { get; set; }
        public bool IsShoot { get; set; }
        public string SignOnMap { get; set; }
        
        public Square(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
            SignOnMap = "[]";
            IsShoot = false;
            
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
                return OccupationType == OccupationType.Battleship
                    || OccupationType == OccupationType.Carrier
                    || OccupationType == OccupationType.Cruiser
                    || OccupationType == OccupationType.Submarine
                    || OccupationType == OccupationType.Destroyer;
            }
        }
    }

}