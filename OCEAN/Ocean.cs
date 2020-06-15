using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using battle_ship_in_the_oo_way_submarine101.SQUARE;


namespace battle_ship_in_the_oo_way_submarine101.Ocean
{
    public class Ocean
    {
        private string Name;
        int CoordX;
        int CoordY;

        public Ocean(string name)
        {
            Square[,] arrayOfSquares = new Square[10, 10];

            if (name != null) Name = name;

            for (CoordX = 0; CoordX < 10; CoordX++)
            {
                for (CoordY = 0; CoordY < 10; CoordY++)
                {
                    arrayOfSquares[CoordX, CoordY] = new Square(CoordX, CoordY);
                }
            }
        }


        public void PrintBoard(Array arrayOfSquares)
        {
            Square square = new Square();
            Ocean ocean = new Ocean("XD");
            Console.WriteLine(ocean.Name);
            Console.WriteLine("A B C D E F G H I J");
            foreach (var field in arrayOfSquares)
            {
                for (CoordY = 0; CoordX < 10; CoordY++)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine(i);
                    }
                }

                Console.WriteLine(square.Sign);
            }
        }

    }
}
