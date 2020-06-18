using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101
{
    internal class Program
    {
        private static void Main()
        {
            Ocean ocean = new Ocean("XD");
            Ocean.PrintBoard();

            Square.UpdateOccupationToShip(2, 2);
            Ocean.PrintBoard();
            Square.Shoot(2, 3);

            Ocean.PrintBoard();
            PLAYER.Player.GetTheCoords();

        }
    }
}