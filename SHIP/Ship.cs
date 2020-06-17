using System;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public ShipEnum ShipType;
        public string Name;
        public int Life;
        public bool IsHorizontal;
        public bool IsSunk
        {
            get
            {
                return Life == 0;
            }
        }
        public Ship(ShipEnum shipType, int life)
        {
            ShipType = shipType;
            Life = life;
        }
        public void PlaceShipHorizontal(int coordX, int coordY, Ship newShip)
        {
            int maxY = coordY + newShip.Life;

            for (int i = coordY; i < maxY; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(coordX, i);
        }

        public void PlaceShipVertical(int coordX, int coordY, Ship newShip)
        {
            int maxX = coordX + newShip.Life;

            for (int i = coordX; i < maxX; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(i, coordY);
        }
    }
}