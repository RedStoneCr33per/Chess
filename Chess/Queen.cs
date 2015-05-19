using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece
    {
        public override bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            bool checkMove = false;

            if (oldCoordinate.xCoordinate == newCoordinate.xCoordinate || oldCoordinate.yCoordinate == newCoordinate.yCoordinate
                || newCoordinate.xCoordinate - oldCoordinate.xCoordinate == newCoordinate.yCoordinate - oldCoordinate.yCoordinate
                || oldCoordinate.xCoordinate - newCoordinate.xCoordinate == oldCoordinate.yCoordinate - newCoordinate.yCoordinate
                || oldCoordinate.xCoordinate - newCoordinate.xCoordinate == newCoordinate.yCoordinate - oldCoordinate.yCoordinate)
            {
                checkMove = true;
            }

            return checkMove;
        }
    }
}
