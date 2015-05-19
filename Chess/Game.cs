using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Game
    {
        public List<PieceTracker> PieceList{ get; set; }
        public Player CurrentPlayer { get; set; }

        public Game()
        {
            this.PieceList = new List<PieceTracker>();
            this.addPiecesToGameList();
            this.CurrentPlayer = Player.Black;
        }

        private void addPiecesToGameList()
        {
            #region whitePieces

            for (int i = 0; i <= 7; i++)
            {
                this.PieceList.Add(new PieceTracker()
                {
                    Piece = new WhitePawn() { Name = "White Pawn", ImageString = @"PieceImages/P1Pawn.png" },
                    Coordinate = new Coordinate() { xCoordinate = i, yCoordinate = 1 },
                    Player = Player.White
                });
            }

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "White Rook", ImageString = @"PieceImages/P1Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 0, yCoordinate = 0 },
                Player = Player.White
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "White Bishop", ImageString = @"PieceImages/P1Bishop.png" },
                Coordinate = new Coordinate() { xCoordinate = 1, yCoordinate = 0 },
                Player = Player.White
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "White Knight", ImageString = @"PieceImages/P1Knight.png" },
                Coordinate = new Coordinate() { xCoordinate = 2, yCoordinate = 0 },
                Player = Player.White
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Queen() { Name = "White Queen", ImageString = @"PieceImages/P1Queen.png" },
                Coordinate = new Coordinate() { xCoordinate = 3, yCoordinate = 0 },
                Player = Player.White
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new King() { Name = "White King", ImageString = @"PieceImages/P1King.png" },
                Coordinate = new Coordinate() { xCoordinate = 4, yCoordinate = 0 },
                Player = Player.White
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "White Knight", ImageString = @"PieceImages/P1Knight.png" },
                Coordinate = new Coordinate() { xCoordinate = 5, yCoordinate = 0 },
                Player = Player.White
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "White Bishop", ImageString = @"PieceImages/P1Bishop.png" },
                Coordinate = new Coordinate() { xCoordinate = 6, yCoordinate = 0 },
                Player = Player.White
            });


            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "White Rook", ImageString = @"PieceImages/P1Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 7, yCoordinate = 0 },
                Player = Player.White
            });

            #endregion

            #region blackPieces

            for (int i = 0; i <= 7; i++)
            {
                this.PieceList.Add(new PieceTracker()
                {
                    Piece = new BlackPawn() { Name = "Black Pawn", ImageString = @"PieceImages/P2Pawn.png" },
                    Coordinate = new Coordinate() { xCoordinate = i, yCoordinate = 6 },
                    Player = Player.Black
                });
            }

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "Black Rook", ImageString = @"PieceImages/P2Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 0, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "Black Bishop", ImageString = @"PieceImages/P2Bishop.png" },
                Coordinate = new Coordinate() { xCoordinate = 1, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "Black Knight", ImageString = @"PieceImages/P2Knight.png" },
                Coordinate = new Coordinate() { xCoordinate = 2, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Queen() { Name = "Black Queen", ImageString = @"PieceImages/P2Queen.png" },
                Coordinate = new Coordinate() { xCoordinate = 3, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new King() { Name = "Black King", ImageString = @"PieceImages/P2King.png" },
                Coordinate = new Coordinate() { xCoordinate = 4, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "Black Knight", ImageString = @"PieceImages/P2Knight.png" },
                Coordinate = new Coordinate() { xCoordinate = 5, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "Black Bishop", ImageString = @"PieceImages/P2Bishop.png" },
                Coordinate = new Coordinate() { xCoordinate = 6, yCoordinate = 7 },
                Player = Player.Black
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "Black Rook", ImageString = @"PieceImages/P2Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 7, yCoordinate = 7 },
                Player = Player.Black
            });

            #endregion

        }

        public void PlayGame()
        {
            if (this.CurrentPlayer == Player.White)
            {
                this.CurrentPlayer = Player.Black;
            }

            else
            {
                this.CurrentPlayer = Player.White;
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
