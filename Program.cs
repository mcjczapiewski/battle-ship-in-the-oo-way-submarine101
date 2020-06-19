using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = new Ocean("XD");
            Ship ship1 = new Ship("Destroyer", 2);
            Ship ship2 = new Ship("Submarine", 5);
            //Ocean.DrawBoard();
            //Ship.PlaceShip(2, 2, ship1.Life, true);
            //Ocean.DrawBoard();
            Ocean.PrintBoard();
            // //Square.UpdateOccupationToShip(2, 2);
            Ship.PlaceShip(1, 2, ship1.Life, false);
            Console.WriteLine(" ");
            Ocean.PrintBoard();
            Ship.PlaceShip(1, 2, ship2.Life, true);
            Ocean.PrintBoard();
            // Console.Read();
            // Square.Shoot(2, 3);
            // Ocean.PrintBoard();
        }
    }
}
//{
//    internal class Program
//    {
//        private static void Main()
//        {
//            new Ocean("XD");
//            Ocean.PrintBoard("test");
//            Square.UpdateOccupationToShip(2, 2);
//            Player player1 = Player.CreateNewPlayer();
//            Player.PlayerMove(player1);
//            Ocean.PrintBoard("test");
//            Player.PlayerMove(player1);
//            Ocean.PrintBoard("test");
//            Console.ReadKey();
//        }
//    }
//}