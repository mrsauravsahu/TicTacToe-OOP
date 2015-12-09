namespace TicTacToe
{
    class GameManager
    {
        static void Main(string[] args)
        {
            Game game = new Game(2, 3, OutputType.File);
            game.Play();
        }
    }
}
