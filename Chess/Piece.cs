using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract public class Piece
    {
        private string name;
        private string imageString;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ImageString
        {
            get { return imageString; }
            set { imageString = value; }
        }
        
        public virtual bool Move(Coordinate oldCoordinate, Coordinate newCoordinate)
        {
            bool checkMove = false;
            return checkMove;
        }
    }
}
