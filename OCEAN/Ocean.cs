
using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using battle_ship_in_the_oo_way_submarine101.SQUARE;


namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public class Ocean
    {
        private string Name;
        static int CoordX;
        static int CoordY;

        public static Square[,] arrayOfSquares = new Square[10, 10];
        public static Square[,] arrayOfSq = new Square[10, 10];
        public Ocean(string name)
        {
            if (name != null) Name = name;

            for (CoordX = 0; CoordX < 10; CoordX++)
            {
                for (CoordY = 0; CoordY < 10; CoordY++)
                {
                    arrayOfSquares[CoordX, CoordY] = new Square(CoordX, CoordY);
                }
            }
        }

        //Ocean ocean = new Ocean("XD");
        public static void PrintBoard()
        {
            //Square square = new Square(CoordX, CoordY);

            //Console.WriteLine(ocean.Name);
            Console.WriteLine("   A B C D E F G H I J");
            for (CoordY = 0; CoordY < 10; CoordY++)
            {
                Console.Write(CoordY + 1);
                if (CoordY != 9)
                {
                     Console.Write(" ");
                }
                
                for (CoordX = 0; CoordX < 10; CoordX++)
                {
                    
                    Console.Write(" " + arrayOfSquares[CoordX, CoordY].Sign);
                    
                }
                Console.WriteLine();
            }

                //Console.WriteLine(square.Sign);
        }

    }
}