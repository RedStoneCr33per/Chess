using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        public override bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            bool checkMove = false;

            if (oldCoordinate.xCoordinate == newCoordinate.xCoordinate || oldCoordinate.yCoordinate == newCoordinate.yCoordinate)
            {
                checkMove = true;
            }

            return checkMove;
        }
    }
}
