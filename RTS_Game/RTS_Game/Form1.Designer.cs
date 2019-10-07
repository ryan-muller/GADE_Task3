namespace RTS_Game
{
    partial class frmGameWindow
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
            this.components = new System.ComponentModel.Container();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblRoundCount = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.rtbUnitInfo = new System.Windows.Forms.RichTextBox();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblResourcesTeam1 = new System.Windows.Forms.Label();
            this.lblResourcesTeam2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(13, 13);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(100, 20);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "temp text";
            // 
            // lblRoundCount
            // 
            this.lblRoundCount.AutoSize = true;
            this.lblRoundCount.Location = new System.Drawing.Point(402, 13);
            this.lblRoundCount.Name = "lblRoundCount";
            this.lblRoundCount.Size = new System.Drawing.Size(82, 13);
            this.lblRoundCount.TabIndex = 1;
            this.lblRoundCount.Text = "Current Round: ";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(409, 433);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartGame.TabIndex = 2;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(516, 433);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // rtbUnitInfo
            // 
            this.rtbUnitInfo.Location = new System.Drawing.Point(405, 117);
            this.rtbUnitInfo.Name = "rtbUnitInfo";
            this.rtbUnitInfo.Size = new System.Drawing.Size(186, 291);
            this.rtbUnitInfo.TabIndex = 4;
            this.rtbUnitInfo.Text = "";
            // 
            // timerGame
            // 
            this.timerGame.Interval = 1000;
            this.timerGame.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(409, 463);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(516, 463);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblResourcesTeam1
            // 
            this.lblResourcesTeam1.AutoSize = true;
            this.lblResourcesTeam1.Location = new System.Drawing.Point(405, 56);
            this.lblResourcesTeam1.Name = "lblResourcesTeam1";
            this.lblResourcesTeam1.Size = new System.Drawing.Size(79, 13);
            this.lblResourcesTeam1.TabIndex = 7;
            this.lblResourcesTeam1.Text = "Team 1 Gems: ";
            // 
            // lblResourcesTeam2
            // 
            this.lblResourcesTeam2.AutoSize = true;
            this.lblResourcesTeam2.Location = new System.Drawing.Point(405, 73);
            this.lblResourcesTeam2.Name = "lblResourcesTeam2";
            this.lblResourcesTeam2.Size = new System.Drawing.Size(79, 13);
            this.lblResourcesTeam2.TabIndex = 8;
            this.lblResourcesTeam2.Text = "Team 2 Gems: ";
            // 
            // frmGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 537);
            this.Controls.Add(this.lblResourcesTeam2);
            this.Controls.Add(this.lblResourcesTeam1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbUnitInfo);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblRoundCount);
            this.Controls.Add(this.lblMap);
            this.Name = "frmGameWindow";
            this.Text = "Game Window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblRoundCount;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox rtbUnitInfo;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblResourcesTeam1;
        private System.Windows.Forms.Label lblResourcesTeam2;
    }
}

