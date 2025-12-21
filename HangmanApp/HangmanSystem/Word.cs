using gnuciDictionary;

namespace HangmanSystem
{
    public class GameWord
    {
        List<Word> lstwrd = gnuciDictionary.EnglishDictionary.GetAllWords().
                                                Where(w => w.Value.Count() < 11 && w.Value.Count() > 5
                                                                  && !w.Value.Contains("-") && !w.Value.Contains(" ")).ToList();
        string _currentword = "";
        public string CurrentWord
        {
            get => _currentword;
        }

        public int WordLength => CurrentWord.Length;

        public void PickRandomWord()
        {
            Random rdm = new();
            _currentword = lstwrd[rdm.Next(0, lstwrd.Count)].Value.ToUpper();
        }
    }
}
