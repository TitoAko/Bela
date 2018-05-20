using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Bela
{
    public partial class Igra : Form
    {
        private PictureBox[] pbLeftOponent = new PictureBox[8];
        private PictureBox[] pbRightOponent = new PictureBox[8];
        private PictureBox[] pbMyTeammate = new PictureBox[8];
        private PictureBox[] pbMyCards = new PictureBox[8];

        private Decks deMyDeck, deRightDeck, deMyTeammateDeck, deLeftDeck;

        private bool bIsMouseDown = false;

        private int iOldX, iOldY, iClickX, iClickY;

        /**************************************************/
        private void pbMyCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && GameInProgress > MyConstants.GameStatus.GameStartNoSuit)
            {
                PictureBox tmpPic = (PictureBox)sender;
                Point p = ConvertFromChildToForm(e.X, e.Y, tmpPic);
                iOldX = p.X;
                iOldY = p.Y;
                iClickX = e.X;
                iClickY = e.Y;
                bIsMouseDown = true;
            }
        }

        private void pbMyCard_MouseMove(object sender, MouseEventArgs e)
        {
            if (bIsMouseDown && GameInProgress > MyConstants.GameStatus.GameStartNoSuit)
            {
                PictureBox tmpPic = (PictureBox)sender;
                Point p = new Point(); // New Coordinate
                p.X = e.X + tmpPic.Left;
                p.Y = e.Y + tmpPic.Top;
                tmpPic.Left = p.X - iClickX;
                tmpPic.Top = p.Y - iClickY;
            }
        }

        private Point ConvertFromChildToForm(int x, int y, Control control)
        {
            Point p = new Point(x, y);
            control.Location = p;
            return p;
        }
        /**************************************************/

        /// <summary>
        /// Check for start of the game.
        /// 0 = game is initialized
        /// 1 = game has started, no suite is selected
        /// 2 = game has started, club is selected, me called
        /// 3 = game has started, club is selected, right called
        /// 4 = game has started, club is selected, my partner called
        /// 5 = game has started, club is selected, left called
        /// 6 = game has started, diamond is selected, me called
        /// 7 = game has started, diamond is selected, right called
        /// 8 = game has started, diamond is selected, my partner called
        /// 9 = game has started, diamond is selected, left called
        /// 10 = game has started, hearts is selected, me called
        /// 11 = game has started, hearts is selected, right called
        /// 12 = game has started, hearts is selected, my partner called
        /// 13 = game has started, hearts is selected, left called
        /// 14 = game has started, spades is selected, me called
        /// 15 = game has started, spades is selected, right called
        /// 16 = game has started, spades is selected, my partner called
        /// 17 = game has started, spades is selected, left called
        /// </summary>
        private MyConstants.GameStatus GameInProgress
        {
            get
            {
                return sGameInProgress;
            }
            set
            {
                sGameInProgress = value;
                if (sGameInProgress > MyConstants.GameStatus.GameStartNoSuit)
                {
                    bIsMouseDown = false;
                }
            }
        }
        private MyConstants.GameStatus sGameInProgress;
        private Decks objNewGame;

        public Igra()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myCtrlInitialization();
            GameInProgress = MyConstants.GameStatus.GameInitialized;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < MyConstants.NumberOfCardsInHand; i++)
            {
                if (pbLeftOponent[i] != null && pbRightOponent[i] != null && pbMyTeammate[i] != null && pbMyCards[i] != null)
                {
                    pbLeftOponent[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(Size.Width) / 32) - (Convert.ToDouble(Size.Width) / 10)),
                         Convert.ToInt32((Convert.ToDouble(Size.Height) / 8) + (i * Convert.ToInt32(Size.Height / 17))));
                    pbLeftOponent[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(Size.Width) / 5.7),
                        Convert.ToInt32(Convert.ToDouble(Size.Height) / 6.0));
                    pbLeftOponent[i].Show();
                    pbRightOponent[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(Size.Width) * 0.71875) + Convert.ToDouble(Size.Width) / 6),
                        Convert.ToInt32((Convert.ToDouble(Size.Height) / 8) + (i * Convert.ToInt32(Size.Height / 17))));
                    pbRightOponent[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(Size.Width) / 5.7),
                        Convert.ToInt32(Convert.ToDouble(Size.Height) / 6.0));
                    pbRightOponent[i].Show();
                    pbMyTeammate[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(Size.Width) / 4.733) + ((Convert.ToDouble(Size.Width) / 16) * Convert.ToDouble(i))),
                        Convert.ToInt32(Convert.ToDouble(Size.Height) * 0.01));
                    pbMyTeammate[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(Size.Width) / 8),
                        Convert.ToInt32(Convert.ToDouble(Size.Height) / 4.4));
                    pbMyTeammate[i].Show();
                    pbMyCards[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(Size.Width) / 4.733) + ((Convert.ToDouble(Size.Width) / 13) * Convert.ToDouble(7 - i))),
                        Convert.ToInt32(Convert.ToDouble(Size.Height) * 0.8));
                    pbMyCards[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(Size.Width) / 8),
                        Convert.ToInt32(Convert.ToDouble(Size.Height) / 4.4));
                    pbMyCards[i].Show();
                }
            }
        }

        private void ChangeContentOnWindowResize()
        {
            for (int i = 0; i < MyConstants.NumberOfCardsInHand; i++)
            {
                if (pbLeftOponent[i] != null && pbRightOponent[i] != null && pbMyTeammate[i] != null && pbMyCards[i] != null)
                {
                    pbLeftOponent[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) / 32) - (Convert.ToDouble(this.Size.Width) / 10)),
                         Convert.ToInt32((Convert.ToDouble(this.Size.Height) / 8) + (i * Convert.ToInt32(this.Size.Height / 17))));
                    pbLeftOponent[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 5.7),
                        Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 6.0));
                    pbLeftOponent[i].Show();
                    pbRightOponent[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) * 0.71875) + Convert.ToDouble(this.Size.Width) / 6),
                        Convert.ToInt32((Convert.ToDouble(this.Size.Height) / 8) + (i * Convert.ToInt32(this.Size.Height / 17))));
                    pbRightOponent[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 5.7),
                        Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 6.0));
                    pbRightOponent[i].Show();
                    pbMyTeammate[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) / 4.733) + ((Convert.ToDouble(this.Size.Width) / 16) * Convert.ToDouble(i))),
                        Convert.ToInt32(Convert.ToDouble(this.Size.Height) * 0.01));
                    pbMyTeammate[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 8),
                        Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 4.4));
                    pbMyTeammate[i].Show();
                    pbMyCards[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) / 4.733) + ((Convert.ToDouble(this.Size.Width) / 13) * Convert.ToDouble(7 - i))),
                        Convert.ToInt32(Convert.ToDouble(this.Size.Height) * 0.8));
                    pbMyCards[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 8),
                        Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 4.4));
                    pbMyCards[i].Show();
                }
            }

        }

        #region Methods for closing the game
        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    this.Close();
        }
        #endregion
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            myStartNewGame();
        }

        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewGame_Click(sender, e);
        }
        #region PictureBox clicked, player plays card

        private void pbMyCards_Click(object sender, EventArgs e)
        {
            switch (GameInProgress)
            {
                case MyConstants.GameStatus.GameInitialized:
                    // new game starts
                    btnNewGame.PerformClick();
                    break;
                case MyConstants.GameStatus.GameStartNoSuit:
                    // player selected lead suite
                    string selectedCard = ((PictureBox)sender).Image.Tag.ToString();
                    if (selectedCard.Contains("club"))
                    {
                        MessageBox.Show("Žir je adut!");
                        GameInProgress = MyConstants.GameStatus.GameStartedClubMe;
                        lblWhoCalledAndSuit.Text = "Ja sam zvao žira";
                    }
                    else if (selectedCard.Contains("diamond"))
                    {
                        MessageBox.Show("Bundeva je adut!");
                        GameInProgress = MyConstants.GameStatus.GameStartedDiamondMe;
                        lblWhoCalledAndSuit.Text = "Ja sam zvao bundevu";
                    }
                    else if (selectedCard.Contains("hearts"))
                    {
                        MessageBox.Show("Srce je adut!");
                        GameInProgress = MyConstants.GameStatus.GameStartedHeartsMe;
                        lblWhoCalledAndSuit.Text = "Ja sam zvao srce";
                    }
                    else if (selectedCard.Contains("spades"))
                    {
                        MessageBox.Show("List je adut!");
                        GameInProgress = MyConstants.GameStatus.GameStartedSpadesMe;
                        lblWhoCalledAndSuit.Text = "Ja sam zvao list";
                    }
                    //objNewGame.pl_Me.DidICall = true;
                    //objNewGame.pl_LeftOponent.DidICall = false;
                    //objNewGame.pl_MyTeammate.DidICall = false;
                    //objNewGame.pl_RightOponent.DidICall = false;
                    // show talon
                    break;
                case MyConstants.GameStatus.GameStartedClubMe: // move cards to the center of the playfield accordingly
                    break;
                case MyConstants.GameStatus.GameStartedClubRight:
                    break;
                case MyConstants.GameStatus.GameStartedClubMyPartner:
                    break;
                case MyConstants.GameStatus.GameStartedClubLeft:
                    break;
                case MyConstants.GameStatus.GameStartedDiamondMe:
                    break;
                case MyConstants.GameStatus.GameStartedDiamondRight:
                    break;
                case MyConstants.GameStatus.GameStartedDiamondMyPartner:
                    break;
                case MyConstants.GameStatus.GameStartedDiamondLeft:
                    break;
                case MyConstants.GameStatus.GameStartedHeartsMe:
                    break;
                case MyConstants.GameStatus.GameStartedHeartsRight:
                    break;
                case MyConstants.GameStatus.GameStartedHeartsMyPartner:
                    break;
                case MyConstants.GameStatus.GameStartedHeartsLeft:
                    break;
                case MyConstants.GameStatus.GameStartedSpadesMe:
                    break;
                case MyConstants.GameStatus.GameStartedSpadesRight:
                    break;
                case MyConstants.GameStatus.GameStartedSpadesMyPartner:
                    break;
                case MyConstants.GameStatus.GameStartedSpadesLeft:
                    break;
            }
        }

        #endregion

        private void myCtrlInitialization()
        {
            objNewGame = new Decks();

            for (int i = 0; i < 8; i++)
            {
                pbLeftOponent[i] = new PictureBox();
                pbLeftOponent[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                pbLeftOponent[i].Anchor = System.Windows.Forms.AnchorStyles.Left;
                pbLeftOponent[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                pbLeftOponent[i].Cursor = System.Windows.Forms.Cursors.No;
                pbLeftOponent[i].Image = global::Bela.Properties.Resources.background;
                pbLeftOponent[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) / 32) - (Convert.ToDouble(this.Size.Width) / 10)),
                     Convert.ToInt32((Convert.ToDouble(this.Size.Height) / 8) + (i * Convert.ToInt32(this.Size.Height / 17))));
                pbLeftOponent[i].Name = "pbpbLeftOponent" + i.ToString();
                pbLeftOponent[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 5.7),
                    Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 6.0));
                pbLeftOponent[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pbLeftOponent[i].TabStop = false;
                pbLeftOponent[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.Controls.Add(pbLeftOponent[i]);

                pbRightOponent[i] = new PictureBox();
                pbRightOponent[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                pbRightOponent[i].Anchor = System.Windows.Forms.AnchorStyles.Left;
                pbRightOponent[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                pbRightOponent[i].Cursor = System.Windows.Forms.Cursors.No;
                pbRightOponent[i].Image = global::Bela.Properties.Resources.background;
                pbRightOponent[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) * 0.71875) + Convert.ToDouble(this.Size.Width) / 6),
                    Convert.ToInt32((Convert.ToDouble(this.Size.Height) / 8) + (i * Convert.ToInt32(this.Size.Height / 17))));
                pbRightOponent[i].Name = "pbRightOponent" + i.ToString();
                pbRightOponent[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 5.7),
                    Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 6.0));
                pbRightOponent[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pbRightOponent[i].TabStop = false;
                pbRightOponent[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                this.Controls.Add(pbRightOponent[i]);

                pbMyCards[i] = new PictureBox();
                pbMyCards[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                pbMyCards[i].Anchor = System.Windows.Forms.AnchorStyles.Left;
                pbMyCards[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                pbMyCards[i].Cursor = System.Windows.Forms.Cursors.Hand;
                pbMyCards[i].Image = global::Bela.Properties.Resources.background;
                pbMyCards[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) / 4.733) + ((Convert.ToDouble(this.Size.Width) / 13) * Convert.ToDouble(7 - i))),
                    Convert.ToInt32(Convert.ToDouble(this.Size.Height) * 0.8));
                pbMyCards[i].Name = "pbMyCards" + i.ToString();
                pbMyCards[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 8),
                    Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 4.4));
                pbMyCards[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pbMyCards[i].TabStop = false;

                pbMyCards[i].Click += new EventHandler(pbMyCards_Click);
                pbMyCards[i].MouseMove += new MouseEventHandler(pbMyCard_MouseMove);
                pbMyCards[i].MouseDown += new MouseEventHandler(pbMyCard_MouseDown);

                this.Controls.Add(pbMyCards[i]);

                pbMyTeammate[i] = new PictureBox();
                pbMyTeammate[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                pbMyTeammate[i].Anchor = System.Windows.Forms.AnchorStyles.Left;
                pbMyTeammate[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                pbMyTeammate[i].Cursor = System.Windows.Forms.Cursors.No;
                pbMyTeammate[i].Image = global::Bela.Properties.Resources.background;
                pbMyTeammate[i].Location = new System.Drawing.Point(Convert.ToInt32((Convert.ToDouble(this.Size.Width) / 4.733) + ((Convert.ToDouble(this.Size.Width) / 16) * Convert.ToDouble(i))),
                    Convert.ToInt32(Convert.ToDouble(this.Size.Height) * 0.01));
                pbMyTeammate[i].Name = "pbMyTeammate" + i.ToString();
                pbMyTeammate[i].Size = new System.Drawing.Size(Convert.ToInt32(Convert.ToDouble(this.Size.Width) / 8),
                    Convert.ToInt32(Convert.ToDouble(this.Size.Height) / 4.4));
                pbMyTeammate[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pbMyTeammate[i].TabStop = false;
                pbMyTeammate[i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                this.Controls.Add(pbMyTeammate[i]);
            }
            //cards dealt and covered

        }

        private void myStartNewGame()
        {
            List<int> tmpNewDeck = HelperClass.DealCards();

            ///Deal new cards to my deck
            //List<short> myDeck = objNewGame.DealCards();

            //GameInProgress = 1;
            //foreach (short card in myDeck)
            //{
            //    using (CardsIndividual tmpCard = new CardsIndividual(card))
            //    {
            //        pbMyCards[myDeck.IndexOf(card)].Image = tmpCard.CardImage;
            //        pbMyCards[myDeck.IndexOf(card)].Image.Tag = tmpCard.CardName;
            //    }
            //}
            // check who's turn is for play, check if npc will call suite if it's not players turn
        }
        #region selecting suite and point calls
        private void CallHearts_Click(object sender, EventArgs e)
        {
            GameInProgress = MyConstants.GameStatus.GameStartedHeartsMe;
        }

        private void CallDiamonds_Click(object sender, EventArgs e)
        {
            GameInProgress = MyConstants.GameStatus.GameStartedDiamondMe;
        }

        private void CallClubs_Click(object sender, EventArgs e)
        {
            GameInProgress = MyConstants.GameStatus.GameStartedClubMe;
        }

        private void CallSpades_Click(object sender, EventArgs e)
        {
            GameInProgress = MyConstants.GameStatus.GameStartedSpadesMe;
        }

        private void CallPass_Click(object sender, EventArgs e)
        {
            CheckNextCardDealt();
        }

        private void CheckNextCardDealt()
        {
            GameInProgress = MyConstants.GameStatus.GameStartedSpadesLeft;
        }

        private void PointsPassCalls_Click(object sender, EventArgs e)
        {

        }

        private void Points20Calls_Click(object sender, EventArgs e)
        {

        }

        private void Points50Calls_Click(object sender, EventArgs e)
        {

        }

        private void Points100Calls_Click(object sender, EventArgs e)
        {

        }

        private void Points150Calls_Click(object sender, EventArgs e)
        {

        }

        private void Points200Calls_Click(object sender, EventArgs e)
        {

        }

        private void PointsBelotCalls_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
