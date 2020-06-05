using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Security.Cryptography;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public string Name;
        public int Length = 0;
        public int Shots = 0;
        public char OccupationType
            ;

        public bool IsSink
        {
            get
            {
                return Shots >= Length;

            }
            set => throw new NotImplementedException();
        }

        public Ship(string name, int length, int shots, char occupationType, bool isSink)
        {
            this.Length = length;
            this.Name = name;
            this.Shots = shots;
            this.OccupationType = occupationType;
            this.Shots = shots;
            this.IsSink = isSink;

        }
        Ship Destroyer = new Ship("Destroyer", 2,0,'D', false);
        Ship Carrier = new Ship("Carrier", 5,0,'R',false);
        Ship Cruiser = new Ship("Cruiser", 3,0,'C',false);
        Ship Submarine = new Ship("Submarine", 3,0,'S',false);
        Ship Battleship = new Ship("Battleship", 4,0,'B',false);
    }
}