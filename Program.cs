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
            Ship ship1 = new Ship(ShipEnum.Destroyer, 2);
            Ocean.PrintBoard();
            //Square.UpdateOccupationToShip(2, 2);
            Ship.PlaceShip(1, 2, ship1.Life, true);

            Ocean.PrintBoard();
            Console.Read();
            Square.Shoot(2, 3);

            Ocean.PrintBoard();
            PLAYER.Player.GetTheCoords();

        }
    }
}