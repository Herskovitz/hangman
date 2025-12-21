using HangmanSystem;
using System.Linq;
namespace HangmanTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestStartGame()
        {
            Game game = new Game();
            game.StartGame();
            string msg = $"Game status = {game.GameStatus.ToString()}, masked word is {game.MaskedWord}.";
            Assert.IsTrue(game.GameStatus == GameStatusEnum.Playing && game.MaskedWord.Contains("??????"));
            TestContext.WriteLine(msg);
        }
        [Test]
        public void TestLetterSelectionNotInWord()
        {
            Game game = new Game();
            List<string> lstletters = new() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "l" };
            List<string> lstlettersinword = game.Word.Select(c => c.ToString()).ToList();
            var letternotinword = lstletters.FirstOrDefault(l => !lstlettersinword.Contains(l));
            game.StartGame();
            string maskedwordbeforeguess = game.MaskedWord;
            int numoftriesremainingbeforeguess = game.NumOfTriesRemaining;
            game.HandleLetterSelection(letternotinword);
            string msg = $"Masked word is {game.MaskedWord}, previous Masked word was {maskedwordbeforeguess}" +
                $"Number of tries remaining is {game.NumOfTriesRemaining} vs. previous number {numoftriesremainingbeforeguess}" +
                $"Used letters contrains the letter {letternotinword} which this test is using";
            Assert.IsTrue(maskedwordbeforeguess == game.MaskedWord && numoftriesremainingbeforeguess - 1 == game.NumOfTriesRemaining
                && game.UsedLetters.Contains(letternotinword[0]));
            TestContext.WriteLine(msg);
        }

        [Test]
        public void TestLetterSelectionInWord()
        {
            Game game = new Game();
            GameWord word = new GameWord();
            game.StartGame();
            int numoftriesremainingbeforeguess = game.NumOfTriesRemaining;
            List<string> lstletters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToList();
            List<string> lstlettersinword = game.Word.Select(c => c.ToString()).ToList();
            string letterinword = lstletters.FirstOrDefault(l => lstlettersinword.Contains(l));
            string maskedwordbeforeguess = game.MaskedWord;
            game.HandleLetterSelection(letterinword);
            string msg = $"Masked word is {game.MaskedWord} and has {letterinword} in it, vs. previous Masked word was {maskedwordbeforeguess}" +
                $"Number of tries remaining is {game.NumOfTriesRemaining} and previous number {numoftriesremainingbeforeguess}" +
                $"Used letters contrains the letter {letterinword} which this test is using";
            Assert.IsTrue(game.MaskedWord.Contains(letterinword[0]) && numoftriesremainingbeforeguess == game.NumOfTriesRemaining
                && game.UsedLetters.Contains(letterinword[0]));
            TestContext.WriteLine(msg);
        }
        [Test]
        public void UpdateMaskedWordTest()
        {
            Game game = new Game();
            game.UsedLetters.Add('t');
            game.UpdateMaskedWord("test");
            string msg = $"Updated Masked word is {game.MaskedWord}";
            Assert.IsTrue(game.MaskedWord == "t??t");
            TestContext.WriteLine(msg);
        }
        [Test]
        public void WinningTest()
        {
            Game game = new Game();
            game.StartGame();
            var wordletters = game.Word.Distinct();
            foreach (var letter in wordletters)
            {
                game.HandleLetterSelection(letter.ToString());
            }
            string msg = $"Game status is {game.GameStatus}, Masked word is {game.MaskedWord} - Current word is {game.Word} And answer is {game.Answer}";
            Assert.IsTrue(game.GameStatus == GameStatusEnum.Winning && game.MaskedWord == game.Word && game.Answer == game.Word);
            TestContext.WriteLine(msg);
        }
        [Test]
        public void LosingTest()
        {
            Game game = new Game();
            game.StartGame();
            List<string> lstletters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToList();
            List<string> lstlettersinword = game.Word.Distinct().Select(c => c.ToString()).ToList();
            List<string> lettersnotinword = lstletters.Where(l => !lstlettersinword.Contains(l)).ToList();
            //see if can replace the 8 by numoftriesremaining
            for (int i = 0; i < 8; i++)
            {
                game.HandleLetterSelection(lettersnotinword[i].ToString());
            }
            string msg = $"Game status is {game.GameStatus}, Number of guesses remaining is {game.NumOfTriesRemaining}, Answer is {game.Answer}";
            Assert.IsTrue(game.GameStatus == GameStatusEnum.Losing && game.NumOfTriesRemaining == 0 && game.Answer == game.Word);
            TestContext.WriteLine(msg);
        }
        [Test]
        public void CalculateScorePointsTest()
        {
            Game game = new Game();
            game.StartGame();
            int scorebefore = Game.Score;
            var wordletters = game.Word.Distinct();
            foreach (var letter in wordletters)
            {
                game.HandleLetterSelection(letter.ToString());
            }
            int scoreafter = Game.Score;
            string msg = $"Score before winning is {scorebefore}, score after winning is {scoreafter}";
            Assert.IsTrue(scoreafter > scorebefore);
            TestContext.WriteLine(msg);
        }
        [Test]
        public void HandleLetterSelectionNotPlayingStatusTest()
        {
            Game game = new Game();
            game.StartGame();
            List<string> lstletters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToList();
            List<string> lstlettersinword = game.Word.Distinct().Select(c => c.ToString()).ToList();
            List<string> lettersnotinword = lstletters.Where(l => !lstlettersinword.Contains(l)).ToList();
            foreach (var letter in lstlettersinword)
            {
                game.HandleLetterSelection(letter.ToString());
            }
            int numoftriesremaininguponwin = game.NumOfTriesRemaining;
            game.HandleLetterSelection(lettersnotinword[0]);
            string msg = $"Game status is {game.GameStatus}, Used letters is {game.UsedLetters}, " +
                $"Number of tries remaining is {game.NumOfTriesRemaining} vs. previous number {numoftriesremaininguponwin}";
            Assert.IsTrue(game.GameStatus == GameStatusEnum.Winning && !game.UsedLetters.Contains(lettersnotinword[0][0])
                && game.NumOfTriesRemaining == numoftriesremaininguponwin);
            TestContext.WriteLine(msg);
        }
    }
}