using System;
using System.Threading;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101
{
    class Program
    {
        private bool CheckIsWin()
        {
            return false; // MOCK!
        }


        private bool IsPlaying()
        {
            if (!CheckIsWin())
            {
                return true;
            }

            return false;
        }
    
        static void Main()
        {
            OutputScreen.ShowIntroScreen();
            OutputScreen.Header();
            Player.GetNameFromPlayer();
            Console.WriteLine("Now we print boards to see how they look.");
            Ocean.DrawBoard();
            Console.ReadKey();


            // Square sqr = new Square(1,2,'e', false);
            // Ocean ocean = new Ocean();


            //Console.WriteLine("Welcome in battleship!");
            //Console.WriteLine("Please select ship to set:\n 1. Battleship\n 2. Carrier" +
            //                  "\n 3. Cruiser \n 4. Destroyer\n 5. Submarine");
            //Console.ReadLine();
            //Console.WriteLine("Please choose:\n 1. Horizontal\n 2.Vertical");
            //Console.ReadLine();

            // SetShips();
            // Shoot(); /// here loop is starting///
            // CheckIsWin();
            // MarkSquare(); /// here is ending?///
            // }

        }
    }

   
}
