using System;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.Ocean
{
    public class Ocean
    {
        private static int CoordX;
        private static int CoordY;

        public static Square[,] arrayOfSquares = new Square[10, 10];
        public static Square[,] arrayOfSq = new Square[10, 10];
        private static readonly Ocean ocean = new Ocean("XD");
        private readonly string Name;
        private Square square = new Square(CoordX, CoordY);

        public Ocean(string name)
        {
            if (name != null) Name = name;

            for (CoordX = 0; CoordX < 10; CoordX++)
            for (CoordY = 0; CoordY < 10; CoordY++)
                arrayOfSquares[CoordX, CoordY] = new Square(CoordX, CoordY);
        }

        public void PrintBoard(Array arrayOfSquares)
        {
            var square = new Square(CoordX, CoordY);
            var ocean = new Ocean("XD");
            Console.WriteLine(ocean.Name);
            Console.WriteLine("A B C D E F G H I J");
            foreach (var field in arrayOfSquares)
            {
                for (CoordY = 0; CoordX < 10; CoordY++)
                for (var i = 1; i <= 10; i++)
                    Console.WriteLine(i);

                Console.WriteLine(square.Sign);
            }
        }

        public static void PrintBoard()
        {
            Console.WriteLine(ocean.Name);
            Console.WriteLine("   A B C D E F G H I J");
            for (CoordY = 0; CoordY < 10; CoordY++)
            {
                Console.Write(CoordY + 1);
                if (CoordY != 9) Console.Write(" ");

                for (CoordX = 0; CoordX < 10; CoordX++) Console.Write(" " + arrayOfSquares[CoordX, CoordY].Sign);

                Console.WriteLine();
            }

            //Console.WriteLine(square.Sign);
        }

        // public bool IsItBorder()
        // {
        //     if (Ocean.arrayOfSquares != null && (Ocean.arrayOfSquares(CoordX) < 0 && Ocean.arrayOfSquares(CoordX) > 10)
        //     {
        //         
        //     }
        //         return false;
        // }
    }
}