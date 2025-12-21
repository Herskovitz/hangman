using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HangmanSystem
{
    public enum GameStatusEnum { Winning, Playing, Losing, GiveUp, Start }

    public class Game : INotifyPropertyChanged
    {
        GameWord word = new GameWord();

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? ScoreChanged;

        int _numoftriesremaining = 0;
        string _maskedword = "";
        string _gamemessage = "Press 'New game' to begin playing.";
        static int _score = 0;
        List<char> _usedletters = new();
        bool _playing;
        private static int numgames;

        public Game()
        {
            numgames++;
            this.GameName = "Game " + numgames;
        }
        public List<Letter> Letters { get; } = new()
        {
            new() {Text = "Q", Enabled = false},
            new() {Text = "W", Enabled = false},
            new() {Text = "E", Enabled = false},
            new() {Text = "R", Enabled = false},
            new() {Text = "T", Enabled = false},
            new() {Text = "Y", Enabled = false},
            new() {Text = "U", Enabled = false},
            new() {Text = "I", Enabled = false},
            new() {Text = "O", Enabled = false},
            new() {Text = "P", Enabled = false},
            new() {Text = "A", Enabled = false},
            new() {Text = "S", Enabled = false},
            new() {Text = "D", Enabled = false},
            new() {Text = "F", Enabled = false},
            new() {Text = "G", Enabled = false},
            new() {Text = "H", Enabled = false},
            new() {Text = "J", Enabled = false},
            new() {Text = "K", Enabled = false},
            new() {Text = "L", Enabled = false},
            new() {Text = "Z", Enabled = false},
            new() {Text = "X", Enabled = false},
            new() {Text = "C", Enabled = false},
            new() {Text = "V", Enabled = false},
            new() {Text = "B", Enabled = false},
            new() {Text = "N", Enabled = false},
            new() {Text = "M", Enabled = false}
        };



        public GameStatusEnum GameStatus { get; set; } = GameStatusEnum.Start;
        public string Word => word.CurrentWord;
        public string MaskedWord
        {
            get => _maskedword;
            set
            {
                if (_maskedword != value)
                {
                    _maskedword = value;
                    InvokePropertyChanged();
                }
            }
        }
        public string GameMessage
        {
            get => _gamemessage;
            set
            {
                _gamemessage = value;
                InvokePropertyChanged();
            }
        }
        public string Answer { get; set; } = "";
        public int NumOfTriesRemaining
        {
            get => _numoftriesremaining;
            set
            {
                _numoftriesremaining = value;
                InvokePropertyChanged();
            }
        }
        public static int Score
        {
            get => _score;
            set
            {
                _score = value;
            }
        }
        public int ScoreDisplay
        {
            get => Score;
            set
            {
                ScoreChanged?.Invoke(this, new EventArgs());
            }
        }

        public List<char> UsedLetters
        {
            get => _usedletters;
            set
            {
                _usedletters = value;
                InvokePropertyChanged();
            }
        }
        public string UsedLettersDisplay => string.Join("", UsedLetters);
        public string GameName { get; private set; }
        public bool Playing
        {
            get => GameStatus == GameStatusEnum.Playing;
            set
            {
                _playing = value;
                InvokePropertyChanged();
            }
        }

        public bool CanStartNewGame => GameStatus == GameStatusEnum.Start || GameStatus == GameStatusEnum.Winning || GameStatus == GameStatusEnum.Losing || GameStatus == GameStatusEnum.GiveUp;
        public bool CanReset => GameStatus != GameStatusEnum.Start;
        public string ActiveGame { get; private set; }
        public string NewGameButtonText
        {
            get { return "New " + GameName; }

        }
        public void StartGame()
        {
            NewGameMode();
            Letters.ForEach(letter => letter.Enabled = true);
            word.PickRandomWord();
            GameStatus = GameStatusEnum.Playing;
            InvokePropertyChanged("Playing");
            InvokePropertyChanged("CanStartNewGame");
            NumOfTriesRemaining = 8;
            GetGameMessage();
            UpdateMaskedWord(word.CurrentWord);
        }
        public void HandleLetterSelection(string letter)
        {
            if (GameStatus == GameStatusEnum.Playing)
            {
                var currentletter = Letters.FirstOrDefault(l => l.Text == letter);
                if (currentletter != null)
                {
                    currentletter.Enabled = false;
                }

                if (!string.IsNullOrEmpty(letter))
                {
                    char charLetter = letter[0];
                    if (!UsedLetters.Contains(charLetter))
                    {
                        UsedLetters.Add(charLetter);
                        InvokePropertyChanged("UsedLettersDisplay");
                    }
                }

                if (word.CurrentWord.Contains(letter))
                {
                    UpdateMaskedWord(word.CurrentWord);
                }
                else
                {
                    NumOfTriesRemaining--;
                }
                EvaluateGameStatus();
            }
        }
        public void UpdateMaskedWord(string wordtomask)
        {
            var result = "";

            foreach (char c in wordtomask)
            {
                if (UsedLetters.Contains(c))
                    result += c;
                else
                    result += '?';
            }

            MaskedWord = result;
        }
        private GameStatusEnum EvaluateGameStatus()
        {
            if (MaskedWord == word.CurrentWord)
            {
                GameStatus = GameStatusEnum.Winning;
                EndGame();
            }
            else if (NumOfTriesRemaining < 1)
            {
                GameStatus = GameStatusEnum.Losing;
                EndGame();
            }
            else
            {
                GameStatus = GameStatusEnum.Playing;
            }

            return GameStatus;
        }
        public void EndGame()
        {
            Letters.ForEach(letter => letter.Enabled = false);
            Answer = word.CurrentWord;
            InvokePropertyChanged("Answer");
            switch (GameStatus)
            {
                case GameStatusEnum.Winning:
                    break;
                case GameStatusEnum.Start:
                case GameStatusEnum.GiveUp:
                    NewGameMode();
                    break;
            }
            InvokePropertyChanged("Playing");
            InvokePropertyChanged("CanStartNewGame");
            Score = CalculateScore();
            ScoreChanged?.Invoke(this, new EventArgs());
            InvokePropertyChanged("ScoreDisplay");
            GetGameMessage();
        }

        private int CalculateScore()
        {
            return Score + CalculatePoints();
        }
        private int CalculatePoints()
        {
            int points = 0;
            int ecpoints = 0;

            if (NumOfTriesRemaining > 2 && GameStatus == GameStatusEnum.Winning)
            {
                ecpoints = 1;
            }
            switch (GameStatus)
            {
                case GameStatusEnum.Winning:
                    points = 1;
                    break;
                case GameStatusEnum.Losing:
                    points = -1;
                    break;
                case GameStatusEnum.GiveUp:
                    points = -2;
                    break;
                case GameStatusEnum.Start:
                    points = -(Score);
                    break;
            }
            ScoreChanged?.Invoke(this, new EventArgs());
            return points + ecpoints;
        }
        private void NewGameMode()
        {
            NumOfTriesRemaining = 0;
            MaskedWord = "";
            UsedLetters.Clear();
            InvokePropertyChanged("UsedLettersDisplay");
            Answer = "";
            InvokePropertyChanged("Answer");
        }
        private void GetGameMessage()
        {
            string msg = word.WordLength + "-letter word. Click on the keyboard below to choose a letter.";
            switch (GameStatus)
            {
                case GameStatusEnum.Start:
                    msg = "Press 'New game' to begin playing.";
                    break;
                case GameStatusEnum.Winning:
                    msg = $"YOU WIN! Points earned this round: {CalculatePoints()} Total score: {Score}.";
                    break;
                case GameStatusEnum.Losing:
                    msg = $"Game over. Word is: {word.CurrentWord} Total score: {Score}.";
                    break;
                case GameStatusEnum.GiveUp:
                    msg = $"No problem, you'll have another chance soon. Total score: {Score}.";
                    break;
            }
            ScoreChanged?.Invoke(this, new EventArgs());
            GameMessage = $"{msg} ({GameName})";
        }
        public void RefreshGame()
        {
            NewGameMode();
            GameStatus = GameStatusEnum.Start;
            GetGameMessage();
        }
        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
