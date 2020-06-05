namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public abstract class IShoot
    {
        /// <summary>
        /// Check what type of square is this
        /// </summary>
        public abstract void CheckOccupation();

        /// <summary>
        /// Change the symbol of square in my array
        /// </summary>
        /// <param name="Row">from user input</param>
        /// <param name="Column">from user input</param>
        public void SetProperMark(int Row, int Column)
        {
            // check at opponents board square type from array
            var whatItShouldBe = OCEAN.Ocean.EnemyBoard.fields[Row, Column];
            // change mark at my board to the mark of opponent
            var isItOccupied = new Square.IsOccupied;
            if (whatItShouldBe == OccupationType.Empty)
            {
                OCEAN.Ocean.MyBoard.fields[Row, Column] = OccupationType.Miss;
            }
            else if (isItOccupied)
            {
                OCEAN.Ocean.MyBoard.fields[Row, Column] = OccupationType.Hit;
            }
        }

        /// <summary>
        /// If the square is a ship, hit it
        /// </summary>
        public abstract void HitThatShip();
    }
}