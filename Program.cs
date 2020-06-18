using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    internal class Program
    {
        private static void Main()
        {
            new Ocean("XD");
            Ocean.PrintBoard();
            Square.UpdateOccupationToShip(2, 2);
            Ocean.PrintBoard();
            Player.PlayerMove();
            Ocean.PrintBoard();
            Console.ReadKey();
        }
    }
}