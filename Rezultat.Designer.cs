namespace Bela
{
    partial class Rezultat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblOurScore = new System.Windows.Forms.Label();
            this.lblOponentScore = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblOurScoreNumber = new System.Windows.Forms.Label();
            this.lblOponentScoreNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOurScore = new System.Windows.Forms.TextBox();
            this.txtOponentScore = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(2, 106);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtOurScore);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtOponentScore);
            this.splitContainer1.Size = new System.Drawing.Size(523, 414);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblOurScore
            // 
            this.lblOurScore.AutoSize = true;
            this.lblOurScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOurScore.Location = new System.Drawing.Point(13, 69);
            this.lblOurScore.Name = "lblOurScore";
            this.lblOurScore.Size = new System.Drawing.Size(120, 25);
            this.lblOurScore.TabIndex = 1;
            this.lblOurScore.Text = "Naši bodovi:";
            // 
            // lblOponentScore
            // 
            this.lblOponentScore.AutoSize = true;
            this.lblOponentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOponentScore.Location = new System.Drawing.Point(260, 69);
            this.lblOponentScore.Name = "lblOponentScore";
            this.lblOponentScore.Size = new System.Drawing.Size(169, 25);
            this.lblOponentScore.TabIndex = 2;
            this.lblOponentScore.Text = "Protivnički bodovi:";
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalScore.Location = new System.Drawing.Point(12, 9);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(204, 31);
            this.lblTotalScore.TabIndex = 3;
            this.lblTotalScore.Text = "Ukupni rezultat:";
            // 
            // lblOurScoreNumber
            // 
            this.lblOurScoreNumber.AutoSize = true;
            this.lblOurScoreNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOurScoreNumber.Location = new System.Drawing.Point(213, 9);
            this.lblOurScoreNumber.Name = "lblOurScoreNumber";
            this.lblOurScoreNumber.Size = new System.Drawing.Size(29, 31);
            this.lblOurScoreNumber.TabIndex = 4;
            this.lblOurScoreNumber.Text = "0";
            // 
            // lblOponentScoreNumber
            // 
            this.lblOponentScoreNumber.AutoSize = true;
            this.lblOponentScoreNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOponentScoreNumber.Location = new System.Drawing.Point(348, 9);
            this.lblOponentScoreNumber.Name = "lblOponentScoreNumber";
            this.lblOponentScoreNumber.Size = new System.Drawing.Size(29, 31);
            this.lblOponentScoreNumber.TabIndex = 5;
            this.lblOponentScoreNumber.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(320, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = ":";
            // 
            // txtOurScore
            // 
            this.txtOurScore.Location = new System.Drawing.Point(4, 4);
            this.txtOurScore.Multiline = true;
            this.txtOurScore.Name = "txtOurScore";
            this.txtOurScore.Size = new System.Drawing.Size(249, 398);
            this.txtOurScore.TabIndex = 0;
            // 
            // txtOponentScore
            // 
            this.txtOponentScore.Location = new System.Drawing.Point(3, 3);
            this.txtOponentScore.Multiline = true;
            this.txtOponentScore.Name = "txtOponentScore";
            this.txtOponentScore.Size = new System.Drawing.Size(249, 398);
            this.txtOponentScore.TabIndex = 2;
            // 
            // Rezultat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 520);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOponentScoreNumber);
            this.Controls.Add(this.lblOurScoreNumber);
            this.Controls.Add(this.lblTotalScore);
            this.Controls.Add(this.lblOponentScore);
            this.Controls.Add(this.lblOurScore);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Rezultat";
            this.ShowIcon = false;
            this.Text = "Rezultat";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtOurScore;
        private System.Windows.Forms.TextBox txtOponentScore;
        private System.Windows.Forms.Label lblOurScore;
        private System.Windows.Forms.Label lblOponentScore;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblOurScoreNumber;
        private System.Windows.Forms.Label lblOponentScoreNumber;
        private System.Windows.Forms.Label label3;
    }
}