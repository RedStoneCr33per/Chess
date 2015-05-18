using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class Piece
    {
        public string Name { get; set; }
        public string ImageString { get; set; }

        public virtual bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            bool checkMove = false;
            return checkMove;

        }
    }
}
