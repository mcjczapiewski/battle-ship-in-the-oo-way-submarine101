using System;
using System.Dynamic;

namespace DefaultNamespace
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