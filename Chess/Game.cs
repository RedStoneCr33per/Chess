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
            this.PieceList.Add(new PieceTracker() 
            { 
                Piece = new Pawn() { Name = "P1 Pawn", ImageString = "P1Pawn.png" },
                Coordinate = new Coordinate() 
                { xCoordinate = 1, yCoordinate = 1 }
            });

            this.PieceList.Add(new PieceTracker()
            {
                Piece = new Rook() { Name = "P1 Rook", ImageString = "P1Rook.png" },
                Coordinate = new Coordinate() { xCoordinate = 0, yCoordinate = 0 }
            });
        }

        public void PlayGame()
        {
            this.addPiecesToGameList();
 
        }
    }
}
