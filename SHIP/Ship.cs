using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public bool IsHorizontal;
        public int Life;
        public string Name;
        public ShipEnum ShipType;

        public Ship(ShipEnum shipType, int life)
        {
            ShipType = shipType;
            Life = life;
        }

        public bool IsSunk => Life == 0;

        public void PlaceShipHorizontal(int coordX, int coordY, Ship newShip)
        {
            var maxY = coordY + newShip.Life;

            for (var i = coordY; i < maxY; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(coordX, i);
        }

        public void PlaceShipVertical(int coordX, int coordY, Ship newShip)
        {
            var maxX = coordX + newShip.Life;

            for (var i = coordX; i < maxX; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(i, coordY);
        }

        public void PlaceShip(PlayerChoicesShip playerChoices)
        {
            var newShip = ShipBuilder.ShipBuild(playerChoices.ShipType);
            switch (playerChoices.Direction)
            {
                case DirectionsEnum.Horizontal:
                    return PlaceShipHorizontal(coordX, coordY, newShip);
                default:
                    return PlaceShipVertical(coordX, coordY, newShip);
            }
        }
    }
}