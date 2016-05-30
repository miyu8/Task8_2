using System.Linq;
using Life.Models;
using Life.Living;
using Life.Initialization;
using System.Text;
using System;
using Life.Living.Grass;
using Life.Living.Grass.Life;

namespace Life.BaseData
{
    public class RecordBase
    {
        public void AddList(Cell[,] gameField, int TypeGame, int Iter)
        {
            using (var db = new DataModelContainer())
            {
                var game = new Game() { Type = TypeGame, SizeX = gameField.Length / gameField.GetLength(0), SizeY = gameField.GetLength(0), Iteration = Iter };
                db.GameSet.Add(game);
                Coords coord;
                for (int i = 0; i < gameField.Length / gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < gameField.GetLength(0); j++)
                    {
                        if (gameField[i, j] != null)
                        {
                            coord = new Coords() { CoordX = gameField[i, j].CoordX, CoordY = gameField[i, j].CoordY, TypeLiving = (int)gameField[i, j].livingName, Game = game };
                            db.CoordsSet.Add(coord);
                        }

                    }
                }
                db.SaveChanges();
            }
        }

        public void RemoveList(int id)
        {
            using (var db = new DataModelContainer())
            {
                foreach (var item in db.CoordsSet.Where(x => x.Game.Id == id))
                {
                    db.CoordsSet.Remove(item);
                }
                Game game = db.GameSet.Where(x => x.Id == id).FirstOrDefault();
                if (game != null)
                    db.GameSet.Remove(game);
                db.SaveChanges();
            }
        }

        public Cell[,] TakeList(int id, int[] ValueCells, Options options)
        {
            using (var db = new DataModelContainer())
            {
                Game game = db.GameSet.Where(x => x.Id == id).FirstOrDefault();

                Cell[,] gameField = new Cell[game.SizeX, game.SizeY];
                if (game != null)
                {
                    ValueCells[0] = game.Type;
                    foreach (var item in db.CoordsSet.Where(x => x.Game.Id == id))
                    {
                        switch (item.TypeLiving)
                        {
                            case 1:
                                gameField[item.CoordX, item.CoordY] = new Cell(new Grass(item.CoordX, item.CoordY, item.Game.SizeX, item.Game.SizeY),
                                    LivingName.Grass, item.CoordX, item.CoordY);
                                ValueCells[(int)gameField[item.CoordX, item.CoordY].livingName]++;
                                break;
                            case 2:
                                gameField[item.CoordX, item.CoordY] = new Cell(new Grass1(item.CoordX, item.CoordY, item.Game.SizeX, item.Game.SizeY,
                                    options.grass1Property), LivingName.Grass1, item.CoordX, item.CoordY);
                                ValueCells[(int)gameField[item.CoordX, item.CoordY].livingName]++;
                                break;
                            case 3:
                                gameField[item.CoordX, item.CoordY] = new Cell(new Grass2(item.CoordX, item.CoordY, item.Game.SizeX, item.Game.SizeY,
                                    options.grass2Property), LivingName.Grass2, item.CoordX, item.CoordY);
                                ValueCells[(int)gameField[item.CoordX, item.CoordY].livingName]++;
                                break;
                            case 4:
                                gameField[item.CoordX, item.CoordY] = new Cell(new Herbivorous1(item.CoordX, item.CoordY, item.Game.SizeX, item.Game.SizeY,
                                    options.herbivorous1Property, options.grass2Property), LivingName.Herbivorous1, item.CoordX, item.CoordY);
                                ValueCells[(int)gameField[item.CoordX, item.CoordY].livingName]++;
                                break;
                        }
                    }
                }
                return gameField;
            }
        }

        public string ErrorBase(Exception ex)
        {
            var sb = new StringBuilder(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                sb.AppendLine(" <=").Append(ex.Message);
            }
            return sb.ToString();
        }
    }
}
