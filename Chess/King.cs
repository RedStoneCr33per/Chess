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

            if ((newCoordinate.XCoordinate - oldCoordinate.XCoordinate == 1 && newCoordinate.YCoordinate - oldCoordinate.YCoordinate == 1)
                || (oldCoordinate.XCoordinate - newCoordinate.XCoordinate == 1 && oldCoordinate.YCoordinate - newCoordinate.YCoordinate == 1)
                || (newCoordinate.XCoordinate - oldCoordinate.XCoordinate == 1 && oldCoordinate.YCoordinate - newCoordinate.YCoordinate == 1)
                || (oldCoordinate.XCoordinate - newCoordinate.XCoordinate == 1 && newCoordinate.YCoordinate - oldCoordinate.YCoordinate == 1)
                || (newCoordinate.XCoordinate - oldCoordinate.XCoordinate == 1 && newCoordinate.YCoordinate == oldCoordinate.YCoordinate)
                || (oldCoordinate.XCoordinate == newCoordinate.XCoordinate && oldCoordinate.YCoordinate - newCoordinate.YCoordinate == 1)
                || (oldCoordinate.XCoordinate - newCoordinate.XCoordinate == 1 && oldCoordinate.YCoordinate == newCoordinate.YCoordinate)
                || (oldCoordinate.XCoordinate == newCoordinate.XCoordinate && oldCoordinate.YCoordinate - newCoordinate.YCoordinate == 1)
                || (oldCoordinate.XCoordinate == newCoordinate.XCoordinate && newCoordinate.YCoordinate - oldCoordinate.YCoordinate == 1))
            {
                checkMove = true;
            }


            return checkMove;
        }
    }
}
