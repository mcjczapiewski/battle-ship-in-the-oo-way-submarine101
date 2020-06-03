using System;
using System.Threading;
using battle_ship_in_the_oo_way_submarine101.OCEAN;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        static void Main(string[] args)
        {
            while (isPlayng())
            {

                Console.WriteLine("Welcome in battleship!");
                Player.ChoosePlayer();
                Ocean.PrintOcean();
                SetShips();
                Shoot(); /// here loop is starting///
                CheckIsWin();
                MarkSquare(); /// here is ending?///
            }
            
        }
    }
}
