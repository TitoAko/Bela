using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bela
{
    public partial class Rezultat : Form
    {
        /// <summary>
        /// Create simple window with total and current score board. Does not keep track of scores,
        /// to keep track of total scores, create some other method somewhere else.
        /// </summary>
        /// <param name="Results">Results: contains 4 numbers, 0 = our team score,
        /// 1 = our oponents team score, 2 = our current team score,
        /// 3 = our oponents current team score</param>
        public Rezultat(List<int> Results)
        {
            InitializeComponent();
            lblOurScoreNumber.Text = Results[0].ToString();
            lblOponentScoreNumber.Text = Results[1].ToString();
            if (txtOurScore.Text == null || txtOurScore.Text == "")
            {
                // TODO: Fill with current score for my team, and check total score
            }
            else
            {
                // TODO: Game in progress, calculate current score for my team and display it on screen
            }

            if (txtOponentScore.Text == null || txtOponentScore.Text == "")
            {
                // TODO: Fill with current score for my team, and check total score
            }
            else
            {
                // TODO: Game in progress, calculate current score for my team and display it on screen
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CumulateScores"></param>
        /// <returns></returns>
        private int TotalScore(List<int> CumulateScores)
        {
            int pointsAmount = 0;
            foreach (int score in CumulateScores)
            {
                pointsAmount += score;
            }
            return pointsAmount;
        }
    }
}
