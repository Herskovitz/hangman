using gnuciDictionary;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangmanWeb.Pages
{
    public class hangman_typescriptModel : PageModel
    {
        public List<string> Words { get; private set; }

        public void OnGet()
        {
            var allWords = EnglishDictionary.GetAllWords();

            Words = EnglishDictionary.GetAllWords()
            .Where(w => w.Value.Count() < 11 && w.Value.Count() > 5
                        && !w.Value.Contains("-") && !w.Value.Contains(" "))
            .Select(w => w.Value)
            .ToList();
        }
    }
}
