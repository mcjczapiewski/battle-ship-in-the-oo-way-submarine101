using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in battleship!");
            ChoosePlayer();
            PrintBoard();
            SetShips();
            Shoot(); /// here loop is starting///
            CheckIsWin();
            MarkSquare();/// here is ending?///
            
            



        }
    }
}
