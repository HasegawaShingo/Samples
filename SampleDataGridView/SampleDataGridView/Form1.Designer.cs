
namespace SampleDataGridView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SourceList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.E = new System.Windows.Forms.Label();
            this.D = new System.Windows.Forms.Label();
            this.C = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BindButton = new System.Windows.Forms.Button();
            this.AverageScore = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.StatusViewChangeCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SourceList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceList
            // 
            this.SourceList.AllowUserToAddRows = false;
            this.SourceList.AllowUserToDeleteRows = false;
            this.SourceList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.SourceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SourceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SourceList.Location = new System.Drawing.Point(12, 12);
            this.SourceList.MultiSelect = false;
            this.SourceList.Name = "SourceList";
            this.SourceList.ReadOnly = true;
            this.SourceList.RowHeadersVisible = false;
            this.SourceList.RowTemplate.Height = 25;
            this.SourceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SourceList.Size = new System.Drawing.Size(484, 371);
            this.SourceList.StandardTab = true;
            this.SourceList.TabIndex = 0;
            this.SourceList.SelectionChanged += new System.EventHandler(this.SourceList_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.E, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.D, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.C, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.B, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.A, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(502, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 145);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // E
            // 
            this.E.AutoSize = true;
            this.E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.E.Location = new System.Drawing.Point(332, 73);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(75, 71);
            this.E.TabIndex = 9;
            this.E.Text = "E";
            this.E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.D.Location = new System.Drawing.Point(250, 73);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(75, 71);
            this.D.TabIndex = 8;
            this.D.Text = "D";
            this.D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // C
            // 
            this.C.AutoSize = true;
            this.C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.C.Location = new System.Drawing.Point(168, 73);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(75, 71);
            this.C.TabIndex = 7;
            this.C.Text = "C";
            this.C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B.Location = new System.Drawing.Point(86, 73);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(75, 71);
            this.B.TabIndex = 6;
            this.B.Text = "B";
            this.B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // A
            // 
            this.A.AutoSize = true;
            this.A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.A.Location = new System.Drawing.Point(4, 73);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(75, 71);
            this.A.TabIndex = 5;
            this.A.Text = "A";
            this.A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(332, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 71);
            this.label5.TabIndex = 4;
            this.label5.Text = "Score E";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(250, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 71);
            this.label4.TabIndex = 3;
            this.label4.Text = "Score D";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(168, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 71);
            this.label3.TabIndex = 2;
            this.label3.Text = "Score C";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(86, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 71);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BindButton
            // 
            this.BindButton.Location = new System.Drawing.Point(824, 362);
            this.BindButton.Name = "BindButton";
            this.BindButton.Size = new System.Drawing.Size(89, 49);
            this.BindButton.TabIndex = 2;
            this.BindButton.Text = "Bind";
            this.BindButton.UseVisualStyleBackColor = true;
            this.BindButton.Click += new System.EventHandler(this.BindButton_Click);
            // 
            // AverageScore
            // 
            this.AverageScore.Location = new System.Drawing.Point(813, 174);
            this.AverageScore.Name = "AverageScore";
            this.AverageScore.Size = new System.Drawing.Size(100, 25);
            this.AverageScore.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(720, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Average Sore";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(813, 205);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 27);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton2_Click);
            // 
            // StatusViewChangeCheckbox
            // 
            this.StatusViewChangeCheckbox.AutoSize = true;
            this.StatusViewChangeCheckbox.Location = new System.Drawing.Point(397, 389);
            this.StatusViewChangeCheckbox.Name = "StatusViewChangeCheckbox";
            this.StatusViewChangeCheckbox.Size = new System.Drawing.Size(99, 22);
            this.StatusViewChangeCheckbox.TabIndex = 6;
            this.StatusViewChangeCheckbox.Text = "済みを非表示";
            this.StatusViewChangeCheckbox.UseVisualStyleBackColor = true;
            this.StatusViewChangeCheckbox.CheckedChanged += new System.EventHandler(this.StatusViewChangeCheckbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 423);
            this.Controls.Add(this.StatusViewChangeCheckbox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AverageScore);
            this.Controls.Add(this.BindButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SourceList);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SourceList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SourceList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label E;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.Label C;
        private System.Windows.Forms.Label B;
        private System.Windows.Forms.Label A;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BindButton;
        private System.Windows.Forms.TextBox AverageScore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox StatusViewChangeCheckbox;
    }
}

