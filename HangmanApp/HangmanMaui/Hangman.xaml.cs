using HangmanSystem;
namespace HangmanMaui;


public partial class Hangman : ContentPage
{
    Game activegame;
    List<Game> lstgame = new() { new Game(), new Game(), new Game() };
    public Hangman()
    {
        InitializeComponent();
        Game1Rb.BindingContext = lstgame[0];
        Game2Rb.BindingContext = lstgame[1];
        Game3Rb.BindingContext = lstgame[2];
        activegame = lstgame[0];
        BindingContext = activegame;
    }

    private void btnNewGame_Clicked(object sender, EventArgs e)
    {
        activegame.StartGame();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        activegame.HandleLetterSelection(btn.Text);
    }

    private void btnGiveUp_Clicked(object sender, EventArgs e)
    {
        activegame.GameStatus = GameStatusEnum.GiveUp;
        activegame.EndGame();
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        activegame.GameStatus = GameStatusEnum.Start;
        activegame.EndGame();
    }

    private void Game_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton Rb = (RadioButton)sender;
        if (Rb.IsChecked && Rb.BindingContext != null)
        {
            activegame = (Game)Rb.BindingContext;
            BindingContext = activegame;
        }
        if (activegame.GameStatus != GameStatusEnum.Playing)
        {
            activegame.RefreshGame();
        }

    }
}