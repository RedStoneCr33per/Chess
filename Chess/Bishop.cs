using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Piece
    {
        public override bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            bool checkMove = false;

            checkMove = VerifyDiagonals(oldCoordinate, newCoordinate, checkMove);

            return checkMove;
        }

        public static bool VerifyDiagonals(Coordinate oldCoordinate, Coordinate newCoordinate, bool checkMove)
        {
            List<Coordinate> pieceRoute = new List<Coordinate>();

            //UP & LEFT AND UP & RIGHT
            if (newCoordinate.XCoordinate - oldCoordinate.XCoordinate == newCoordinate.YCoordinate - oldCoordinate.YCoordinate)
            {
                //+VE X & +VE Y => RIGHT AND UP
                if (newCoordinate.XCoordinate > oldCoordinate.XCoordinate && newCoordinate.YCoordinate > oldCoordinate.YCoordinate)
                {
                    int newY = oldCoordinate.YCoordinate + 1;
                    int newX = oldCoordinate.XCoordinate + 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = newX, YCoordinate = newY });
                        if (newY == newCoordinate.YCoordinate)
                        {
                            break;
                        }
                        newY++;
                        newX++;
                    }
                }

                //-VE X & -VE Y +> DOWN  AND LEFT
                else if (newCoordinate.XCoordinate < oldCoordinate.XCoordinate && newCoordinate.YCoordinate < oldCoordinate.YCoordinate)
                {
                    int newY = oldCoordinate.YCoordinate - 1;
                    int newX = oldCoordinate.XCoordinate - 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = newX, YCoordinate = newY });
                        if (newY == newCoordinate.YCoordinate)
                        {
                            break;
                        }
                        newY--;
                        newX--;
                    }
                }
            }

            //DOWN & RIGHT AND UP & LEFT
            else if (oldCoordinate.XCoordinate - newCoordinate.XCoordinate == newCoordinate.YCoordinate - oldCoordinate.YCoordinate)
            {
                //newx > oldx & oldy > newy
                //+VE X & -VE Y DOWN AND RIGHT
                if (newCoordinate.XCoordinate > oldCoordinate.XCoordinate && oldCoordinate.YCoordinate > newCoordinate.YCoordinate)
                {
                    int newY = oldCoordinate.YCoordinate - 1;
                    int newX = oldCoordinate.XCoordinate + 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = newX, YCoordinate = newY });
                        if (newY == newCoordinate.YCoordinate)
                        {
                            break;
                        }
                        newY--;
                        newX++;
                    }
                }
                //-VE X & +VE Y LEFT AND UP
                else
                {
                    int newY = oldCoordinate.YCoordinate + 1;
                    int newX = oldCoordinate.XCoordinate - 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = newX, YCoordinate = newY });
                        if (newY == newCoordinate.YCoordinate)
                        {
                            break;
                        }
                        newY++;
                        newX--;
                    }
                }
            }

            foreach (Coordinate coordinate in pieceRoute)
            {
                List<PieceTracker> pieceListAtCoordinate = (from piece in GameBoard.game.PieceList
                                                            where piece.Coordinate.XCoordinate.Equals(coordinate.XCoordinate)
                                                            & piece.Coordinate.YCoordinate.Equals(coordinate.YCoordinate)
                                                            select piece).ToList();

                if (pieceListAtCoordinate.Count == 0)
                {
                    checkMove = true;
                }

                else if (pieceListAtCoordinate.Count != 0)
                {
                    if (newCoordinate.XCoordinate == coordinate.XCoordinate && newCoordinate.YCoordinate == coordinate.YCoordinate)
                    {
                        checkMove = true;
                    }

                    else
                    {
                        checkMove = false;
                        break;
                    }
                }

            }
            return checkMove;
        }
    }
}