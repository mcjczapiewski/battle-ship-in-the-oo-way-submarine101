using System;
using System.Dynamic;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        Player player = new Player();
        public static int MapSize;
        private string _inputMapSize;

        public int SetMap()
        {
            bool validatedMapSize = false;
            do
            {
                Console.Write("Please select map size");
                _inputMapSize = Console.ReadLine();
                validatedMapSize = Int32.TryParse(_inputMapSize, out MapSize);

            } while (!validatedMapSize);

            return MapSize;


        }
    }
    
}