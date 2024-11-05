using System.Data;
using gnuciDictionary;

namespace HangmanApp
{
    /*
     YM: Great job! See one comment below from LB which still needs fixing. User can overwrite the text box values. Was that intentional? 
    It may be worthwhile switching them to a label.

     LB: Amazing job on the game! 94% Please see comments and list of bugs below and resubmit.
        (*) 1. Ensure all relevant textboxes (e.g. txtAnswer, txtTriesRemaining, txtWord) are disabled when appropriate.
    */
    public partial class Hangman : Form
    {
        List<Button> lstKeys;
       
        List<Word> lstwrd = gnuciDictionary.EnglishDictionary.GetAllWords().ToList().Where(w => w.Value.Count() < 11 && w.Value.Count() > 5
                                                                    && !w.Value.Contains("-") && !w.Value.Contains(" ")).ToList();
        List<char> lstQuestionMark;

        Random rdm = new();
        string GameWord = "";

        enum WinningStatusEnum { Winning, Playing, Losing, GiveUp, Start }
        WinningStatusEnum GameStatus;


        public Hangman()
        {
            InitializeComponent();
            btnNewGame.Click += BtnNewGame_Click;
            lstKeys = new() {btnQ,btnW,btnE,btnR,btnT,btnY,btnU,btnI,btnO,btnP,
                                btnA,btnS,btnD, btnF,btnG,btnH,btnJ,btnK,btnL,
                                    btnZ,btnX,btnC,btnV,btnB,btnN,btnM};

            lstKeys.ForEach(b => b.Click += BtnKeyboard_Click);
            lstQuestionMark = new() { '?' };
            btnGiveUp.Click += BtnGiveUp_Click;
            btnReset.Click += BtnReset_Click;
        }

        private void BtnNewGame_Click(object? sender, EventArgs e)
        {
            StartGame();
        }
        static string Replicate(char character, int count)
        {
            return new string(character, count);
        }

        private void BtnKeyboard_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            LetterSelection(btn);
        }
        private string Stuff(int substrend, string repl)
        {
            return txtWord.Text.Substring(0, substrend) + repl + txtWord.Text.Substring(substrend + 1, txtWord.TextLength - substrend - 1);
        }
        private void EndGame()
        {

            foreach (Control c in tblBottom.Controls)
            {
                c.Enabled = false;
            }

            DisableTableMainControls();

            EnableControlsForNewGame();

            txtAnswer.Enabled = true;
            txtAnswer.Text = GameWord.ToString();
            switch (GameStatus)
            {
                case WinningStatusEnum.Winning:
                    txtWord.ForeColor = Color.Green;
                    txtWord.Enabled = true;
                    break;
                case WinningStatusEnum.Start:
                case WinningStatusEnum.GiveUp:
                    NewGameMode();
                    break;
            }

            txtScore.Text = CalculateScore().ToString();

            GameMessage();
        }
        private void GameMessage()
        {
            string msg = GameWord.ToList().Count().ToString() + "-letter word. Click on the keyboard below to choose a letter.";
            string score = txtScore.Text;

            switch (GameStatus)
            {
                case WinningStatusEnum.Start:
                    msg = "Press 'New game' to begin playing.";
                    break;
                case WinningStatusEnum.Winning:
                    msg = "YOU WIN! Points earned this round: " + CalculatePoints() +
                    ". Total score: " + score + ".";
                    break;
                case WinningStatusEnum.Losing:
                    msg = "Game over - word is: " + GameWord + ". Total score: " + score + ".";
                    break;
                case WinningStatusEnum.GiveUp:
                    msg = "No problem, you'll have another chance soon. Total score: " + score + ".";
                    break;
            }
            txtMessage.Text = msg;

        }
        private WinningStatusEnum DetermineStatus()
        {
            
            int n;
            int.TryParse(txtTriesRemaining.Text, out n);

            if (txtWord.Text == GameWord)
            {
                GameStatus = WinningStatusEnum.Winning;
                EndGame();
            }
            else if (n < 1)
            {
                GameStatus = WinningStatusEnum.Losing;
                EndGame();
            }
            else
                GameStatus = WinningStatusEnum.Playing;

            return GameStatus;
        }
        private int CalculatePoints()
        {
            int points = 0;
            int ecpoints = 0;
            int TriesRemaining = 0;
            int.TryParse(txtTriesRemaining.Text, out TriesRemaining);

            if (TriesRemaining > 2 && txtWord.Text == GameWord)
            {
                ecpoints = 1;
            }
            switch (GameStatus)
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
            GameStatus = WinningStatusEnum.GiveUp;
            EndGame();
        }
        private void BtnReset_Click(object? sender, EventArgs e)
        {
            GameStatus = WinningStatusEnum.Start;
            EndGame();
        }
        private void EnableControlsForNewGame()
        {
            btnNewGame.Enabled = true;
            txtMessage.Enabled = true;
        }
        private void NewGameMode()
        {
            DisableTableMainControls();
            EnableControlsForNewGame();

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
        private void StartGame()
        {
            GameWord = lstwrd[rdm.Next(0, lstwrd.Count)].Value.ToString().ToUpper();

            GameStatus = WinningStatusEnum.Playing;
            txtWord.ForeColor = Color.Black;

            txtTriesRemaining.Text = 13.ToString();

            int LetterNum = GameWord.Length;

            foreach (Control c in tblMain.Controls)
            {
                c.Enabled = true;
            }

            btnNewGame.Enabled = false;
            txtAnswer.Text = "";
            txtAnswer.Enabled = false;

            foreach (Control c in tblBottom.Controls)
            {
                c.Enabled = true;
            }

            lstKeys.ForEach(b => b.Enabled = true);

            GameMessage();

            txtWord.Text = Replicate(lstQuestionMark[0], LetterNum);

            txtLetters.Clear();
        }
        private void LetterSelection(Button btn)
        {
            txtLetters.Text = txtLetters.Text + btn.Text;
            btn.Enabled = false;

            int n;
            char w;
            char.TryParse(btn.Text, out w);

            if (int.TryParse(txtTriesRemaining.Text, out n))
            {
                txtTriesRemaining.Text = (n - 1).ToString();
            }

            if (GameWord.Contains(btn.Text))
            {
                for (int i = 0; i < GameWord.Length; i++)
                {
                    if (GameWord[i] == w)
                    {
                        int index = GameWord[i];
                        txtWord.Text = Stuff(i, w.ToString());
                    }
                }
            }
            DetermineStatus();
        }
    }
}
