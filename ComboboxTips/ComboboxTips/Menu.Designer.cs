
namespace ComboboxTips
{
    partial class Menu
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
            this.SourceBindingSample = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceExchangeSample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SourceBindingSample
            // 
            this.SourceBindingSample.Location = new System.Drawing.Point(43, 38);
            this.SourceBindingSample.Name = "SourceBindingSample";
            this.SourceBindingSample.Size = new System.Drawing.Size(342, 46);
            this.SourceBindingSample.TabIndex = 0;
            this.SourceBindingSample.Text = "外部設定ファイルからコンボボックスへのソースバインディング";
            this.SourceBindingSample.UseVisualStyleBackColor = true;
            this.SourceBindingSample.Click += new System.EventHandler(this.SourceBindingSample_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Samples";
            // 
            // SourceExchangeSample
            // 
            this.SourceExchangeSample.Location = new System.Drawing.Point(43, 90);
            this.SourceExchangeSample.Name = "SourceExchangeSample";
            this.SourceExchangeSample.Size = new System.Drawing.Size(342, 46);
            this.SourceExchangeSample.TabIndex = 2;
            this.SourceExchangeSample.Text = "2つのコンボボックス連携でソースの切り替え";
            this.SourceExchangeSample.UseVisualStyleBackColor = true;
            this.SourceExchangeSample.Click += new System.EventHandler(this.SourceExchangeSample_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 181);
            this.Controls.Add(this.SourceExchangeSample);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceBindingSample);
            this.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SourceBindingSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SourceExchangeSample;
    }
}