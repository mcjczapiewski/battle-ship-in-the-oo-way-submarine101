
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using System;
using battle_ship_in_the_oo_way_submarine101.PLAYER;


namespace battle_ship_in_the_oo_way_submarine101
{
    internal class Program
    {
        private static void Main()
        {

            Ocean ocean = new Ocean("XD");

            Console.WriteLine(Ocean.NewMethodPrinting(ocean));
            

            new Ocean("XD");
            Ocean.PrintBoard("XD");
            Square.UpdateOccupationToShip(2, 2);
            Player player1 = Player.CreateNewPlayer();

        }
    }
}