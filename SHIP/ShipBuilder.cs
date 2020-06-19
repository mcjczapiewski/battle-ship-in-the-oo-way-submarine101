namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class ShipBuilder
    {
        public static Ship ShipBuild(ShipEnum Ship)
        {
            switch (Ship)
            {
                case ShipEnum.Destroyer:
                    return new Ship("Destroyer", 2);
                case ShipEnum.Submarine:
                    return new Ship("Submarine", 3);
                case ShipEnum.Cruiser:
                    return new Ship("Cruiser", 3);
                case ShipEnum.Battleship:
                    return new Ship("Battleship", 4);
                default:
                    return new Ship("Carrier", 5);
            }
        }
    }
}