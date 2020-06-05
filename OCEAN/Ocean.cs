using System;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN

{
    public class Ocean
    {
        public List<Panel> Panels { get; set; }

        public Ocean()
        {
            Panels = new List<Panel>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Panels.Add(new Panel(i, j));
                }
            }
        }
    }

    public void OutputBoards()
    {
        Console.WriteLine(Name);
        Console.WriteLine("Ship Board:                          Firing Board:");
        for (int row = 1; row <= 10; row++)
        {
            for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
            {
                Console.Write(GameBoard.Panels.At(row, ownColumn).Status + " ");
            }
            Console.Write("                ");
            for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
            {
                Console.Write(FiringBoard.Panels.At(row, firingColumn).Status + " ");
            }
            Console.WriteLine(Environment.NewLine);
        }
        Console.WriteLine(Environment.NewLine);
    }
}
