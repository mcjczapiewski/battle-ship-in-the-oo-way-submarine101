using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using System;


namespace battle_ship_in_the_oo_way_submarine101
{
    internal class Program
    {
        private static void Main()
        {
            Ocean ocean = new Ocean("XD");

            Console.WriteLine(Ocean.NewMethodPrinting(ocean));
            
            

        }
    }
}