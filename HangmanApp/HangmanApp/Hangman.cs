using HangmanSystem;

namespace HangmanApp
{
    public partial class Hangman : Form
    {
        Game game = new();
        List<Button> lstKeys;

        public Hangman()
        {
            InitializeComponent();
            btnNewGame.Click += BtnNewGame_Click;
            lstKeys = new() {btnQ,btnW,btnE,btnR,btnT,btnY,btnU,btnI,btnO,btnP,
                                btnA,btnS,btnD, btnF,btnG,btnH,btnJ,btnK,btnL,
                                    btnZ,btnX,btnC,btnV,btnB,btnN,btnM};

            lstKeys.ForEach(b => b.Click += BtnKeyboard_Click);
            btnGiveUp.Click += BtnGiveUp_Click;
            btnReset.Click += BtnReset_Click;

            lblMessageText.DataBindings.Add("Text", game, "GameMessage");
            lblWordText.DataBindings.Add("Text", game, "MaskedWord");
            lblAnswerText.DataBindings.Add("Text", game, "Answer");
            lblScoreNum.DataBindings.Add("Text", game, "ScoreDisplay");
            lblTriesRemainingNum.DataBindings.Add("Text", game, "NumOfTriesRemaining");
            lblLettersText.DataBindings.Add("Text", game, "UsedLettersDisplay");
            btnNewGame.DataBindings.Add("Enabled", game, "CanStartNewGame");
            btnGiveUp.DataBindings.Add("Enabled", game, "Playing");
            btnReset.DataBindings.Add("Enabled", game, "Playing");
            for (int i = 0; i < lstKeys.Count; i++)
            {
                lstKeys[i].DataBindings.Add("Enabled", game.Letters[i], "Enabled");
            }
        }

        private void BtnNewGame_Click(object? sender, EventArgs e)
        {
            game.StartGame();
        }

        private void BtnKeyboard_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            game.HandleLetterSelection(btn.Text);
        }
        private void BtnGiveUp_Click(object? sender, EventArgs e)
        {
            game.GameStatus = GameStatusEnum.GiveUp;
            game.EndGame();
        }
        private void BtnReset_Click(object? sender, EventArgs e)
        {
            game.GameStatus = GameStatusEnum.Start;
            game.EndGame();
        } 
    }
}
