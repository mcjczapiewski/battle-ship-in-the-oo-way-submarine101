using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public class Ocean
    {
        private string Name;

        private static int CoordX;
        private static int CoordY;

        public static Square[,] arrayOfSquares = new Square[10, 10];
        


        public Ocean(string name)
        {
            if (name != null) Name = name;

            for (CoordX = 0; CoordX < 10; CoordX++)
            for (CoordY = 0; CoordY < 10; CoordY++)
                arrayOfSquares[CoordX, CoordY] = new Square(CoordX, CoordY);
        }
        
        public static void PrintBoard()
        {
            Ocean ocean = new Ocean("Board");
            Console.WriteLine(ocean.Name);
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J ");
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