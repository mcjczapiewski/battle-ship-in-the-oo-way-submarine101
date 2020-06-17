<<<<<<< HEAD

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using battle_ship_in_the_oo_way_submarine101.Ocean;
using battle_ship_in_the_oo_way_submarine101.SQUARE;


=======
﻿using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
>>>>>>> 86abcf90496af3b82598feffc3389056f898bc19

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Ocean.Ocean ocean = new Ocean.Ocean("XD");

            Ocean.PrintBoard();
            Square.UpdateOccupationToShip(2, 2);
            Ocean.PrintBoard();
            Square.Shoot(2, 3);
            Ocean.PrintBoard();
        }
    }
}

