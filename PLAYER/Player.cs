using System;
using System.Collections.Generic;
using System.Linq;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SHIP;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        public static string[] GetNameFromPlayer()
        {
            string player1 = "";
            string player2 = "";

            Console.Write("Player 1 name: ");
            player1 = Console.ReadLine();
            Console.WriteLine("Ok " + player1 + ", get ready for game!");
            Console.Write("Plater 2 name: ");
            player2 = Console.ReadLine();
            Console.WriteLine("Ok " + player2 + ", get ready for game!");
            return new string[] { player1, player2 };
        }

        public string Name { get; set; }
        public Ocean Ocean { get; set; }
        // public EnemyBoard EnemyBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSink);
            }
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Ship("Destroyer", 2,0,'D', false),
                new Ship("Carrier", 5,0,'R',false),
                new Ship("Cruiser", 3,0,'C',false),
                new Ship("Submarine", 3,0,'S',false),
                new Ship("Battleship", 4,0,'B',false),
            };
            Ocean = new Ocean();
            Ocean EnemyBoard = new Ocean();
        }

        public void PlaceShips()
        {
            foreach (var ship in Ships)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    Console.Write("Select row:");
                    var InputRow = int.Parse(Console.ReadLine());
                    int EndRow = InputRow;
                    Console.Write("Select column:");
                    var InputColumn = int.Parse(Console.ReadLine());
                    int EndColumn = InputColumn;
                    Console.Write("Ship will be horizontal or vertical? H/V");
                    var InputIsHorizontal = Console.ReadLine();
                    var UpperInputIsHorizontal = InputIsHorizontal.ToUpper();
                   
                    List<int> panelNumbers = new List<int>();
                    if (UpperInputIsHorizontal == "H")
                    {
                        for (int i = 1; i < Ship.Length; i++)
                        {
                            EndRow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < Ship.Length; i++)
                        {
                            EndColumn++;
                        }
                    }

                    //check boundaries
                    if(EndRow > 10 || EndColumn > 10)
                    {
                        isOpen = true;
                        continue;
                    }

                    // //Check if square is occupied
                    // var affectedSquares = Ocean.Ocean1().Range(InputRow, InputColumn, EndRow, EndColumn);
                    // if(affectedSquares.Any(x=>x.IsOccupied))
                    // {
                    //     isOpen = true;
                    //     continue;
                    // }
                    //
                    // foreach(var Square in affectedSquares)
                    // {
                    //     Square.OccupationType = ship.OccupationType;
                    // }
                    // isOpen = false;
                }
            }
        }

        private void PlayerShoot()
        {
            /// get players input to shoot ///
        }

    }
}