using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DefaultNamespace;
using static DefaultNamespace.Square;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public abstract class Ocean
    {
        public List<Square> Fields { get; set; }

        private Ocean()
        {
            Fields = new List<Square>();
            int mapSize = Player.MapSize;
            string name = "";
        }

        private Ocean(List<Square> fields)
        {
            Fields = fields;
            int i;
            int j;
            
            for (i = 0; i < Player.MapSize; i++)
            {
                
                for (j = 0; j < Player.MapSize; j++)
                {
                    fields.Add(new Square(i; j)
                }
            }
        }

        public string StringPrinter(char c, int count)
        {
            return (c * count).ToString();
        }

        public void PrintOcean(int length, int height, string name)
        {
            List<string> alphabet = new List<string>();
            Console.WriteLine("   A B C D E F G H I J ");
            
        }
    }




    public class MyBoard() : Ocean /// MyBoard that inheritate from Ocean ///
    {
        public MyBoard(int mapSize, string name, List<int> borders, List<int> fields) : base()
        {
            mapSize = Player.MapSize;
            name = "This is your board";
        }
    }
    
    public class EnemyBoard() : Ocean
    {
        public EnemyBoard(int mapSize, string name, List<int> borders, List<int>fields) : base()
        {
            mapSize = Player.MapSize;
            name = "This is an enemy board";
        }
    }
    
}
