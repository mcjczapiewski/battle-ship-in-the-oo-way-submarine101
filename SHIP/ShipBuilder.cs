using System;
using System.Collections.Generic;
using System.Text;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class ShipBuilder
    {
        public static Ship ShipBuild(ShipEnum Ship)
        {
            switch (Ship)
            {
                case ShipEnum.Destroyer:
                    return new Ship(ShipEnum.Destroyer, 2);
                case ShipEnum.Submarine:
                    return new Ship(ShipEnum.Submarine, 3);
                case ShipEnum.Cruiser:
                    return new Ship(ShipEnum.Cruiser, 3);
                case ShipEnum.Battleship:
                    return new Ship(ShipEnum.Battleship, 4);
                default:
                    return new Ship(ShipEnum.Carrier, 5);
            }
        }
    }
}