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
    public partial class GameBoard : Form
    {
        static bool clicked;
        static Coordinate oldCoordinate;
        static Coordinate newCoordinate;
        static string output = "";
        public static Game game;
        static PictureBox pictureBox1;
        static Color pictureBox1Color;
        static PictureBox pictureBox2;
        static Color pictureBox2Color;
        static Player currentPlayer;

        public GameBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            clicked = false;
            oldCoordinate = new Coordinate();
            newCoordinate = new Coordinate();
            game = new Game();
            game.PlayGame();
            currentPlayer = game.CurrentPlayer;
            gameLabel.Text = game.CurrentPlayer.ToString() + " player's" + " turn...";

            #region whitePieces

            zeroOne.ImageLocation = @"PieceImages/P1Pawn.png";
            oneOne.ImageLocation = @"PieceImages/P1Pawn.png";
            twoOne.ImageLocation = @"PieceImages/P1Pawn.png";
            threeOne.ImageLocation = @"PieceImages/P1Pawn.png";
            fourOne.ImageLocation = @"PieceImages/P1Pawn.png";
            fiveOne.ImageLocation = @"PieceImages/P1Pawn.png";
            sixOne.ImageLocation = @"PieceImages/P1Pawn.png";
            sevenOne.ImageLocation = @"PieceImages/P1Pawn.png";
            zeroZero.ImageLocation = @"PieceImages/P1Rook.png";
            oneZero.ImageLocation = @"PieceImages/P1Bishop.png";
            twoZero.ImageLocation = @"PieceImages/P1Knight.png";
            threeZero.ImageLocation = @"PieceImages/P1Queen.png";
            fourZero.ImageLocation = @"PieceImages/P1King.png";
            fiveZero.ImageLocation = @"PieceImages/P1Knight.png";
            sixZero.ImageLocation = @"PieceImages/P1Bishop.png";
            sevenZero.ImageLocation = @"PieceImages/P1Rook.png";

            #endregion

            #region blackPieces

            zeroSix.ImageLocation = @"PieceImages/P2Pawn.png";
            oneSix.ImageLocation = @"PieceImages/P2Pawn.png";
            twoSix.ImageLocation = @"PieceImages/P2Pawn.png";
            threeSix.ImageLocation = @"PieceImages/P2Pawn.png";
            fourSix.ImageLocation = @"PieceImages/P2Pawn.png";
            fiveSix.ImageLocation = @"PieceImages/P2Pawn.png";
            sixSix.ImageLocation = @"PieceImages/P2Pawn.png";
            sevenSix.ImageLocation = @"PieceImages/P2Pawn.png";
            zeroSeven.ImageLocation = @"PieceImages/P2Rook.png";
            oneSeven.ImageLocation = @"PieceImages/P2Bishop.png";
            twoSeven.ImageLocation = @"PieceImages/P2Knight.png";
            threeSeven.ImageLocation = @"PieceImages/P2Queen.png";
            fourSeven.ImageLocation = @"PieceImages/P2King.png";
            fiveSeven.ImageLocation = @"PieceImages/P2Knight.png";
            sixSeven.ImageLocation = @"PieceImages/P2Bishop.png";
            sevenSeven.ImageLocation = @"PieceImages/P2Rook.png";

            #endregion
        }

        private void handleClicks(int x, int y, PictureBox pb)
        {
            output = "";

            List<PieceTracker> pieceListAtOldCoordinate = (from piece in game.PieceList
                                                           where piece.Coordinate.XCoordinate.Equals(oldCoordinate.XCoordinate)
                                                           & piece.Coordinate.YCoordinate.Equals(oldCoordinate.YCoordinate)
                                                           select piece).ToList();

            if (!clicked)
            {
                gameLabel.Text = "";
                oldCoordinate.XCoordinate = x;
                oldCoordinate.YCoordinate = y;
                clicked = true;
                gameLabel.Text = "Click another square...";
                pictureBox1 = pb;
                pictureBox1Color = pb.BackColor;
                pb.BackColor = Color.Red;
                return;
            }

            else
            {
                newCoordinate.XCoordinate = x;
                newCoordinate.YCoordinate = y;
                clicked = false;

                if (oldCoordinate.XCoordinate == newCoordinate.XCoordinate && oldCoordinate.YCoordinate == newCoordinate.YCoordinate)
                {
                    output = "Squares must be different...";
                    pictureBox1.BackColor = pictureBox1Color;
                    pictureBox1 = new PictureBox();
                    pictureBox2 = new PictureBox();
                }

                else
                {
                    pictureBox2 = pb;
                    pictureBox2Color = pb.BackColor;
                    pb.BackColor = Color.Red;


                    List<PieceTracker> pieceListAtNewCoordinate = (from piece in game.PieceList
                                                                   where piece.Coordinate.XCoordinate.Equals(newCoordinate.XCoordinate)
                                                                   & piece.Coordinate.YCoordinate.Equals(newCoordinate.YCoordinate)
                                                                   select piece).ToList();

                    if (pieceListAtNewCoordinate.Count == 1 && pieceListAtNewCoordinate[0].Player == currentPlayer)
                    {
                        output = "Square contains one of your pieces...";
                        pictureBox1.BackColor = pictureBox1Color;
                        pictureBox2.BackColor = pictureBox2Color;
                        pictureBox1 = new PictureBox();
                        pictureBox2 = new PictureBox();
                    }


                    else if (pieceListAtOldCoordinate.Count == 1 && pieceListAtOldCoordinate[0].Player == currentPlayer)
                    {
                        if (pieceListAtOldCoordinate[0].Piece.Move(oldCoordinate, newCoordinate))
                        {
                            if (pieceListAtNewCoordinate.Count == 1 && pieceListAtNewCoordinate[0].Player != currentPlayer)
                            {
                                //TAKE PIECE!
                                output = output = pieceListAtOldCoordinate[0].Piece.Name.ToString()
                                    + " takes a " + pieceListAtNewCoordinate[0].Piece.Name.ToString() + "!";
                                int pieceToBeRemoved = game.PieceList.FindIndex(piece =>
                                piece.Coordinate.XCoordinate == newCoordinate.XCoordinate && piece.Coordinate.YCoordinate == newCoordinate.YCoordinate);
                                game.PieceList.RemoveAt(pieceToBeRemoved);
                                game.PieceList.Count();
                            }

                            int pieceIndex = game.PieceList.FindIndex(piece =>
                                piece.Coordinate.XCoordinate == oldCoordinate.XCoordinate && piece.Coordinate.YCoordinate == oldCoordinate.YCoordinate);

                            game.PieceList[pieceIndex].Coordinate = new Coordinate()
                            {
                                XCoordinate = newCoordinate.XCoordinate,
                                YCoordinate = newCoordinate.YCoordinate
                            };

                            pictureBox1.ImageLocation = "";
                            pictureBox2.ImageLocation = pieceListAtOldCoordinate[0].Piece.ImageString;
                            game.PlayGame();
                            currentPlayer = game.CurrentPlayer;

                            if (output.Contains("takes a"))
                            {
                                output += " " + game.CurrentPlayer.ToString() + " player's" + " turn...";
                            }

                            else
                            {
                                output = game.CurrentPlayer.ToString() + " player's" + " turn...";
                            }

                            pictureBox1.BackColor = pictureBox1Color;
                            pictureBox2.BackColor = pictureBox2Color;

                        }

                        else
                        {
                            output = "Illegal move...";
                            pictureBox1.BackColor = pictureBox1Color;
                            pictureBox2.BackColor = pictureBox2Color;
                            pictureBox1 = new PictureBox();
                            pictureBox2 = new PictureBox();
                        }
                    }

                    else
                    {
                        output = game.CurrentPlayer.ToString() + " player's" + " turn...";
                        pictureBox1.BackColor = pictureBox1Color;
                        pictureBox2.BackColor = pictureBox2Color;
                        pictureBox1 = new PictureBox();
                        pictureBox2 = new PictureBox();
                    }

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
