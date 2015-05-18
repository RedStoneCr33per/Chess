using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        public override bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            bool checkMove = false;

            if ((newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 1 && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 2)
                || (newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 2 && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 2 && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 1)
                || (newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 1 && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 2)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 2 && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 1 && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 2)
                || (newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 2 && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 1 && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 2))
            {
                checkMove = true;
            }

            return checkMove;
        }
    }
}
