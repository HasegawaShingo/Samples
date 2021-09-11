
namespace SampleSortByScore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScoreDataGridview = new System.Windows.Forms.DataGridView();
            this.AcoreALabel = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.Label();
            this.ScoreBLabel = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.Label();
            this.ScoreCLabel = new System.Windows.Forms.Label();
            this.C = new System.Windows.Forms.Label();
            this.ScoreDLabel = new System.Windows.Forms.Label();
            this.D = new System.Windows.Forms.Label();
            this.ScoreELabel = new System.Windows.Forms.Label();
            this.E = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TopScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreDataGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreDataGridview
            // 
            this.ScoreDataGridview.AllowUserToAddRows = false;
            this.ScoreDataGridview.AllowUserToDeleteRows = false;
            this.ScoreDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoreDataGridview.Location = new System.Drawing.Point(12, 12);
            this.ScoreDataGridview.Name = "ScoreDataGridview";
            this.ScoreDataGridview.ReadOnly = true;
            this.ScoreDataGridview.RowTemplate.Height = 25;
            this.ScoreDataGridview.Size = new System.Drawing.Size(346, 333);
            this.ScoreDataGridview.TabIndex = 0;
            this.ScoreDataGridview.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScoreDataGridview_RowEnter);
            // 
            // AcoreALabel
            // 
            this.AcoreALabel.AutoSize = true;
            this.AcoreALabel.Location = new System.Drawing.Point(364, 12);
            this.AcoreALabel.Name = "AcoreALabel";
            this.AcoreALabel.Size = new System.Drawing.Size(49, 18);
            this.AcoreALabel.TabIndex = 1;
            this.AcoreALabel.Text = "ScoreA";
            // 
            // A
            // 
            this.A.AutoSize = true;
            this.A.Location = new System.Drawing.Point(419, 12);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(16, 18);
            this.A.TabIndex = 2;
            this.A.Text = "A";
            // 
            // ScoreBLabel
            // 
            this.ScoreBLabel.AutoSize = true;
            this.ScoreBLabel.Location = new System.Drawing.Point(364, 39);
            this.ScoreBLabel.Name = "ScoreBLabel";
            this.ScoreBLabel.Size = new System.Drawing.Size(49, 18);
            this.ScoreBLabel.TabIndex = 3;
            this.ScoreBLabel.Text = "ScoreB";
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.Location = new System.Drawing.Point(419, 39);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(16, 18);
            this.B.TabIndex = 4;
            this.B.Text = "B";
            // 
            // ScoreCLabel
            // 
            this.ScoreCLabel.AutoSize = true;
            this.ScoreCLabel.Location = new System.Drawing.Point(364, 66);
            this.ScoreCLabel.Name = "ScoreCLabel";
            this.ScoreCLabel.Size = new System.Drawing.Size(49, 18);
            this.ScoreCLabel.TabIndex = 5;
            this.ScoreCLabel.Text = "ScoreC";
            // 
            // C
            // 
            this.C.AutoSize = true;
            this.C.Location = new System.Drawing.Point(419, 66);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(16, 18);
            this.C.TabIndex = 6;
            this.C.Text = "C";
            // 
            // ScoreDLabel
            // 
            this.ScoreDLabel.AutoSize = true;
            this.ScoreDLabel.Location = new System.Drawing.Point(364, 96);
            this.ScoreDLabel.Name = "ScoreDLabel";
            this.ScoreDLabel.Size = new System.Drawing.Size(50, 18);
            this.ScoreDLabel.TabIndex = 7;
            this.ScoreDLabel.Text = "ScoreD";
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Location = new System.Drawing.Point(419, 96);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(17, 18);
            this.D.TabIndex = 8;
            this.D.Text = "D";
            // 
            // ScoreELabel
            // 
            this.ScoreELabel.AutoSize = true;
            this.ScoreELabel.Location = new System.Drawing.Point(364, 125);
            this.ScoreELabel.Name = "ScoreELabel";
            this.ScoreELabel.Size = new System.Drawing.Size(48, 18);
            this.ScoreELabel.TabIndex = 9;
            this.ScoreELabel.Text = "ScoreE";
            // 
            // E
            // 
            this.E.AutoSize = true;
            this.E.Location = new System.Drawing.Point(419, 125);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(15, 18);
            this.E.TabIndex = 10;
            this.E.Text = "E";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "TopScore";
            // 
            // TopScoreLabel
            // 
            this.TopScoreLabel.AutoSize = true;
            this.TopScoreLabel.Location = new System.Drawing.Point(434, 179);
            this.TopScoreLabel.Name = "TopScoreLabel";
            this.TopScoreLabel.Size = new System.Drawing.Size(62, 18);
            this.TopScoreLabel.TabIndex = 12;
            this.TopScoreLabel.Text = "TopScore";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 357);
            this.Controls.Add(this.TopScoreLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.E);
            this.Controls.Add(this.ScoreELabel);
            this.Controls.Add(this.D);
            this.Controls.Add(this.ScoreDLabel);
            this.Controls.Add(this.C);
            this.Controls.Add(this.ScoreCLabel);
            this.Controls.Add(this.B);
            this.Controls.Add(this.ScoreBLabel);
            this.Controls.Add(this.A);
            this.Controls.Add(this.AcoreALabel);
            this.Controls.Add(this.ScoreDataGridview);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreDataGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ScoreDataGridview;
        private System.Windows.Forms.Label AcoreALabel;
        private System.Windows.Forms.Label A;
        private System.Windows.Forms.Label ScoreBLabel;
        private System.Windows.Forms.Label B;
        private System.Windows.Forms.Label ScoreCLabel;
        private System.Windows.Forms.Label C;
        private System.Windows.Forms.Label ScoreDLabel;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.Label ScoreELabel;
        private System.Windows.Forms.Label E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TopScoreLabel;
    }
}

