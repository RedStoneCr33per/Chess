using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Piece
    {
        public override bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)

        {
            bool checkMove = false;

            if ((newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 1 && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 1 && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 1)
                || (newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 1 && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 1 && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 1)
                || (newCoordinate.xCoordinate - oldCoordinate.xCoordinate == 1 && newCoordinate.yCoordinate == oldCoordinate.yCoordinate)
                || (oldCoordinate.xCoordinate == newCoordinate.xCoordinate && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate - newCoordinate.xCoordinate == 1 && oldCoordinate.yCoordinate == newCoordinate.yCoordinate)
                || (oldCoordinate.xCoordinate == newCoordinate.xCoordinate && oldCoordinate.yCoordinate - newCoordinate.yCoordinate == 1)
                || (oldCoordinate.xCoordinate == newCoordinate.xCoordinate && newCoordinate.yCoordinate - oldCoordinate.yCoordinate == 1))
            {
                checkMove = true;
            }


            return checkMove;
        }
    }
}
