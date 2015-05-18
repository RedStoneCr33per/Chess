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

        public Game()
        {
            this.PieceList = new List<PieceTracker>();
        }

        private void addPiecesToGameList()
        {
            for (int i = 0; i <= 7; i++)
            {
                this.PieceList.Add(new PieceTracker()
                {
                    Piece = new Player1Pawn() { Name = "P1 Pawn", ImageString = "P1Pawn.png" },
                    Coordinate = new Coordinate() { xCoordinate = i, yCoordinate = 1 }
                });
            }

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "P1 Rook", ImageString = "P1Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 0, yCoordinate = 0 }
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "P1 Bishop", ImageString = "P1Bishop.png" },
                Coordinate = new Coordinate() { xCoordinate = 1, yCoordinate = 0 }
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "P1 Knight", ImageString = "P1Knight.png" },
                Coordinate = new Coordinate() { xCoordinate = 5, yCoordinate = 0 }
            });


            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Knight() { Name = "P1 Knight", ImageString = "P1Knight.png" },
                Coordinate = new Coordinate() { xCoordinate = 2, yCoordinate = 0 }
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Bishop() { Name = "P1 Bishop", ImageString = "P1Bishop.png" },
                Coordinate = new Coordinate() { xCoordinate = 6, yCoordinate = 0 }
            });


            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "P1 Rook", ImageString = "P1Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 7, yCoordinate = 0 }
            });
        }

        public void PlayGame()
        {
            this.addPiecesToGameList();
 
        }
    }
}
