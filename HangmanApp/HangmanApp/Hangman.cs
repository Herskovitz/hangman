using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Extensions;
using gnuciDictionary;
using Microsoft.VisualBasic;
using static System.Formats.Asn1.AsnWriter;

namespace HangmanApp
{
    public partial class Hangman : Form
    {
        List<Button> lstkeys;
        List<Word> lstwrd = gnuciDictionary.EnglishDictionary.GetAllWords().ToList().Where(w => w.Value.Count() < 11 && w.Value.Count() > 5 
                                                                    && w.Value.Contains("-") == false && w.Value.Contains(" ") == false).ToList();

        List<char> lstquestionmark;

        Random rdm = new();
        string gameword = "";

        enum WinningStatusEnum { Winning, Playing, Losing, GiveUp, Start }
        WinningStatusEnum gamestatus;


        public Hangman()
        {
            InitializeComponent();
            btnNewGame.Click += BtnNewGame_Click;
            lstkeys = new() {btnQ,btnW,btnE,btnR,btnT,btnY,btnU,btnI,btnO,btnP,
                                btnA,btnS,btnD, btnF,btnG,btnH,btnJ,btnK,btnL,
                                    btnZ,btnX,btnC,btnV,btnB,btnN,btnM};

            lstkeys.ForEach(b => b.Click += BtnKeyboard_Click);
            lstquestionmark = new() { '?' };
            btnGiveUp.Click += BtnGiveUp_Click;
            btnReset.Click += BtnReset_Click;
        }

        private void BtnNewGame_Click(object? sender, EventArgs e)
        {
            gameword = lstwrd[rdm.Next(0, lstwrd.Count)].Value.ToString().ToUpper();

            gamestatus = WinningStatusEnum.Playing;
            txtWord.ForeColor = Color.Black;

            txtTriesRemaining.Text = 13.ToString();

            int letternum = gameword.Length;

            foreach(Control c in tblMain.Controls)
            {
                c.Enabled = true;
            }

            btnNewGame.Enabled = false;
            txtAnswer.Text = "";

            foreach (Control c in tblBottom.Controls)
            {
                c.Enabled = true;
            }

            lstkeys.ForEach(b => b.Enabled = true);

            GameMessage();

            txtWord.Text = Replicate(lstquestionmark[0], letternum);

            txtLetters.Clear();

        }
        static string Replicate(char character, int count)
        {
            return new string(character, count);
        }

        private void BtnKeyboard_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtLetters.Text = txtLetters.Text + btn.Text;
            btn.Enabled = false;
            int n = 13;
            bool conversion = int.TryParse(txtTriesRemaining.Text, out n);

            char w;
            char.TryParse(btn.Text, out w);

            if (conversion == true)
            {
                txtTriesRemaining.Text = (n - 1).ToString();
            }

            if (gameword.Contains(btn.Text))
            {
                for (int i = 0; i < gameword.Length; i++)
                {
                    if (gameword[i] == w)
                    {
                        int index = gameword[i];
                        txtWord.Text = Stuff(i, w.ToString());
                    }
                }
            }
            DetermineStatus();
        }
        private string Stuff(int substrend, string repl)
        {
            return txtWord.Text.Substring(0,substrend) + repl + txtWord.Text.Substring(substrend + 1, txtWord.TextLength - substrend - 1);
        }
        private void EndGame()
        {
            foreach (Control c in tblBottom.Controls)
            {
                c.Enabled = false;
            }
            DisableTableMainControls();

            EndGameMode();

            switch (gamestatus)
            {
                case WinningStatusEnum.Winning:
                    txtWord.Enabled = true;
                    txtWord.ForeColor = Color.Green;
                    break;
                case WinningStatusEnum.Start:
                    NewGameMode();
                    break;
            }
            GameMessage();
            txtScore.Text = CalculateScore().ToString();
            txtAnswer.Text = gameword.ToString();
        }
        private void GameMessage()
        {
            string msg = gameword.ToList().Count().ToString() + "-letter word. Click on the keyboard below to choose a letter.";
            string score = CalculateScore().ToString();

            switch (gamestatus)
            {
                case WinningStatusEnum.Start:
                    msg = "Press 'New game' to begin playing.";
                    break;
                case WinningStatusEnum.Winning:
                    msg = "YOU WIN! Points earned this round: " + CalculatePoints() +
                    ". Total score: " + score + ".";
                    break;
                case WinningStatusEnum.Losing:
                    msg = "Game over - word is: " + gameword + ". Total score: " + score + ".";
                    break;
                case WinningStatusEnum.GiveUp:
                    msg = "No problem, you'll have another chance soon. Total score: " + score + ".";
                    break;
            }
            txtMessage.Text = msg;

        }
        private WinningStatusEnum DetermineStatus()
        {
            int n = 13;
            bool conversion = int.TryParse(txtTriesRemaining.Text, out n);

            if (txtWord.Text == gameword)
            {
                gamestatus = WinningStatusEnum.Winning;
                EndGame();
            }
            else if (n < 1)
            {
                gamestatus = WinningStatusEnum.Losing;
                EndGame();
            }
            else
                gamestatus = WinningStatusEnum.Playing;
            return gamestatus;
        }
        private int CalculatePoints()
        {
            int points = 0;
            int ecpoints = 0;
            int triesremaining = 0;
            int.TryParse(txtTriesRemaining.Text, out triesremaining);

            if (triesremaining > 2 && txtWord.Text == gameword)
            {
                ecpoints = 1;
            }
            switch (gamestatus)
            {
                case WinningStatusEnum.Winning:
                    points = 1;
                    break;
                case WinningStatusEnum.Losing:
                    points = -1;
                    break;
                case WinningStatusEnum.GiveUp:
                    points = -2;
                    break;
            }
            return points + ecpoints;
        }
        private int CalculateScore()
        {
            int score = 0;
            int.TryParse(txtScore.Text, out score);
            return score + CalculatePoints();
        }
        private void BtnGiveUp_Click(object? sender, EventArgs e)
        {
            gamestatus = WinningStatusEnum.GiveUp;
            EndGame();
        }
        private void BtnReset_Click(object? sender, EventArgs e)
        {
            gamestatus = WinningStatusEnum.Start;
            EndGame();
        }
        private void EndGameMode()
        {
            btnNewGame.Enabled = true;
            txtMessage.Enabled = true;
        }
        private void NewGameMode()
        {
            DisableTableMainControls();
            EndGameMode();

            foreach (Control c in tblMain.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
        private void DisableTableMainControls()
        {
            foreach (Control c in tblMain.Controls)
            {
                c.Enabled = false;
            }
        }
    }
}
