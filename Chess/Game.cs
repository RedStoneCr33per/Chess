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

        public Game()
        {
            this.addPiecesToGameList();
            this.currentPlayer = Player.Black;
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
    }

    public enum Player
    {
        Default,
        White,
        Black
    }
}
