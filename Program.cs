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
            Player player1 = Player.CreateNewPlayer();
            Player.PlayerMove(player1);
            Ocean.PrintBoard();
            Player.PlayerMove(player1);
            Ocean.PrintBoard();
            Console.ReadKey();
        }
    }
}