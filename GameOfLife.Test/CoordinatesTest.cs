using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Test
{
    [TestClass]
    public class CoordinatesTest
    {
        [TestMethod]
        public void Initialize_CheckValues()
        {
            Coordinates coordinates = new Coordinates(1, 4);
            coordinates.Y.ShouldBe(4);
            coordinates.X.ShouldBe(1);
        }

        [TestMethod]
        public void Equals_Check()
        {
            Coordinates coordinates1 = new Coordinates(1, 4);
            Coordinates coordinates2 = new Coordinates(1, 4);

            coordinates1.Equals(coordinates2).ShouldBeTrue();
        }

        [TestMethod]
        public void GetNeighbours_Check()
        {
            Coordinates coordinates = new Coordinates(1, 1);

            Coordinates topLeft = new Coordinates(0, 2);
            Coordinates top = new Coordinates(1, 2);
            Coordinates topRight = new Coordinates(2, 2);

            Coordinates left = new Coordinates(0, 1);
            Coordinates right = new Coordinates(2, 1);

            Coordinates bottomLeft = new Coordinates(0, 0);
            Coordinates bottom = new Coordinates(1, 0);
            Coordinates bottomRight = new Coordinates(2, 0);

            coordinates.GetNeighbours().Contains(topLeft).ShouldBeTrue();
            coordinates.GetNeighbours().Contains(top).ShouldBeTrue();
            coordinates.GetNeighbours().Contains(topRight).ShouldBeTrue();

            coordinates.GetNeighbours().Contains(left).ShouldBeTrue();
            coordinates.GetNeighbours().Contains(right).ShouldBeTrue();

            coordinates.GetNeighbours().Contains(bottomLeft).ShouldBeTrue();
            coordinates.GetNeighbours().Contains(bottomLeft).ShouldBeTrue();
            coordinates.GetNeighbours().Contains(bottomLeft).ShouldBeTrue();
        }
    }
}
