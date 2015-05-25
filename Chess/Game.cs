using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Game
    {
        private List<PieceTracker> pieceList = new List<PieceTracker>();
        private Player currentPlayer;
        private bool check = false;
        private Player playerInCheck = Player.Default;
        private bool checkmate = false;

        public List<PieceTracker> PieceList
        {
            get
            {
                return pieceList;
            }
            set
            {
                pieceList = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
            set
            {
                currentPlayer = value;
            }
        }

        public bool Check
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
            }
        }

        public Player PlayerInCheck
        {
            get
            {
                return playerInCheck;
            }
            set
            {
                playerInCheck = value;
            }
        }

        public bool Checkmate
        {
            get
            {
                return checkmate;
            }
            set
            {
                checkmate = value;
            }
        }

        public Game()
        {
            this.addPiecesToGameList();
            this.currentPlayer = Player.Black;
            this.check = false;
        }

        private void addPiecesToGameList()
        {
            #region whitePieces

            for (int i = 0; i <= 7; i++)
            {
                this.pieceList.Add(new PieceTracker()
                {
                    Piece = new Pawn() { Name = "White Pawn", ImageString = @"PieceImages/P1Pawn.png" },
                    Coordinate = new Coordinate() { XCoordinate = i, YCoordinate = 1 },
                    Player = Player.White
                });
            }

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "White Rook", ImageString = @"PieceImages/P1Rook.png" },
                Coordinate = new Coordinate() { XCoordinate = 0, YCoordinate = 0 },
                Player = Player.White
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "White Bishop", ImageString = @"PieceImages/P1Bishop.png" },
                Coordinate = new Coordinate() { XCoordinate = 1, YCoordinate = 0 },
                Player = Player.White
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "White Knight", ImageString = @"PieceImages/P1Knight.png" },
                Coordinate = new Coordinate() { XCoordinate = 2, YCoordinate = 0 },
                Player = Player.White
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Queen() { Name = "White Queen", ImageString = @"PieceImages/P1Queen.png" },
                Coordinate = new Coordinate() { XCoordinate = 3, YCoordinate = 0 },
                Player = Player.White
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new King() { Name = "White King", ImageString = @"PieceImages/P1King.png" },
                Coordinate = new Coordinate() { XCoordinate = 4, YCoordinate = 0 },
                Player = Player.White
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "White Knight", ImageString = @"PieceImages/P1Knight.png" },
                Coordinate = new Coordinate() { XCoordinate = 5, YCoordinate = 0 },
                Player = Player.White
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "White Bishop", ImageString = @"PieceImages/P1Bishop.png" },
                Coordinate = new Coordinate() { XCoordinate = 6, YCoordinate = 0 },
                Player = Player.White
            });


            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "White Rook", ImageString = @"PieceImages/P1Rook.png" },
                Coordinate = new Coordinate() { XCoordinate = 7, YCoordinate = 0 },
                Player = Player.White
            });

            #endregion

            #region blackPieces

            for (int i = 0; i <= 7; i++)
            {
                this.pieceList.Add(new PieceTracker()
                {
                    Piece = new Pawn() { Name = "Black Pawn", ImageString = @"PieceImages/P2Pawn.png" },
                    Coordinate = new Coordinate() { XCoordinate = i, YCoordinate = 6 },
                    Player = Player.Black
                });
            }

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "Black Rook", ImageString = @"PieceImages/P2Rook.png" },
                Coordinate = new Coordinate() { XCoordinate = 0, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "Black Bishop", ImageString = @"PieceImages/P2Bishop.png" },
                Coordinate = new Coordinate() { XCoordinate = 1, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "Black Knight", ImageString = @"PieceImages/P2Knight.png" },
                Coordinate = new Coordinate() { XCoordinate = 2, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Queen() { Name = "Black Queen", ImageString = @"PieceImages/P2Queen.png" },
                Coordinate = new Coordinate() { XCoordinate = 3, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new King() { Name = "Black King", ImageString = @"PieceImages/P2King.png" },
                Coordinate = new Coordinate() { XCoordinate = 4, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "Black Knight", ImageString = @"PieceImages/P2Knight.png" },
                Coordinate = new Coordinate() { XCoordinate = 5, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "Black Bishop", ImageString = @"PieceImages/P2Bishop.png" },
                Coordinate = new Coordinate() { XCoordinate = 6, YCoordinate = 7 },
                Player = Player.Black
            });

            this.pieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "Black Rook", ImageString = @"PieceImages/P2Rook.png" },
                Coordinate = new Coordinate() { XCoordinate = 7, YCoordinate = 7 },
                Player = Player.Black
            });

            #endregion

        }

        public void PlayGame()
        {
            if (this.currentPlayer == Player.White)
            {
                this.currentPlayer = Player.Black;
            }

            else
            {
                this.currentPlayer = Player.White;
            }

        }

        public void CheckCheckOnThisKingWithOppositePlayerPieces()
        {
            List<PieceTracker> kingPiece = (from piece in this.PieceList
                                            where piece.Piece.Name.Contains("King")
                                            & piece.Player.Equals(this.currentPlayer)
                                            select piece).ToList();

            List<PieceTracker> oppositePlayerPieces = (from piece in this.PieceList
                                                       where !piece.Player.Equals(this.currentPlayer)
                                                       && !piece.Piece.Name.Contains("Pawn")
                                                       select piece).ToList();

            foreach (PieceTracker piecetracker in oppositePlayerPieces)
            {
                if (piecetracker.Piece.Move(piecetracker.Coordinate, kingPiece[0].Coordinate))
                {
                    //THIS PIECE CAN ATTACK THE KING
                    this.check = true;
                    break;
                }

                else
                {
                    this.check = false;
                }
            }
        }

        public void CheckCheckMate()
        {
            //CHECK SITUATION CURRENTLY HARD CODED FOR TESTING!
            if (!this.check)
            {
                return;
            }

            else
            {
                List<CheckmateState> checkmateStateList = new List<CheckmateState>();

                List<PieceTracker> playerPieces = (from piece in this.PieceList
                                                   where piece.Player.Equals(this.currentPlayer)
                                                   && !piece.Piece.Name.Contains("Pawn")
                                                   select piece).ToList();

                List<Coordinate> fullBoard = new List<Coordinate>();

                for (int j = 0; j < 8; j++)
                {


                    for (int i = 0; i < 8; i++)
                    {
                        fullBoard.Add(new Coordinate() { XCoordinate = i, YCoordinate = j });
                    }

                }


                foreach (PieceTracker piecetracker in playerPieces)
                {
                    foreach (Coordinate coordinate in fullBoard)
                    {
                        //CHECK IF EACH PIECE IS ABLE TO MOVE TO ANY PIECE ON THE BOARD
                        //IF MOVE IS NOT VALID - CONTINUE
                        if (!piecetracker.Piece.Move(piecetracker.Coordinate, coordinate))
                        {
                            continue;
                        }

                        //IF MOVE IS VALID, SIMULATE THE MOVE TO THE NEW COORDINATE AND CHECK CHECK
                        else
                        {
                            //GET LIST INDEX OF THE CURRENT PIECE FROM THE GAME MASTER PIECE LIST
                            int pieceIndex = this.PieceList.FindIndex(piece =>
                               piece.Coordinate.XCoordinate == piecetracker.Coordinate.XCoordinate
                               && piece.Coordinate.YCoordinate == piecetracker.Coordinate.YCoordinate);

                            //SIMULATE THE MOVE - THE MOVE IS ALREADY KNOWN TO BE A VALID MOVE AT THIS POINT
                            Coordinate oldCoordinate = piecetracker.Coordinate;
                            this.PieceList[pieceIndex].Coordinate = coordinate;

                            //CHECK CHECK OF THE KING WITH THE PIECE ON THE NEW SQUARE
                            CheckCheckOnThisKingWithOppositePlayerPieces();

                            if (!this.Check)
                            {
                                //THERE IS A MOVE AVAILABLE TO THE PLAYER, SO THE GAME IS DEFINITELY NOT IN CHECKMATE
                                //this.PieceList[pieceIndex].Coordinate = oldCoordinate;
                                checkmateStateList.Add(CheckmateState.MoveAvailable);
                                //REVERSE THE SIMULATED MOVE
                                this.PieceList[pieceIndex].Coordinate = oldCoordinate;
                                break;



                            }

                            else
                            {
                                checkmateStateList.Add(CheckmateState.NoMoveAvailable);
                                //REVERSE THE SIMULATED MOVE
                                this.PieceList[pieceIndex].Coordinate = oldCoordinate;
                            }

                            //REVERSE THE SIMULATED MOVE
                            //this.PieceList[pieceIndex].Coordinate = oldCoordinate;

 
                        }
                    }
                }


                //OUTSIDE OF ALL THE FOREACH LOOPS - THE PROGRAM SHOULD BREAK AND COME TO THIS POINT
                //NEXT IF THERE ARE MOVES AVAILABLE TO currentPlayer

                List<CheckmateState> checkIfMovesAvailable = (from cs in checkmateStateList
                                                              where cs.Equals(CheckmateState.MoveAvailable)
                                                              select cs).ToList();

                if (checkIfMovesAvailable.Count >= 1)
                {
                    //GAME IS NOT IN CHECKMATE
                    return;
                }

                else
                {
                    //NO MOVES AVAILABLE - GAME IS IN CHECKMATE!
                    this.checkmate = true;
                }

            }
        }

    }

    public enum Player
    {
        Default,
        White,
        Black
    }

    enum CheckmateState
    {
        MoveAvailable,
        NoMoveAvailable
    }
}
