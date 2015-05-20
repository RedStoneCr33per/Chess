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

            List<Coordinate> pieceRoute = new List<Coordinate>();

            if (oldCoordinate.XCoordinate == newCoordinate.XCoordinate)
            {
                if (newCoordinate.YCoordinate > oldCoordinate.YCoordinate)
                {
                    int newY = oldCoordinate.YCoordinate + 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = oldCoordinate.XCoordinate, YCoordinate = newY });
                        if (newY == newCoordinate.YCoordinate)
                        {
                            break;
                        }
                        newY++;

                    }
                }

                else if (oldCoordinate.YCoordinate > newCoordinate.YCoordinate)
                {
                    int newY = oldCoordinate.YCoordinate - 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = oldCoordinate.XCoordinate, YCoordinate = newY });
                        if (newY == newCoordinate.YCoordinate)
                        {
                            break;
                        }
                        newY--;

                    }
                }
            }

            else if (oldCoordinate.YCoordinate == newCoordinate.YCoordinate)
            {
                if (newCoordinate.XCoordinate > oldCoordinate.XCoordinate)
                {
                    int newX = oldCoordinate.XCoordinate + 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = newX, YCoordinate = oldCoordinate.YCoordinate });
                        if (newX == newCoordinate.XCoordinate)
                        {
                            break;
                        }
                        newX++;
                    }
                }

                else if (oldCoordinate.XCoordinate > newCoordinate.XCoordinate)
                {
                    int newX = oldCoordinate.XCoordinate - 1;

                    while (true)
                    {
                        pieceRoute.Add(new Coordinate() { XCoordinate = newX, YCoordinate = oldCoordinate.YCoordinate });
                        if (newX == newCoordinate.XCoordinate)
                        {
                            break;
                        }
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
