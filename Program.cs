using battle_ship_in_the_oo_way_submarine101.OCEAN;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = new Ocean("XD");
            Ocean.PrintBoard();
            SQUARE.Square.UpdateOccupationToShip(2, 2);
            Ocean.PrintBoard();
            SQUARE.Square.Shoot(2, 3);
            Ocean.PrintBoard();
        }
    }
}
