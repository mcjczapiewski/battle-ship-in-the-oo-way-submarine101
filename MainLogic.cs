using System;

namespace battle_ship_in_the_oo_way_submarine101
{
    public static class MainLogic
    {
        public static bool CheckIsWin()  //TODO 
        {
           
            return false; // MOCK!
        }


        public static bool IsPlaying()  //TODO
        {
            if (!CheckIsWin())
            {
                return true;  //MOCK!
            }

            return false;
        }

        public static void WelcomeText()
        {
            Console.WriteLine("Welcome in battleship!\n Please give me your name:");
            Console.ReadLine();
            Console.WriteLine("Please select ship to set:\n 1. Battleship\n 2. Carrier" +
                              "\n 3. Cruiser \n 4. Destroyer\n 5. Submarine");
            Console.ReadLine();
            Console.WriteLine("Please choose:\n 1. Horizontal\n 2. Vertical");
            Console.ReadLine();
        }
    }
}