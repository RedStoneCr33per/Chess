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

            //QUEEN = ROOK + BISHOP...
            checkMove = Rook.VerifyVerticalAndHorizontal(oldCoordinate, newCoordinate, checkMove);

            if (!checkMove)
            {
                checkMove = Bishop.VerifyDiagonals(oldCoordinate, newCoordinate, checkMove);
            }

            return checkMove;
        }
    }
}