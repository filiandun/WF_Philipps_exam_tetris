namespace Tetris
{
    partial class Game
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonMute = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonLevelPlus = new System.Windows.Forms.Button();
            this.buttonFirstLinePlus = new System.Windows.Forms.Button();
            this.buttonFirstLevelMinus = new System.Windows.Forms.Button();
            this.buttonLevelMinus = new System.Windows.Forms.Button();
            this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFirstLine = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstLine)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(346, 605);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(54, 33);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.TabStop = false;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonMute
            // 
            this.buttonMute.Enabled = false;
            this.buttonMute.Location = new System.Drawing.Point(406, 605);
            this.buttonMute.Name = "buttonMute";
            this.buttonMute.Size = new System.Drawing.Size(43, 33);
            this.buttonMute.TabIndex = 2;
            this.buttonMute.TabStop = false;
            this.buttonMute.Text = "Mute";
            this.buttonMute.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(489, 605);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(65, 33);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.White;
            this.labelScore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelScore.Location = new System.Drawing.Point(444, 84);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(35, 13);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "label2";
            // 
            // buttonLevelPlus
            // 
            this.buttonLevelPlus.Location = new System.Drawing.Point(361, 317);
            this.buttonLevelPlus.Name = "buttonLevelPlus";
            this.buttonLevelPlus.Size = new System.Drawing.Size(29, 23);
            this.buttonLevelPlus.TabIndex = 7;
            this.buttonLevelPlus.Text = "+";
            this.buttonLevelPlus.UseVisualStyleBackColor = true;
            this.buttonLevelPlus.Click += new System.EventHandler(this.buttonLevelPlus_Click);
            // 
            // buttonFirstLinePlus
            // 
            this.buttonFirstLinePlus.Location = new System.Drawing.Point(361, 197);
            this.buttonFirstLinePlus.Name = "buttonFirstLinePlus";
            this.buttonFirstLinePlus.Size = new System.Drawing.Size(29, 23);
            this.buttonFirstLinePlus.TabIndex = 8;
            this.buttonFirstLinePlus.Text = "+";
            this.buttonFirstLinePlus.UseVisualStyleBackColor = true;
            this.buttonFirstLinePlus.Click += new System.EventHandler(this.buttonFirstLinePlus_Click);
            // 
            // buttonFirstLevelMinus
            // 
            this.buttonFirstLevelMinus.Location = new System.Drawing.Point(525, 198);
            this.buttonFirstLevelMinus.Name = "buttonFirstLevelMinus";
            this.buttonFirstLevelMinus.Size = new System.Drawing.Size(29, 23);
            this.buttonFirstLevelMinus.TabIndex = 9;
            this.buttonFirstLevelMinus.Text = "-";
            this.buttonFirstLevelMinus.UseVisualStyleBackColor = true;
            this.buttonFirstLevelMinus.Click += new System.EventHandler(this.buttonFirstLevelMinus_Click);
            // 
            // buttonLevelMinus
            // 
            this.buttonLevelMinus.Location = new System.Drawing.Point(525, 317);
            this.buttonLevelMinus.Name = "buttonLevelMinus";
            this.buttonLevelMinus.Size = new System.Drawing.Size(29, 23);
            this.buttonLevelMinus.TabIndex = 10;
            this.buttonLevelMinus.Text = "-";
            this.buttonLevelMinus.UseVisualStyleBackColor = true;
            this.buttonLevelMinus.Click += new System.EventHandler(this.buttonLevelMinus_Click);
            // 
            // numericUpDownLevel
            // 
            this.numericUpDownLevel.Location = new System.Drawing.Point(417, 317);
            this.numericUpDownLevel.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownLevel.Name = "numericUpDownLevel";
            this.numericUpDownLevel.ReadOnly = true;
            this.numericUpDownLevel.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownLevel.TabIndex = 11;
            // 
            // numericUpDownFirstLine
            // 
            this.numericUpDownFirstLine.Location = new System.Drawing.Point(417, 197);
            this.numericUpDownFirstLine.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFirstLine.Name = "numericUpDownFirstLine";
            this.numericUpDownFirstLine.ReadOnly = true;
            this.numericUpDownFirstLine.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownFirstLine.TabIndex = 12;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris.Properties.Resources.Фон;
            this.ClientSize = new System.Drawing.Size(807, 650);
            this.Controls.Add(this.numericUpDownFirstLine);
            this.Controls.Add(this.numericUpDownLevel);
            this.Controls.Add(this.buttonLevelMinus);
            this.Controls.Add(this.buttonFirstLevelMinus);
            this.Controls.Add(this.buttonFirstLinePlus);
            this.Controls.Add(this.buttonLevelPlus);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonMute);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.label1);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonMute;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button buttonLevelPlus;
        private System.Windows.Forms.Button buttonFirstLinePlus;
        private System.Windows.Forms.Button buttonFirstLevelMinus;
        private System.Windows.Forms.Button buttonLevelMinus;
        private System.Windows.Forms.NumericUpDown numericUpDownLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownFirstLine;
    }
}