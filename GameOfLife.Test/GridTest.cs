using Shouldly;

namespace GameOfLife.Test
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void InitializeGrid_CheckDimensions()
        {
            const int width = 10;
            const int height = 20;

            Grid grid = new Grid(width, height);
            grid.Width.ShouldBe(width);
            grid.Height.ShouldBe(height);
        }

        [TestMethod]
        public void InitializeGrid_CheckDefaultCellStatus()
        {
            Grid grid = new Grid(2, 2);
            grid.AliveCellCount.ShouldBe(grid.TotalCellCount);
        }

        [TestMethod]
        public void NextGeneration_CheckRule1()
        {
            /*  DDD 
                DAD
                DDD */

            Coordinates cellToCheck = new Coordinates(1, 1);

            Grid grid = new Grid(3, 3, aliveCellsCoordinates: cellToCheck);

            grid.NextGeneration();

            grid.IsCellAlive(cellToCheck).ShouldBeFalse();
        }

        [TestMethod]
        public void NextGeneration_CheckRule2()
        {
            /*  DDD 
                AAA
                A0A */

            Coordinates cellToCheck = new Coordinates(1, 1);

            Grid grid = new Grid(3,
                                 3,
                                 new Coordinates(0, 0),
                                 new Coordinates(0, 2),
                                 new Coordinates(1, 0),
                                 cellToCheck,
                                 new Coordinates(1, 2));

            grid.NextGeneration();

            grid.IsCellAlive(cellToCheck).ShouldBeFalse();
        }

        [TestMethod]
        public void NextGeneration_CheckRule3()
        {
            /*  DDD 
                AAD
                AAD */

            Coordinates cellToCheck = new Coordinates(1, 1);

            Grid grid = new Grid(3,
                                 3,
                                 new Coordinates(0, 0),
                                 new Coordinates(0, 1),
                                 new Coordinates(0, 0),
                                 cellToCheck);

            grid.NextGeneration();

            grid.IsCellAlive(cellToCheck).ShouldBeTrue();
        }

        [TestMethod]
        public void NextGeneration_CheckRule4_2AliveNeighbours()
        {
            /*  DDD 
                ADD
                DAD */

            Coordinates cellToCheck = new Coordinates(1, 1);

            Grid grid = new Grid(3,
                                 3,
                                 new Coordinates(1, 0),
                                 new Coordinates(0, 1),
                                 new Coordinates(1, 1));

            grid.NextGeneration();

            grid.IsCellAlive(cellToCheck).ShouldBeTrue();
        }

        [TestMethod]
        public void NextGeneration_CheckRule4_3AliveNeighbours()
        {
            /*  DDD 
                ADA
                DAD */

            Coordinates cellToCheck = new Coordinates(1, 1);

            Grid grid = new Grid(3,
                                 3,
                                 new Coordinates(1, 0),
                                 new Coordinates(0, 1),
                                 new Coordinates(1, 1),
                                 new Coordinates(1, 2));

            grid.NextGeneration();

            grid.IsCellAlive(cellToCheck).ShouldBeTrue();
        }
    }
}