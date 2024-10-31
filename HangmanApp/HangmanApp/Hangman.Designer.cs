namespace HangmanApp
{
    partial class Hangman : Form
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
            tblMain = new TableLayoutPanel();
            txtMessage = new TextBox();
            btnNewGame = new Button();
            lblScore = new Label();
            txtScore = new TextBox();
            txtAnswer = new TextBox();
            txtTriesRemaining = new TextBox();
            lblAnswer = new Label();
            lblTriesRemaining = new Label();
            txtWord = new TextBox();
            tblBottom = new TableLayoutPanel();
            tblKeys = new TableLayoutPanel();
            btnQ = new Button();
            btnW = new Button();
            btnE = new Button();
            btnR = new Button();
            btnT = new Button();
            btnY = new Button();
            btnU = new Button();
            btnI = new Button();
            btnO = new Button();
            btnP = new Button();
            btnA = new Button();
            btnS = new Button();
            btnD = new Button();
            btnF = new Button();
            btnG = new Button();
            btnH = new Button();
            btnJ = new Button();
            btnK = new Button();
            btnL = new Button();
            btnZ = new Button();
            btnX = new Button();
            btnC = new Button();
            btnV = new Button();
            btnB = new Button();
            btnN = new Button();
            btnM = new Button();
            lblLetters = new Label();
            txtLetters = new TextBox();
            btnGiveUp = new Button();
            btnReset = new Button();
            tblMain.SuspendLayout();
            tblBottom.SuspendLayout();
            tblKeys.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 7;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66278F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6627789F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6627789F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6627789F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6627789F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.338054F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.348052F));
            tblMain.Controls.Add(txtMessage, 1, 0);
            tblMain.Controls.Add(btnNewGame, 0, 0);
            tblMain.Controls.Add(lblScore, 5, 0);
            tblMain.Controls.Add(txtScore, 6, 0);
            tblMain.Controls.Add(txtAnswer, 2, 1);
            tblMain.Controls.Add(txtTriesRemaining, 4, 1);
            tblMain.Controls.Add(lblAnswer, 1, 1);
            tblMain.Controls.Add(lblTriesRemaining, 3, 1);
            tblMain.Controls.Add(txtWord, 0, 2);
            tblMain.Controls.Add(tblBottom, 0, 4);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 6;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 19F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 19F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 19F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 19F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(962, 543);
            tblMain.TabIndex = 0;
            // 
            // txtMessage
            // 
            tblMain.SetColumnSpan(txtMessage, 4);
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMessage.ForeColor = Color.Firebrick;
            txtMessage.Location = new Point(163, 3);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(634, 56);
            txtMessage.TabIndex = 1;
            txtMessage.TabStop = false;
            txtMessage.Text = "Press 'New game' to begin playing.";
            txtMessage.TextAlign = HorizontalAlignment.Center;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = Color.DarkTurquoise;
            btnNewGame.Dock = DockStyle.Fill;
            btnNewGame.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewGame.ForeColor = SystemColors.ButtonFace;
            btnNewGame.Location = new Point(3, 3);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(154, 56);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = SystemColors.Highlight;
            lblScore.Dock = DockStyle.Fill;
            lblScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = SystemColors.ButtonFace;
            lblScore.Location = new Point(803, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(74, 62);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score:";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtScore
            // 
            txtScore.Dock = DockStyle.Fill;
            txtScore.Enabled = false;
            txtScore.Location = new Point(883, 3);
            txtScore.Multiline = true;
            txtScore.Name = "txtScore";
            txtScore.PlaceholderText = "0";
            txtScore.Size = new Size(76, 56);
            txtScore.TabIndex = 3;
            txtScore.TabStop = false;
            txtScore.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAnswer
            // 
            txtAnswer.Dock = DockStyle.Fill;
            txtAnswer.Enabled = false;
            txtAnswer.Location = new Point(323, 65);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(154, 56);
            txtAnswer.TabIndex = 5;
            txtAnswer.TabStop = false;
            // 
            // txtTriesRemaining
            // 
            txtTriesRemaining.Dock = DockStyle.Fill;
            txtTriesRemaining.Enabled = false;
            txtTriesRemaining.Location = new Point(643, 65);
            txtTriesRemaining.Multiline = true;
            txtTriesRemaining.Name = "txtTriesRemaining";
            txtTriesRemaining.Size = new Size(154, 56);
            txtTriesRemaining.TabIndex = 7;
            txtTriesRemaining.TabStop = false;
            txtTriesRemaining.Text = "13";
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.BackColor = Color.LightSeaGreen;
            lblAnswer.Dock = DockStyle.Fill;
            lblAnswer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAnswer.ForeColor = SystemColors.ButtonFace;
            lblAnswer.Location = new Point(163, 62);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(154, 62);
            lblAnswer.TabIndex = 4;
            lblAnswer.Text = "Answer:";
            lblAnswer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTriesRemaining
            // 
            lblTriesRemaining.AutoSize = true;
            lblTriesRemaining.BackColor = SystemColors.ActiveCaption;
            lblTriesRemaining.Dock = DockStyle.Fill;
            lblTriesRemaining.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTriesRemaining.ForeColor = SystemColors.ButtonFace;
            lblTriesRemaining.Location = new Point(483, 62);
            lblTriesRemaining.Name = "lblTriesRemaining";
            lblTriesRemaining.Size = new Size(154, 62);
            lblTriesRemaining.TabIndex = 6;
            lblTriesRemaining.Text = "# of tries remaining:";
            lblTriesRemaining.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtWord
            // 
            txtWord.BackColor = SystemColors.Info;
            tblMain.SetColumnSpan(txtWord, 7);
            txtWord.Dock = DockStyle.Fill;
            txtWord.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWord.Location = new Point(3, 127);
            txtWord.Multiline = true;
            txtWord.Name = "txtWord";
            tblMain.SetRowSpan(txtWord, 2);
            txtWord.Size = new Size(956, 192);
            txtWord.TabIndex = 8;
            txtWord.TabStop = false;
            txtWord.TextAlign = HorizontalAlignment.Center;
            // 
            // tblBottom
            // 
            tblBottom.ColumnCount = 7;
            tblMain.SetColumnSpan(tblBottom, 7);
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.25F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.25F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.25F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.25F));
            tblBottom.Controls.Add(tblKeys, 1, 1);
            tblBottom.Controls.Add(lblLetters, 0, 1);
            tblBottom.Controls.Add(txtLetters, 0, 2);
            tblBottom.Controls.Add(btnGiveUp, 4, 1);
            tblBottom.Controls.Add(btnReset, 4, 3);
            tblBottom.Dock = DockStyle.Fill;
            tblBottom.Location = new Point(3, 325);
            tblBottom.Name = "tblBottom";
            tblBottom.RowCount = 5;
            tblMain.SetRowSpan(tblBottom, 3);
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBottom.Size = new Size(956, 215);
            tblBottom.TabIndex = 0;
            // 
            // tblKeys
            // 
            tblKeys.ColumnCount = 20;
            tblBottom.SetColumnSpan(tblKeys, 3);
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.00239944F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99987364F));
            tblKeys.Controls.Add(btnQ, 0, 0);
            tblKeys.Controls.Add(btnW, 2, 0);
            tblKeys.Controls.Add(btnE, 4, 0);
            tblKeys.Controls.Add(btnR, 6, 0);
            tblKeys.Controls.Add(btnT, 8, 0);
            tblKeys.Controls.Add(btnY, 10, 0);
            tblKeys.Controls.Add(btnU, 12, 0);
            tblKeys.Controls.Add(btnI, 14, 0);
            tblKeys.Controls.Add(btnO, 16, 0);
            tblKeys.Controls.Add(btnP, 18, 0);
            tblKeys.Controls.Add(btnA, 1, 1);
            tblKeys.Controls.Add(btnS, 3, 1);
            tblKeys.Controls.Add(btnD, 5, 1);
            tblKeys.Controls.Add(btnF, 7, 1);
            tblKeys.Controls.Add(btnG, 9, 1);
            tblKeys.Controls.Add(btnH, 11, 1);
            tblKeys.Controls.Add(btnJ, 13, 1);
            tblKeys.Controls.Add(btnK, 15, 1);
            tblKeys.Controls.Add(btnL, 17, 1);
            tblKeys.Controls.Add(btnZ, 2, 2);
            tblKeys.Controls.Add(btnX, 4, 2);
            tblKeys.Controls.Add(btnC, 6, 2);
            tblKeys.Controls.Add(btnV, 8, 2);
            tblKeys.Controls.Add(btnB, 10, 2);
            tblKeys.Controls.Add(btnN, 12, 2);
            tblKeys.Controls.Add(btnM, 14, 2);
            tblKeys.Dock = DockStyle.Fill;
            tblKeys.Location = new Point(242, 46);
            tblKeys.Name = "tblKeys";
            tblKeys.RowCount = 3;
            tblBottom.SetRowSpan(tblKeys, 3);
            tblKeys.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblKeys.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tblKeys.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tblKeys.Size = new Size(531, 123);
            tblKeys.TabIndex = 9;
            // 
            // btnQ
            // 
            tblKeys.SetColumnSpan(btnQ, 2);
            btnQ.Dock = DockStyle.Fill;
            btnQ.Enabled = false;
            btnQ.Location = new Point(3, 3);
            btnQ.Name = "btnQ";
            btnQ.Size = new Size(46, 34);
            btnQ.TabIndex = 0;
            btnQ.Text = "Q";
            btnQ.UseVisualStyleBackColor = true;
            // 
            // btnW
            // 
            tblKeys.SetColumnSpan(btnW, 2);
            btnW.Dock = DockStyle.Fill;
            btnW.Enabled = false;
            btnW.Location = new Point(55, 3);
            btnW.Name = "btnW";
            btnW.Size = new Size(46, 34);
            btnW.TabIndex = 1;
            btnW.Text = "W";
            btnW.UseVisualStyleBackColor = true;
            // 
            // btnE
            // 
            tblKeys.SetColumnSpan(btnE, 2);
            btnE.Dock = DockStyle.Fill;
            btnE.Enabled = false;
            btnE.Location = new Point(107, 3);
            btnE.Name = "btnE";
            btnE.Size = new Size(46, 34);
            btnE.TabIndex = 2;
            btnE.Text = "E";
            btnE.UseVisualStyleBackColor = true;
            // 
            // btnR
            // 
            tblKeys.SetColumnSpan(btnR, 2);
            btnR.Dock = DockStyle.Fill;
            btnR.Enabled = false;
            btnR.Location = new Point(159, 3);
            btnR.Name = "btnR";
            btnR.Size = new Size(46, 34);
            btnR.TabIndex = 3;
            btnR.Text = "R";
            btnR.UseVisualStyleBackColor = true;
            // 
            // btnT
            // 
            tblKeys.SetColumnSpan(btnT, 2);
            btnT.Dock = DockStyle.Fill;
            btnT.Enabled = false;
            btnT.Location = new Point(211, 3);
            btnT.Name = "btnT";
            btnT.Size = new Size(46, 34);
            btnT.TabIndex = 4;
            btnT.Text = "T";
            btnT.UseVisualStyleBackColor = true;
            // 
            // btnY
            // 
            tblKeys.SetColumnSpan(btnY, 2);
            btnY.Dock = DockStyle.Fill;
            btnY.Enabled = false;
            btnY.Location = new Point(263, 3);
            btnY.Name = "btnY";
            btnY.Size = new Size(46, 34);
            btnY.TabIndex = 5;
            btnY.Text = "Y";
            btnY.UseVisualStyleBackColor = true;
            // 
            // btnU
            // 
            tblKeys.SetColumnSpan(btnU, 2);
            btnU.Dock = DockStyle.Fill;
            btnU.Enabled = false;
            btnU.Location = new Point(315, 3);
            btnU.Name = "btnU";
            btnU.Size = new Size(46, 34);
            btnU.TabIndex = 6;
            btnU.Text = "U";
            btnU.UseVisualStyleBackColor = true;
            // 
            // btnI
            // 
            tblKeys.SetColumnSpan(btnI, 2);
            btnI.Dock = DockStyle.Fill;
            btnI.Enabled = false;
            btnI.Location = new Point(367, 3);
            btnI.Name = "btnI";
            btnI.Size = new Size(46, 34);
            btnI.TabIndex = 7;
            btnI.Text = "I";
            btnI.UseVisualStyleBackColor = true;
            // 
            // btnO
            // 
            tblKeys.SetColumnSpan(btnO, 2);
            btnO.Dock = DockStyle.Fill;
            btnO.Enabled = false;
            btnO.Location = new Point(419, 3);
            btnO.Name = "btnO";
            btnO.Size = new Size(46, 34);
            btnO.TabIndex = 8;
            btnO.Text = "O";
            btnO.UseVisualStyleBackColor = true;
            // 
            // btnP
            // 
            tblKeys.SetColumnSpan(btnP, 2);
            btnP.Dock = DockStyle.Fill;
            btnP.Enabled = false;
            btnP.Location = new Point(471, 3);
            btnP.Name = "btnP";
            btnP.Size = new Size(57, 34);
            btnP.TabIndex = 9;
            btnP.Text = "P";
            btnP.UseVisualStyleBackColor = true;
            // 
            // btnA
            // 
            tblKeys.SetColumnSpan(btnA, 2);
            btnA.Dock = DockStyle.Fill;
            btnA.Enabled = false;
            btnA.Location = new Point(29, 43);
            btnA.Name = "btnA";
            btnA.Size = new Size(46, 35);
            btnA.TabIndex = 10;
            btnA.Text = "A";
            btnA.UseVisualStyleBackColor = true;
            // 
            // btnS
            // 
            tblKeys.SetColumnSpan(btnS, 2);
            btnS.Dock = DockStyle.Fill;
            btnS.Enabled = false;
            btnS.Location = new Point(81, 43);
            btnS.Name = "btnS";
            btnS.Size = new Size(46, 35);
            btnS.TabIndex = 11;
            btnS.Text = "S";
            btnS.UseVisualStyleBackColor = true;
            // 
            // btnD
            // 
            tblKeys.SetColumnSpan(btnD, 2);
            btnD.Dock = DockStyle.Fill;
            btnD.Enabled = false;
            btnD.Location = new Point(133, 43);
            btnD.Name = "btnD";
            btnD.Size = new Size(46, 35);
            btnD.TabIndex = 12;
            btnD.Text = "D";
            btnD.UseVisualStyleBackColor = true;
            // 
            // btnF
            // 
            tblKeys.SetColumnSpan(btnF, 2);
            btnF.Dock = DockStyle.Fill;
            btnF.Enabled = false;
            btnF.Location = new Point(185, 43);
            btnF.Name = "btnF";
            btnF.Size = new Size(46, 35);
            btnF.TabIndex = 13;
            btnF.Text = "F";
            btnF.UseVisualStyleBackColor = true;
            // 
            // btnG
            // 
            tblKeys.SetColumnSpan(btnG, 2);
            btnG.Dock = DockStyle.Fill;
            btnG.Enabled = false;
            btnG.Location = new Point(237, 43);
            btnG.Name = "btnG";
            btnG.Size = new Size(46, 35);
            btnG.TabIndex = 14;
            btnG.Text = "G";
            btnG.UseVisualStyleBackColor = true;
            // 
            // btnH
            // 
            tblKeys.SetColumnSpan(btnH, 2);
            btnH.Dock = DockStyle.Fill;
            btnH.Enabled = false;
            btnH.Location = new Point(289, 43);
            btnH.Name = "btnH";
            btnH.Size = new Size(46, 35);
            btnH.TabIndex = 15;
            btnH.Text = "H";
            btnH.UseVisualStyleBackColor = true;
            // 
            // btnJ
            // 
            tblKeys.SetColumnSpan(btnJ, 2);
            btnJ.Dock = DockStyle.Fill;
            btnJ.Enabled = false;
            btnJ.Location = new Point(341, 43);
            btnJ.Name = "btnJ";
            btnJ.Size = new Size(46, 35);
            btnJ.TabIndex = 16;
            btnJ.Text = "J";
            btnJ.UseVisualStyleBackColor = true;
            // 
            // btnK
            // 
            tblKeys.SetColumnSpan(btnK, 2);
            btnK.Dock = DockStyle.Fill;
            btnK.Enabled = false;
            btnK.Location = new Point(393, 43);
            btnK.Name = "btnK";
            btnK.Size = new Size(46, 35);
            btnK.TabIndex = 17;
            btnK.Text = "K";
            btnK.UseVisualStyleBackColor = true;
            // 
            // btnL
            // 
            tblKeys.SetColumnSpan(btnL, 2);
            btnL.Dock = DockStyle.Fill;
            btnL.Enabled = false;
            btnL.Location = new Point(445, 43);
            btnL.Name = "btnL";
            btnL.Size = new Size(46, 35);
            btnL.TabIndex = 18;
            btnL.Text = "L";
            btnL.UseVisualStyleBackColor = true;
            // 
            // btnZ
            // 
            tblKeys.SetColumnSpan(btnZ, 2);
            btnZ.Dock = DockStyle.Fill;
            btnZ.Enabled = false;
            btnZ.Location = new Point(55, 84);
            btnZ.Name = "btnZ";
            btnZ.Size = new Size(46, 36);
            btnZ.TabIndex = 19;
            btnZ.Text = "Z";
            btnZ.UseVisualStyleBackColor = true;
            // 
            // btnX
            // 
            tblKeys.SetColumnSpan(btnX, 2);
            btnX.Dock = DockStyle.Fill;
            btnX.Enabled = false;
            btnX.Location = new Point(107, 84);
            btnX.Name = "btnX";
            btnX.Size = new Size(46, 36);
            btnX.TabIndex = 20;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            tblKeys.SetColumnSpan(btnC, 2);
            btnC.Dock = DockStyle.Fill;
            btnC.Enabled = false;
            btnC.Location = new Point(159, 84);
            btnC.Name = "btnC";
            btnC.Size = new Size(46, 36);
            btnC.TabIndex = 21;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = true;
            // 
            // btnV
            // 
            tblKeys.SetColumnSpan(btnV, 2);
            btnV.Dock = DockStyle.Fill;
            btnV.Enabled = false;
            btnV.Location = new Point(211, 84);
            btnV.Name = "btnV";
            btnV.Size = new Size(46, 36);
            btnV.TabIndex = 22;
            btnV.Text = "V";
            btnV.UseVisualStyleBackColor = true;
            // 
            // btnB
            // 
            tblKeys.SetColumnSpan(btnB, 2);
            btnB.Dock = DockStyle.Fill;
            btnB.Enabled = false;
            btnB.Location = new Point(263, 84);
            btnB.Name = "btnB";
            btnB.Size = new Size(46, 36);
            btnB.TabIndex = 23;
            btnB.Text = "B";
            btnB.UseVisualStyleBackColor = true;
            // 
            // btnN
            // 
            tblKeys.SetColumnSpan(btnN, 2);
            btnN.Dock = DockStyle.Fill;
            btnN.Enabled = false;
            btnN.Location = new Point(315, 84);
            btnN.Name = "btnN";
            btnN.Size = new Size(46, 36);
            btnN.TabIndex = 24;
            btnN.Text = "N";
            btnN.UseVisualStyleBackColor = true;
            // 
            // btnM
            // 
            tblKeys.SetColumnSpan(btnM, 2);
            btnM.Dock = DockStyle.Fill;
            btnM.Enabled = false;
            btnM.Location = new Point(367, 84);
            btnM.Name = "btnM";
            btnM.Size = new Size(46, 36);
            btnM.TabIndex = 25;
            btnM.Text = "M";
            btnM.UseVisualStyleBackColor = true;
            // 
            // lblLetters
            // 
            lblLetters.AutoSize = true;
            lblLetters.BackColor = SystemColors.ControlLight;
            lblLetters.Dock = DockStyle.Fill;
            lblLetters.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLetters.Location = new Point(3, 43);
            lblLetters.Name = "lblLetters";
            lblLetters.Size = new Size(233, 43);
            lblLetters.TabIndex = 0;
            lblLetters.Text = "Used Letters";
            lblLetters.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtLetters
            // 
            txtLetters.Dock = DockStyle.Fill;
            txtLetters.Enabled = false;
            txtLetters.Location = new Point(3, 89);
            txtLetters.Multiline = true;
            txtLetters.Name = "txtLetters";
            tblBottom.SetRowSpan(txtLetters, 2);
            txtLetters.Size = new Size(233, 80);
            txtLetters.TabIndex = 1;
            txtLetters.TabStop = false;
            // 
            // btnGiveUp
            // 
            btnGiveUp.BackColor = Color.Sienna;
            tblBottom.SetColumnSpan(btnGiveUp, 3);
            btnGiveUp.Dock = DockStyle.Fill;
            btnGiveUp.Enabled = false;
            btnGiveUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGiveUp.Location = new Point(779, 46);
            btnGiveUp.Name = "btnGiveUp";
            btnGiveUp.Size = new Size(174, 37);
            btnGiveUp.TabIndex = 0;
            btnGiveUp.Text = "Give up";
            btnGiveUp.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Coral;
            tblBottom.SetColumnSpan(btnReset, 3);
            btnReset.Dock = DockStyle.Fill;
            btnReset.Enabled = false;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(779, 132);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(174, 37);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // Hangman
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 543);
            Controls.Add(tblMain);
            Name = "Hangman";
            Text = "Hangman";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblBottom.ResumeLayout(false);
            tblBottom.PerformLayout();
            tblKeys.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TextBox txtMessage;
        private Button btnNewGame;
        private Label lblScore;
        private TextBox txtScore;
        private TextBox txtAnswer;
        private TextBox txtTriesRemaining;
        private Label lblAnswer;
        private Label lblTriesRemaining;
        private TextBox txtWord;
        private TableLayoutPanel tblKeys;
        private TableLayoutPanel tblBottom;
        private Button btnQ;
        private Button btnW;
        private Button btnE;
        private Button btnR;
        private Button btnT;
        private Button btnY;
        private Button btnU;
        private Button btnI;
        private Button btnO;
        private Button btnP;
        private Button btnA;
        private Button btnS;
        private Button btnD;
        private Button btnF;
        private Button btnG;
        private Button btnH;
        private Button btnJ;
        private Button btnK;
        private Button btnL;
        private Button btnZ;
        private Button btnX;
        private Button btnC;
        private Button btnV;
        private Button btnB;
        private Button btnN;
        private Button btnM;
        private Label lblLetters;
        private TextBox txtLetters;
        private Button btnGiveUp;
        private Button btnReset;
    }
}
