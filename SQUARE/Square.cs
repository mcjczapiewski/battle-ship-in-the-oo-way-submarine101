using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square
    {
        public Dictionary<Coordinates, ShotTrack> ShotTrack;
        public Ship[] ShipList;
        public int ShipIndex;

        public Square()
        {
            ShotTrack = new Dictionary<Coordinates, ShotTrack>();
            ShipList = new Ship[5];
            ShipIndex = 0;
        }
        //ublic ShotTrack CheckCoordinate(Coordinates coordinates)
        private void IsShipHit(Coordinates coordinate, ShotFeedback place)
        {
            place.GameStatus = GameStatus.Miss;

            foreach (var ship in ShipList)
            {
                if (ship.IsSink)
                    continue;

                GameStatus status = ship.ShootingShip(coordinate);

                switch (status)
                {
                    case GameStatus.Hit:
                        place.GameStatus = GameStatus.Hit;
                        place.ShipImpact = ship.Name;
                        ShotTrack.Add(coordinate, SQUARE.ShotTrack.Hit);
                        break;
                    case GameStatus.HitAndSunk:
                        place.GameStatus = GameStatus.HitAndSunk;
                        place.ShipImpact = ship.Name;
                        ShotTrack.Add(coordinate, SQUARE.ShotTrack.Hit);
                        break;
                }

                if (status != GameStatus.Miss)
                    break;
            }

            if (place.GameStatus == GameStatus.Miss)
            {
                ShotTrack.Add(coordinate, SQUARE.ShotTrack.Miss);
            }
        }
        private void VictoryCheck(ShotFeedback place)
        {
            if (place.GameStatus == GameStatus.HitAndSunk)
            {
                if (ShipList.All(s => s.IsSink))
                    place.GameStatus = GameStatus.Victory;
            }
        }
        public ShipPlaceStatus PlaceShip(ShipPlacement place)
        {
            ShipIndex = 0;
            if (ShipIndex > 4)
                throw new Exception("Maximum number of ships is 5.");


            if (!IsCoordinateValid(place.Coordinate))
                return ShipPlaceStatus.NoSpace;

            Ship newShip = ShipClasses.ShipClass(place.ShipType);
            switch (place.Direction)
            {
                case ShipDirection.Down:
                    return PlaceShipDown(place.Coordinate, newShip);
                case ShipDirection.Up:
                    return PlaceShipUp(place.Coordinate, newShip);
                case ShipDirection.Left:
                    return PlaceShipLeft(place.Coordinate, newShip);
                default:
                    return PlaceShipRight(place.Coordinate, newShip);
            }
        }

        private ShipPlaceStatus PlaceShipRight(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int maxY = coordinate.YCoordinate + newShip.OceanPositions.Length;

            for (int i = coordinate.YCoordinate; i < maxY; i++)
            {
                var currentCoordinate = new Coordinates(coordinate.XCoordinate, i);
                if (!IsCoordinateValid(currentCoordinate))
                    return ShipPlaceStatus.NoSpace;

                if (IsShipOverlapping(currentCoordinate))
                    return ShipPlaceStatus.Overlap;

                newShip.OceanPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToOcean(newShip);
            return ShipPlaceStatus.Ok;
        }

        private ShipPlaceStatus PlaceShipLeft(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int minY = coordinate.YCoordinate + newShip.OceanPositions.Length;

            for (int i = coordinate.YCoordinate; i > minY; i--)
            {
                var currentCoordinate = new Coordinates(coordinate.XCoordinate, i);
                if (!IsCoordinateValid(currentCoordinate))
                    return ShipPlaceStatus.NoSpace;

                if (IsShipOverlapping(currentCoordinate))
                    return ShipPlaceStatus.Overlap;

                newShip.OceanPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToOcean(newShip);
            return ShipPlaceStatus.Ok;
        }
        private ShipPlaceStatus PlaceShipUp(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int minX = coordinate.XCoordinate + newShip.OceanPositions.Length;

            for (int i = coordinate.XCoordinate; i > minX; i--)
            {
                var currentCoordinate = new Coordinates(i, coordinate.YCoordinate);
                if (!IsCoordinateValid(currentCoordinate))
                    return ShipPlaceStatus.NoSpace;

                if (IsShipOverlapping(currentCoordinate))
                    return ShipPlaceStatus.Overlap;

                newShip.OceanPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToOcean(newShip);
            return ShipPlaceStatus.Ok;
        }

        private ShipPlaceStatus PlaceShipDown(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int manX = coordinate.XCoordinate + newShip.OceanPositions.Length;

            for (int i = coordinate.XCoordinate; i < manX; i++)
            {
                var currentCoordinate = new Coordinates(i, coordinate.YCoordinate);
                if (!IsCoordinateValid(currentCoordinate))
                    return ShipPlaceStatus.NoSpace;

                if (IsShipOverlapping(currentCoordinate))
                    return ShipPlaceStatus.Overlap;

                newShip.OceanPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToOcean(newShip);
            return ShipPlaceStatus.Ok;
        }

        private bool IsCoordinateValid(Coordinates coordinate)
        {
            return coordinate.XCoordinate >= 1 && coordinate.XCoordinate <= Ocean.XSize &&
            coordinate.YCoordinate >= 1 && coordinate.YCoordinate <= Ocean.YSize;
        }
        public bool IsShipOverlapping(Coordinates coordinates)
        {
            foreach (var ship in ShipList)
            {
                if (ship != null)
                {
                    if (ship.OceanPositions.Contains(coordinates))
                        return true;
                }
            }
            return false;
        }

        private void AddShipToOcean(Ship newShip)
        {
                ShipList[ShipIndex] = newShip;
                ShipIndex++;
        }
    }
}