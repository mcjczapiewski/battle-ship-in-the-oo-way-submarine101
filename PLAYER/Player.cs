using System;
using System.Dynamic;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101.PLAYER
{
    public class Player
    {
        public string Name { get; set; }
        public Ocean Ocean { get; set; }
        public ShootOcean ShootOcean { get; set; }
        public List<Ship> Ships { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            Ocean = new Ocean();
            ShootOcean = new ShootOcean();
        }

        public void PlaceShips()
        {
            foreach (var ship in Ships)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    Console.Write("Select row:");
                    var InputRow = Console.ReadLine();
                    int EndRow = InputRow;
                    Console.Write("Select column:");
                    var InputColumn = int.Parse(Console.ReadLine());
                    int EndColumn = InputColumn;
                    Console.Write("Ship will be horizontal or vertical? H/V");
                    var InputIsHorizontal = Console.ReadLine();
                    var UpperInputIsHorizontal = InputIsHorizontal.ToUpper();
                    if (UpperInputIsHorizontal == "H")
                    {
                        IsHorizontal = true;
                    }
                    else
                    {
                        IsHorizontal = false;
                    }
                    
                    List<int> panelNumbers = new List<int>();
                    if (IsHorizontal is true)
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

                    //Check if square is occupied
                    var affectedPanels = GameBoard.Panels.Range(startrow, startcolumn, endrow, endcolumn);
                    if(affectedPanels.Any(x=>x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach(var panel in affectedPanels)
                    {
                        Square.OccupationType = ship.OccupationType;
                    }
                    isOpen = false;
                }
            }
        }

        private Coordinates PlayerShot()
        {
            /// get players input to shoot ///
        }
    }
}