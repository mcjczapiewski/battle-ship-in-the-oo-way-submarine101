using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DefaultNamespace;
using static battle_ship_in_the_oo_way_submarine101.SQUARE.Square;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public abstract class Ocean
    {
        public int mapSize;
        public string name;
        public List<int> borders;
        public List<int> fields;
        

        public Ocean(int mapSize, string name, List<int> borders, List<int> fields )
        {
            this.mapSize = Player.MapSize;
            this.name = name;
            this.borders = borders;
            this.fields = fields;
        }

        // public string StringPrinter(char c, int count)
        // {
        //     return (c * count).ToString();
        // }
        
        public void PrintOcean(int length, int height, string name)
        {
            Console.WriteLine();
        }
        
        
        public void PlaceShips
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    public class MyBoard() : Ocean /// MyBoard that inheritate from Ocean ///
    {
        public MyBoard(int mapSize, string name, List<int> borders, List<int> fields) : base(mapSize, name, borders, fields)
        {
            mapSize = Player.MapSize;
            name = "This is your board";
        }
    }
    
    public class EnemyBoard() : Ocean
    {
        public EnemyBoard(int mapSize, string name, List<int> borders, List<int>fields) : base(mapSize, name, borders, fields)
        {
            mapSize = Player.MapSize;
            name = "This is an enemy board";
        }
    }
    
}
