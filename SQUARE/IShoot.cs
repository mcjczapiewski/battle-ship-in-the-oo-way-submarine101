using System.Reflection;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using static battle_ship_in_the_oo_way_submarine101.OCEAN.Ocean;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public interface IShoot
    {
        /// <summary>
        /// Check what type of square is this
        /// </summary>
        void CheckOccupation();
        
        
        void SetProperMark(int Row, int Column) 
        {
            
            
            // check at opponents board square type from array
            var whatItShouldBe = 
            // change mark at my board to the mark of opponent
            Square
            var isItOccupied = new Square.IsOccupied();
            if (whatItShouldBe == Square.IsOccupied)
            {
                myBoard.Squares[Row, Column] = OccupationType.Miss;
            }
            else if (isItOccupied)
            {
                myBoard.Squares[Row, Column] = OccupationType.Hit;
            }
        }

        object Square { get; set; }

        /// <summary>
        /// If the square is a ship, hit it
        /// </summary>
        void HitThatShip();

        {
            if Square.isOccupied() ()
        }
    }
}