using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Grid
    {
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            InitializeCells();
        }

        public Grid(int width, int height, params Coordinates[] aliveCellsCoordinates) : this(height, width)
        {
            ForeachCell((cell, coordinates) =>
            {
                if (aliveCellsCoordinates.Contains(coordinates))
                    cell.Alive();
                else
                    cell.Dead();
            });
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public int AliveCellCount
        {
            get
            {
                int aliveCount = 0;
                ForeachCell(todo: cell => aliveCount++,
                            where: x => x.IsAlive());
                return aliveCount;
            }
        }
        public int TotalCellCount => Width * Height;
        public bool IsCellAlive(Coordinates coordinates)
            => GetCell(coordinates).IsAlive();

        public void NextGeneration()
        {
            ForeachCell((cell, coordinates) =>
            {
                List<Cell> neighbours = GetNeighbours(coordinates);

                if (Rules.Rule1.Verify(neighbours, cell))
                    cell.Dead();

                if (Rules.Rule2.Verify(neighbours, cell))
                    cell.Dead();

                if (Rules.Rule3.Verify(neighbours, cell))
                    return;

                if (Rules.Rule4.Verify(neighbours, cell))
                    cell.Alive();
            });
        }

        public override string ToString()
        {
            string toString = string.Empty;

            int previousX = 0;

            ForeachCell((cell, coordinates) =>
            {
                if (previousX != coordinates.X)
                    toString = toString + "\r\n";

                if (cell.IsAlive())
                    toString = toString + "A";
                else
                    toString = toString + "D";

                previousX = coordinates.X;
            });

            return toString.ToString();
        }

        private Dictionary<Coordinates, Cell> grid = new Dictionary<Coordinates, Cell>();

        private void InitializeCells()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    grid.Add(new Coordinates(x, y), new Cell());
        }

        private void ForeachCell(Action<Cell, Coordinates> todo, Func<Cell, bool> where = null)
        {
            grid
                .Where(cc => where == null || where(cc.Value))
                .OrderBy(cc => cc.Key.X)
                .ThenBy(cc => cc.Key.Y)
                .ToList()
                .ForEach(cc => todo(cc.Value, cc.Key));
        }

        private void ForeachCell(Action<Cell> todo, Func<Cell, bool> where = null)
            => ForeachCell((cell, coordinates) => todo(cell), where);

        private Cell GetCell(Coordinates coordinates) => grid[coordinates];

        private List<Cell> GetNeighbours(Coordinates coordinates)
            => coordinates.GetNeighbours()
                                .Where(c => AreOutOfGrid(c) == false)
                                .Select(c => GetCell(c))
                                .ToList();

        private bool AreOutOfGrid(Coordinates coordinates)
        {
            if (coordinates.X >= Width || coordinates.X < 0)
                return true;

            if (coordinates.Y >= Height || coordinates.Y < 0)
                return true;

            return false;
        }
    }
}
