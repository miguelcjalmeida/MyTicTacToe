namespace MyTicTacToe.Game
{
    public interface ITicTacToeGame
    {
        bool IsGameOver();
        PlayerEnum GetWinner();
        PlayerEnum CurrentPlayer { get; }
        PlayerEnum Enemy { get; }
        ITicTacToeGame PlayAt(int row, int col);
        ITicTacToeBoard Board { get; }
    }
}
