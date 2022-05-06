namespace Randomizer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Options = new System.Windows.Forms.CheckedListBox();
            this.SelectBase = new System.Windows.Forms.Button();
            this.SelectGame = new System.Windows.Forms.Button();
            this.SeedInput = new System.Windows.Forms.TextBox();
            this.RegenerateSeed = new System.Windows.Forms.Button();
            this.Randomize = new System.Windows.Forms.Button();
            this.BaseStatus = new System.Windows.Forms.Label();
            this.GameStatus = new System.Windows.Forms.Label();
            this.Divider = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Options.FormattingEnabled = true;
            this.Options.Items.AddRange(new object[] {
            "Levels",
            "Themes",
            "Sounds",
            "Models"});
            this.Options.Location = new System.Drawing.Point(12, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(120, 214);
            this.Options.TabIndex = 0;
            // 
            // SelectBase
            // 
            this.SelectBase.Location = new System.Drawing.Point(140, 12);
            this.SelectBase.Name = "SelectBase";
            this.SelectBase.Size = new System.Drawing.Size(138, 38);
            this.SelectBase.TabIndex = 1;
            this.SelectBase.Text = "Select Base Directory";
            this.SelectBase.UseVisualStyleBackColor = true;
            this.SelectBase.Click += new System.EventHandler(this.SelectBase_Click);
            // 
            // SelectGame
            // 
            this.SelectGame.Location = new System.Drawing.Point(140, 56);
            this.SelectGame.Name = "SelectGame";
            this.SelectGame.Size = new System.Drawing.Size(138, 38);
            this.SelectGame.TabIndex = 2;
            this.SelectGame.Text = "Select Game Directory";
            this.SelectGame.UseVisualStyleBackColor = true;
            this.SelectGame.Click += new System.EventHandler(this.SelectGame_Click);
            // 
            // SeedInput
            // 
            this.SeedInput.Location = new System.Drawing.Point(141, 119);
            this.SeedInput.MaxLength = 40;
            this.SeedInput.Name = "SeedInput";
            this.SeedInput.Size = new System.Drawing.Size(138, 20);
            this.SeedInput.TabIndex = 3;
            this.SeedInput.Text = "0";
            // 
            // RegenerateSeed
            // 
            this.RegenerateSeed.Location = new System.Drawing.Point(141, 145);
            this.RegenerateSeed.Name = "RegenerateSeed";
            this.RegenerateSeed.Size = new System.Drawing.Size(138, 38);
            this.RegenerateSeed.TabIndex = 4;
            this.RegenerateSeed.Text = "Regenerate Seed";
            this.RegenerateSeed.UseVisualStyleBackColor = true;
            this.RegenerateSeed.Click += new System.EventHandler(this.RegenerateSeed_Click);
            // 
            // Randomize
            // 
            this.Randomize.Location = new System.Drawing.Point(141, 189);
            this.Randomize.Name = "Randomize";
            this.Randomize.Size = new System.Drawing.Size(138, 38);
            this.Randomize.TabIndex = 5;
            this.Randomize.Text = "Randomize";
            this.Randomize.UseVisualStyleBackColor = true;
            this.Randomize.Click += new System.EventHandler(this.Randomize_Click);
            // 
            // BaseStatus
            // 
            this.BaseStatus.AutoEllipsis = true;
            this.BaseStatus.AutoSize = true;
            this.BaseStatus.Location = new System.Drawing.Point(9, 229);
            this.BaseStatus.Name = "BaseStatus";
            this.BaseStatus.Size = new System.Drawing.Size(108, 13);
            this.BaseStatus.TabIndex = 6;
            this.BaseStatus.Text = "Base Directory: None";
            // 
            // GameStatus
            // 
            this.GameStatus.AutoSize = true;
            this.GameStatus.Location = new System.Drawing.Point(9, 244);
            this.GameStatus.Name = "GameStatus";
            this.GameStatus.Size = new System.Drawing.Size(112, 13);
            this.GameStatus.TabIndex = 7;
            this.GameStatus.Text = "Game Directory: None";
            // 
            // Divider
            // 
            this.Divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Divider.Location = new System.Drawing.Point(141, 105);
            this.Divider.Name = "Divider";
            this.Divider.Size = new System.Drawing.Size(137, 2);
            this.Divider.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 266);
            this.Controls.Add(this.Divider);
            this.Controls.Add(this.GameStatus);
            this.Controls.Add(this.BaseStatus);
            this.Controls.Add(this.Randomize);
            this.Controls.Add(this.RegenerateSeed);
            this.Controls.Add(this.SeedInput);
            this.Controls.Add(this.SelectGame);
            this.Controls.Add(this.SelectBase);
            this.Controls.Add(this.Options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Kula Randomizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Options;
        private System.Windows.Forms.Button SelectBase;
        private System.Windows.Forms.Button SelectGame;
        private System.Windows.Forms.TextBox SeedInput;
        private System.Windows.Forms.Button RegenerateSeed;
        private System.Windows.Forms.Button Randomize;
        private System.Windows.Forms.Label BaseStatus;
        private System.Windows.Forms.Label GameStatus;
        private System.Windows.Forms.Label Divider;
    }
}

