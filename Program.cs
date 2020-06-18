using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ocean = new Ocean.Ocean("XD");

            Ocean.Ocean.PrintBoard();
            Square.UpdateOccupationToShip(2, 2);
            Ocean.Ocean.PrintBoard();
            Square.Shoot(2, 3);
            Ocean.Ocean.PrintBoard();
        }
    }
}