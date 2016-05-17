using Life.Models;
using Life.Interface;
using Life.LivingProperty;
using System;

namespace Life.Living
{
    public class Herbivorous1 : ILiving
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public struct Point
        {
            public int X;
            public int Y;
        }
        int p, p2;
        Point[] point, point2;
        public Herbivorous1Property herbivorous1Property, herbivorous1Property2, herbivorous1Property3;
        public Grass2Property grass2Property;
        GenerateRandom generaterandom = new GenerateRandom();
        public Herbivorous1(int coordX, int coordY, int sizeX, int sizeY, Herbivorous1Property herbivorous1property, Grass2Property grass2property)
        {
            CoordX = coordX;
            CoordY = coordY;
            SizeX = sizeX;
            SizeY = sizeY;
            herbivorous1Property = herbivorous1property;
            grass2Property = grass2property;
        }
        public Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            herbivorous1Property2 = new Herbivorous1Property(((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyBaseBegin,
                ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyBase, ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyConsumption,
                ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.StartRot, ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.TimeRot,
                ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.Grass2Radius, ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyGrass,
                ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.Speed);
            herbivorous1Property2.EnergyBase -= herbivorous1Property2.EnergyConsumption;
            if (herbivorous1Property2.EnergyBase <= 0)
            {
                herbivorous1Property2.StartRot++;
                if (herbivorous1Property2.StartRot <= herbivorous1Property2.TimeRot)
                    gameFieldNext[CoordX, CoordY] = new Cell(new Herbivorous1(CoordX, CoordY, SizeX, SizeY, herbivorous1Property2, grass2Property), Cell.LivingName.Corpse, CoordX, CoordY);
                else
                    gameFieldNext = GrowGrass(gameField, gameFieldNext);
            }
            else
            {
                gameFieldNext = Move(gameField, gameFieldNext);
                if (herbivorous1Property2.EnergyBase >= herbivorous1Property2.EnergyBaseBegin + 2)
                {
                    gameFieldNext = Duplication(gameField, gameFieldNext);
                    herbivorous1Property2.EnergyBase = herbivorous1Property2.EnergyBaseBegin;
                    gameFieldNext[CoordX, CoordY] = new Cell(new Herbivorous1(CoordX, CoordY, SizeX, SizeY, herbivorous1Property2, grass2Property), Cell.LivingName.Herbivorous1, CoordX, CoordY);
                }

            }
            return gameFieldNext;
        }

        public Cell[,] Move(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            int speed = herbivorous1Property2.Speed;
            int max = Math.Max(SizeX, SizeY);
            do
            {
                p2 = p = 0;
                point = new Point[(2 * speed + 1) * (2 * speed + 1) - (2 * (speed - 1) + 1) * (2 * (speed - 1) + 1)];
                point2 = new Point[(2 * speed + 1) * (2 * speed + 1) - (2 * (speed - 1) + 1) * (2 * (speed - 1) + 1)];
                for (int i = CoordX - speed; i <= CoordX + speed; i++)
                {
                    Detour(i, CoordY - speed, gameField);
                    Detour(i, CoordY + speed, gameField);
                }
                for (int i = CoordY - speed + 1; i < CoordY + speed; i++)
                {
                    Detour(CoordX - speed, i, gameField);
                    Detour(CoordX + speed, i, gameField);
                }
                speed++;
            } while (p == 0 && speed <= max);
            speed--;
            int x, y;
            if (p != 0)
            {
                if (p != 1)
                    p = generaterandom.RandomString(p);
                else
                    p = 0;
                if (speed == herbivorous1Property2.Speed)
                {
                    herbivorous1Property2.EnergyBase += 3;
                    gameFieldNext[point[p].X, point[p].Y] = new Cell(new Herbivorous1(point[p].X, point[p].Y, SizeX, SizeY,
                        herbivorous1Property2, grass2Property), Cell.LivingName.Herbivorous1, point[p].X, point[p].Y);
                }
                else
                {
                    x = BigSpeed(point[p].X, CoordX, herbivorous1Property2.Speed);
                    y = BigSpeed(point[p].Y, CoordY, herbivorous1Property2.Speed);
                    gameFieldNext[x, y] = new Cell(new Herbivorous1(x, y, SizeX, SizeY,
                            herbivorous1Property2, grass2Property), Cell.LivingName.Herbivorous1, x, y);
                }
            }
            else if (p2 != 0)
            {
                p2 = generaterandom.RandomString(p2);
                gameFieldNext[point2[p2].X, point2[p2].Y] = new Cell(new Herbivorous1(point2[p2].X, point2[p2].Y, SizeX, SizeY,
                    herbivorous1Property2, grass2Property), Cell.LivingName.Herbivorous1, point2[p2].X, point2[p2].Y);
            }
            return gameFieldNext;
        }

        public Cell[,] GrowGrass(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            for (int x = CoordX - herbivorous1Property2.Grass2Radius; x <= CoordX + herbivorous1Property2.Grass2Radius; x++)
                for (int y = CoordY - herbivorous1Property2.Grass2Radius; y <= CoordY + herbivorous1Property2.Grass2Radius; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY)
                        continue;

                    if (gameField[x, y] == null)
                        gameFieldNext[CoordX, CoordY] = new Cell(new Grass2(CoordX, CoordY, SizeX, SizeY, grass2Property), Cell.LivingName.Grass2, CoordX, CoordY);
                }
            return gameFieldNext;
        }

        public Cell[,] Duplication(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            Point[] point = new Point[9];
            p = 0;
            for (int x = CoordX - 1; x <= CoordX + 1; x++)
                for (int y = CoordY - 1; y <= CoordY + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY
                       || (x == CoordX && y == CoordY))
                        continue;

                    if (gameField[x, y] == null)
                    {
                        point[p].X = x;
                        point[p].Y = y;
                        p++;
                    }
                }
            if (p != 0)
            {
                p = generaterandom.RandomString(p);
                herbivorous1Property3 = new Herbivorous1Property(((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyBaseBegin,
                    ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyBase, ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyConsumption,
                    ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.StartRot, ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.TimeRot,
                    ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.Grass2Radius, ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.EnergyGrass,
                    ((Herbivorous1)gameField[CoordX, CoordY].Living).herbivorous1Property.Speed);
                Modification(herbivorous1Property2.EnergyBaseBegin, herbivorous1Property3.EnergyBaseBegin);
                Modification(herbivorous1Property2.EnergyConsumption, herbivorous1Property3.EnergyConsumption);
                herbivorous1Property2.StartRot = herbivorous1Property3.StartRot;
                Modification(herbivorous1Property2.TimeRot, herbivorous1Property3.TimeRot);
                Modification(herbivorous1Property2.Grass2Radius, herbivorous1Property3.Grass2Radius);
                Modification(herbivorous1Property2.EnergyGrass, herbivorous1Property3.EnergyGrass);
                Modification(herbivorous1Property2.Speed, herbivorous1Property3.Speed);
                herbivorous1Property3.EnergyBase = herbivorous1Property2.EnergyBase - herbivorous1Property2.EnergyBaseBegin;
                gameFieldNext[point[p].X, point[p].Y] = new Cell(new Herbivorous1(point[p].X, point[p].Y, SizeX, SizeY,
                    herbivorous1Property3, grass2Property), Cell.LivingName.Herbivorous1, point[p].X, point[p].Y);
            }
            return gameFieldNext;
        }

        public void Modification(int Name, int Name2)
        {
            Name2 = Name;
            if (generaterandom.Mutation())
                if (Name2 > 1)
                    if (generaterandom.Coin())
                        Name2++;
                    else
                        Name2--;
                else
                    Name2++;
        }

        public void Detour(int x, int y, Cell[,] gameField)
        {
            if (!(x < 0 || y < 0 || x >= SizeX || y >= SizeY))
                if (gameField[x, y] == null)
                {
                    point2[p2].X = x;
                    point2[p2].Y = y;
                    p2++;
                }
                else if ((int)gameField[x, y].livingName == 3)
                {
                    point[p].X = x;
                    point[p].Y = y;
                    p++;
                }
        }
        public int Way(int CoordGrass, int CoordHerbivorous, int SpeedWay)
        {
            if (CoordGrass > CoordHerbivorous)
                return CoordHerbivorous + SpeedWay;
            else if (CoordGrass < CoordHerbivorous)
                return CoordHerbivorous - SpeedWay;
            else
                return CoordHerbivorous;
        }

        public int BigSpeed(int CoordGrass, int CoordHerbivorous, int SpeedWay)
        {
            int speed2 = Math.Abs(CoordGrass - CoordHerbivorous);
            if (SpeedWay > speed2)
            {

                return Way(point[p].X, CoordX, speed2);
            }
            else
                return Way(point[p].X, CoordX, herbivorous1Property2.Speed);
        }
    }
}

