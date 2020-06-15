using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Security.Cryptography;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using System.Linq;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public Ships Ships;
        public string Name { get { return Ships.ToString();} }
        public int Life;
        public int Shots;
        public string Sign;
        public char OccupationType;
        public int ShipIndex;
        public Coordinates[] OceanPositions;
        public bool IsSink
        {
            get
            {
                return Shots >= Life;
            }
        }
        public Ship(Ships ships, int lifes, string sign)
        {
            Ships = ships;
            Life = lifes;
            Sign = sign;
            OceanPositions = new Coordinates[lifes];
        }
        public GameStatus ShootingShip(Coordinates position)
        {
            if (OceanPositions.Contains(position))
            {
                Life--;
                if (Life == 0)
                {
                    return GameStatus.HitAndSunk;
                }
                return GameStatus.Hit;
            }
            return GameStatus.Miss;
        }
    }
}