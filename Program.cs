
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using battle_ship_in_the_oo_way_submarine101.Ocean;
using battle_ship_in_the_oo_way_submarine101.SQUARE;



namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {

        static void Main()
        {
        
            Ocean ocean = new Ocean.Ocean("XD");
            Ocean.PrintBoard();
            Square.UpdateOccupationToShip(2, 2);
            Ocean.PrintBoard();
            Square.Shoot(2, 3);
            Ocean.PrintBoard();
        }
    }
}

