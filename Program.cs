using System;
using System.Threading;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        public static void ShowIntroScreen()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#######################################");
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("        Welcome to Batttleship!      ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#");
            Console.WriteLine("#######################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        public static void Header()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#######################################");
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("             Batttleship            ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#");
            Console.WriteLine("#######################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }

        static void Main()
        {
            ShowIntroScreen();
            Header();
            Player.GetNameFromPlayer();
            Console.WriteLine("Now we print boards to see how they look.");
            Ocean.DrawBoard();
            Console.ReadKey();

        }
    }

   
}
