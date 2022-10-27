using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    //should be a ValueObject, no base class created
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public List<Coordinates> GetNeighbours() => new List<Coordinates>{
            new Coordinates(X - 1, Y - 1),
            new Coordinates(X - 1, Y),
            new Coordinates(X - 1, Y + 1),
            new Coordinates(X, Y - 1),
            new Coordinates(X, Y + 1),
            new Coordinates(X + 1, Y - 1),
            new Coordinates(X + 1, Y),
            new Coordinates(X + 1, Y + 1)
        };

        public override bool Equals(object? obj)
        {
            return obj is Coordinates coordinates &&
                   X == coordinates.X &&
                   Y == coordinates.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
