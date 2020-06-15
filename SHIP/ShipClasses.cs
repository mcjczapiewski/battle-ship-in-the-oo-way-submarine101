using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class ShipClasses
    {
        public static Ship ShipClass(Ships type)
        {
            switch (type)
            {
                case Ships.Destroyer:
                    return new Ship(Ships.Destroyer, 2, "D");
                case Ships.Cruiser:
                    return new Ship(Ships.Cruiser, 3, "C");
                case Ships.Submarine:
                    return new Ship(Ships.Submarine, 3, "S");
                case Ships.Battleship:
                    return new Ship(Ships.Battleship, 4, "B");
                default:
                    return new Ship(Ships.Carrier, 5, "R");
            }
        }
    }
}
