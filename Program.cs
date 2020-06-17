using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = new Ocean("XD");
            Ocean.PrintBoard();
            Square.UpdateOccupationToShip(2, 2);
            Ocean.PrintBoard();
            Square.Shoot(2, 3);
            Ocean.PrintBoard();
        }
    }
}