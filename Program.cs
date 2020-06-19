using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using System;



namespace battle_ship_in_the_oo_way_submarine101
{
    internal class Program
    {
        private static void Main()
        {
            Ocean ocean = new Ocean("NewOcean");
            Ocean.PrintBoard(ocean.Name);
            new Ocean("XD");
            Ocean.PrintBoard("XD");

        }
    }
}