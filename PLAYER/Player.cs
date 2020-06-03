using System;
using System.Dynamic;

namespace DefaultNamespace
{
    public class Player
    {
        Player player = new Player();
        private int mapNumber;
        private string mapsize;

        public int SetMap()
        {
            bool validatedMapSize = false;
            do
            {
                Console.Write("Please select map size");
                mapsize = Console.ReadLine();
                validatedMapSize = Int32.TryParse(mapsize, out mapNumber);

            } while (!validatedMapSize);

            return mapNumber;


        }
    }
    
}