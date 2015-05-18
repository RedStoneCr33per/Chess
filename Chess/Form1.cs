using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        static bool clicked;
        static Coordinate oldCoordinate;
        static Coordinate newCoordinate;
        static string output;
        static Game game;
        static PictureBox pictureBox1;
        static PictureBox pictureBox2;


        public Form1()
        {
            InitializeComponent();
            clicked = false;
            oldCoordinate = new Coordinate();
            newCoordinate = new Coordinate();
            game = new Game();
            game.PlayGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zeroOne.ImageLocation = "P1Pawn.png";
            oneOne.ImageLocation = "P1Pawn.png";
            twoOne.ImageLocation = "P1Pawn.png";
            threeOne.ImageLocation = "P1Pawn.png";
            fourOne.ImageLocation = "P1Pawn.png";
            fiveOne.ImageLocation = "P1Pawn.png";
            sixOne.ImageLocation = "P1Pawn.png";
            sevenOne.ImageLocation = "P1Pawn.png";
            zeroZero.ImageLocation = "P1Rook.png";
            oneZero.ImageLocation = "P1Bishop.png";
            twoZero.ImageLocation = "P1Knight.png";
            fiveZero.ImageLocation = "P1Knight.png";
            sixZero.ImageLocation = "P1Bishop.png";
            sevenZero.ImageLocation = "P1Rook.png";
        }

        private void handleClicks(int x, int y, PictureBox pb)
        {
            if (!clicked)
            {
                gameLabel.Text = "";
                oldCoordinate.xCoordinate = x;
                oldCoordinate.yCoordinate = y;
                clicked = true;
                gameLabel.Text = "Click another square...";
                output = "Coordinate 1: (" + oldCoordinate.xCoordinate + "," + oldCoordinate.yCoordinate + ")";
                pictureBox1 = pb;
            }

            else
            {
                newCoordinate.xCoordinate = x;
                newCoordinate.yCoordinate = y;
                clicked = false;

                if (oldCoordinate.xCoordinate == newCoordinate.xCoordinate && oldCoordinate.yCoordinate == newCoordinate.yCoordinate)
                {
                    output = "Squares must be different...";
                    pictureBox1 = new PictureBox();
                    pictureBox2 = new PictureBox();
                }

                else
                {
                    output += "\r\nCoordinate 2: (" + newCoordinate.xCoordinate + "," + newCoordinate.yCoordinate + ")";
                    pictureBox2 = pb;
                    List<PieceTracker> pieceList = (from piece in game.PieceList
                                                    where piece.Coordinate.xCoordinate.Equals(oldCoordinate.xCoordinate)
                                                    & piece.Coordinate.yCoordinate.Equals(oldCoordinate.yCoordinate)
                                                    select piece).ToList();
                    if (pieceList.Count == 1)
                    {
                        //pieceList[0].Piece.Move();

                        if (pieceList[0].Piece.Move( oldCoordinate, newCoordinate))
                        {

                            int pieceIndex = game.PieceList.FindIndex(piece =>
                                piece.Coordinate.xCoordinate == oldCoordinate.xCoordinate && piece.Coordinate.yCoordinate == oldCoordinate.yCoordinate);

                            game.PieceList[pieceIndex].Coordinate = new Coordinate()
                            {
                                xCoordinate = newCoordinate.xCoordinate,
                                yCoordinate = newCoordinate.yCoordinate
                            };

                            pictureBox1.ImageLocation = "";
                            pictureBox2.ImageLocation = pieceList[0].Piece.ImageString;

                        }

                        else
                        {
                            output = "Illegal move...";
                            pictureBox1 = new PictureBox();
                            pictureBox2 = new PictureBox();

                        }

                        ////int pieceIndex = game.PieceList.FindIndex(piece =>
                        ////    piece.Coordinate.xCoordinate == coordinate1.xCoordinate && piece.Coordinate.yCoordinate == coordinate1.yCoordinate);
                        
                        ////game.PieceList[pieceIndex].Coordinate = new Coordinate()
                        ////{
                        ////    xCoordinate = coordinate2.xCoordinate,
                        ////    yCoordinate = coordinate2.yCoordinate
                        ////};
                        
                        ////pictureBox1.ImageLocation = "";
                        ////pictureBox2.ImageLocation = "P1Pawn.png";
                    }

                    else
                    {
                        output = "Illegal move...";
                        pictureBox1 = new PictureBox();
                        pictureBox2 = new PictureBox();

                    }

                    //pictureBox1.ImageLocation = "";
                    //pictureBox2.ImageLocation = "P1Pawn.png";
                }

                gameLabel.Text = output;

            }
        }

        #region pictureBoxesOnClickEvents(64)

        private void zeroZero_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            handleClicks(x, y, zeroZero);
        }

        private void sixSeven_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 7;

            handleClicks(x, y, sixSeven);
        }

        private void fiveSeven_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 7;

            handleClicks(x, y, fiveSeven);
        }

        private void fourSeven_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 7;

            handleClicks(x, y, fourSeven);
        }

        private void sevenSix_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 6;

            handleClicks(x, y, sevenSix);
        }

        private void sixSix_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 6;

            handleClicks(x, y, sixSix);
        }

        private void fiveSix_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 6;

            handleClicks(x, y, fiveSix);
        }

        private void fourSix_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 6;

            handleClicks(x, y, fourSix);
        }

        private void sevenFive_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 5;

            handleClicks(x, y, sevenFive);
        }

        private void sixFive_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 5;

            handleClicks(x, y, sixFive);
        }

        private void fiveFive_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 5;

            handleClicks(x, y, fiveFive);
        }

        private void fourFive_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 5;

            handleClicks(x, y, fourFive);
        }

        private void sevenFour_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 4;

            handleClicks(x, y, sevenFour);
        }

        private void sixFour_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 4;

            handleClicks(x, y, sixFour);
        }

        private void fiveFour_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 4;

            handleClicks(x, y, fiveFour);
        }

        private void fourFour_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 4;

            handleClicks(x, y, fourFour);
        }

        private void threeSeven_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 7;

            handleClicks(x, y, threeSeven);
        }

        private void threeSix_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 6;

            handleClicks(x, y, threeSix);
        }

        private void threeFive_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 5;

            handleClicks(x, y, threeFive);
        }

        private void threeFour_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 4;

            handleClicks(x, y, threeFour);
        }

        private void twoSeven_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 7;

            handleClicks(x, y, twoSeven);
        }

        private void oneSeven_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 7;

            handleClicks(x, y, oneSeven);
        }

        private void zeroSeven_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 7;

            handleClicks(x, y, zeroSeven);
        }

        private void twoSix_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 6;

            handleClicks(x, y, twoSix);
        }

        private void oneSix_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 6;

            handleClicks(x, y, oneSix);
        }

        private void zeroSix_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 6;

            handleClicks(x, y, zeroSix);
        }

        private void twoFive_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 5;

            handleClicks(x, y, twoFive);
        }

        private void oneFive_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 5;

            handleClicks(x, y, oneFive);
        }

        private void zeroFive_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 5;

            handleClicks(x, y, zeroFive);
        }

        private void twoFour_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 4;

            handleClicks(x, y, twoFour);
        }

        private void oneFour_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 4;

            handleClicks(x, y, oneFour);
        }

        private void zeroFour_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 4;

            handleClicks(x, y, zeroFour);
        }

        private void sevenThree_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 3;

            handleClicks(x, y, sevenThree);
        }

        private void sixThree_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 3;

            handleClicks(x, y, sixThree);
        }

        private void fiveThree_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 3;

            handleClicks(x, y, fiveThree);
        }

        private void fourThree_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 3;

            handleClicks(x, y, fourThree);
        }

        private void sevenTwo_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 2;

            handleClicks(x, y, sevenTwo);
        }

        private void sixTwo_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 2;

            handleClicks(x, y, sixTwo);
        }

        private void fiveTwo_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 2;

            handleClicks(x, y, fiveTwo);
        }

        private void fourTwo_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 2;

            handleClicks(x, y, fourTwo);
        }

        private void sevenOne_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 1;

            handleClicks(x, y, sevenOne);
        }

        private void sixOne_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 1;

            handleClicks(x, y, sixOne);
        }

        private void fiveOne_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 1;

            handleClicks(x, y, fiveOne);
        }

        private void fourOne_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 1;

            handleClicks(x, y, fourOne);
        }

        private void sevenZero_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 0;

            handleClicks(x, y, sevenZero);
        }

        private void sixZero_Click(object sender, EventArgs e)
        {
            int x = 6;
            int y = 0;

            handleClicks(x, y, sixZero);

        }

        private void fiveZero_Click(object sender, EventArgs e)
        {
            int x = 5;
            int y = 0;

            handleClicks(x, y, fiveZero);
        }

        private void fourZero_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = 0;

            handleClicks(x, y, fourZero);

        }

        private void threeThree_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 3;

            handleClicks(x, y, threeThree);

        }

        private void threeTwo_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 2;

            handleClicks(x, y, threeTwo);
        }

        private void threeOne_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 1;

            handleClicks(x, y, threeOne);
        }

        private void threeZero_Click(object sender, EventArgs e)
        {
            int x = 3;
            int y = 0;

            handleClicks(x, y, threeZero);
        }

        private void twoThree_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 3;

            handleClicks(x, y, twoThree);
        }

        private void oneThree_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 3;

            handleClicks(x, y, oneThree);
        }

        private void zeroThree_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 3;

            handleClicks(x, y, zeroThree);
        }

        private void twoTwo_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 2;

            handleClicks(x, y, twoTwo);
        }

        private void oneTwo_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 2;

            handleClicks(x, y, oneTwo);

        }

        private void zeroTwo_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 2;

            handleClicks(x, y, zeroTwo);
        }

        private void twoOne_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 1;

            handleClicks(x, y, twoOne);
        }

        private void oneOne_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 1;

            handleClicks(x, y, oneOne);
        }

        private void zeroOne_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 1;

            handleClicks(x, y, zeroOne);
        }

        private void twoZero_Click(object sender, EventArgs e)
        {
            int x = 2;
            int y = 0;

            handleClicks(x, y, twoZero);
        }

        private void oneZero_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 0;

            handleClicks(x, y, oneZero);
        }

        private void sevenSeven_Click(object sender, EventArgs e)
        {
            int x = 7;
            int y = 7;

            handleClicks(x, y, sevenSeven);

        }

        #endregion

    }
}
