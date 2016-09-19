namespace MyTicTacToe.Game
{
    public class TicTacToeGame : ITicTacToeGame
    {
        public TicTacToeGame(PlayerEnum currentTurnPlayer, ITicTacToeBoard board)
        {
            CurrentPlayer = currentTurnPlayer;
            Board = board;
        }

        public ITicTacToeBoard Board { get; private set; }

        public PlayerEnum CurrentPlayer { get; private set; }

        public PlayerEnum Enemy
        {
            get
            {
                return CurrentPlayer == PlayerEnum.Player1 ? PlayerEnum.Player2 : PlayerEnum.Player1;
            }
        }

        public PlayerEnum GetWinner()
        {
            if (Board.IsPlayerInLine(CurrentPlayer, Board.Size))
                return CurrentPlayer;

            if (Board.IsPlayerInLine(Enemy, Board.Size))
                return Enemy;

            return PlayerEnum.None;
        }

        public bool IsGameOver()
        {
            return !Board.HasEmptyCells() || GetWinner() != PlayerEnum.None;
        }

        public ITicTacToeGame PlayAt(int row, int col)
        {
            var newBoard = (ITicTacToeBoard)Board.Clone();
            newBoard.SetCellPlayer(CurrentPlayer, row, col);
            return new TicTacToeGame(Enemy, newBoard);
        }
    }
}
