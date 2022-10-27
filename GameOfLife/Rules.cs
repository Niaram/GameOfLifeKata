using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal static class Rules
    {
        public static Rule Rule1 = new Rule((neighbours, currentCell) => neighbours.Count(c => c.IsAlive()) < 2 && currentCell.IsAlive());

        public static Rule Rule2 = new Rule((neighbours, currentCell) => neighbours.Count(c => c.IsAlive()) > 3 && currentCell.IsAlive());

        public static Rule Rule3 = new Rule((neighbours, currentCell) =>
        {
            if (currentCell.IsAlive() == false)
                return false;

            int aliveNeighboursCount = neighbours.Count(c => c.IsAlive());
            return aliveNeighboursCount == 2 || aliveNeighboursCount == 3;
        });

        public static Rule Rule4 = new Rule((neighbours, currentCell) => neighbours.Count(c => c.IsAlive()) == 3 && currentCell.IsDead());
    }

    internal class Rule
    {
        public Rule(Func<List<Cell>, Cell, bool> howToVerify)
        {
            HowToVerify = howToVerify;
        }

        private Func<List<Cell>, Cell, bool> HowToVerify { get; set; }

        public bool Verify(List<Cell> neighbours, Cell currentCell)
            => HowToVerify(neighbours, currentCell);
    }
}
