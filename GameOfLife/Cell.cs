using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Cell
    {
        public Cell() => Alive();

        private CellStatuses Status { get; set; }

        public void Dead() => Status = CellStatuses.Dead;
        public void Alive() => Status = CellStatuses.Alive;

        public bool IsAlive() => Status == CellStatuses.Alive;

        internal bool IsDead() => IsAlive() == false;
    }
}
