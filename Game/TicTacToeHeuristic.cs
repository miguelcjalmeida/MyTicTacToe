using MyTicTacToe.Algorithm;

namespace MyTicTacToe.Game
{
    public class TicTacToeHeuristic : IHeuristic<ITicTacToeGame>
    {
        public double Score(INode<ITicTacToeGame> node)
        {
            var winner = node.Value.GetWinner();

            if (winner == node.Value.CurrentPlayer)
                return 1;

            if (winner == node.Value.Enemy)
                return -1;

            var sum = 0.0;

            if (node.Value.Board.Cells[0][0] == node.Value.CurrentPlayer)
                sum += 0.1;
            if (node.Value.Board.Cells[0][3] == node.Value.CurrentPlayer)
                sum += 0.1;
            if (node.Value.Board.Cells[3][0] == node.Value.CurrentPlayer)
                sum += 0.1;
            if (node.Value.Board.Cells[3][3] == node.Value.CurrentPlayer)
                sum += 0.1;

            /*
            if (node.Value.Board.Cells[0][0] == node.Value.Enemy)
                sum -= 0.1;
            if (node.Value.Board.Cells[0][3] == node.Value.Enemy)
                sum -= 0.1;
            if (node.Value.Board.Cells[3][0] == node.Value.Enemy)
                sum -= 0.1;
            if (node.Value.Board.Cells[3][3] == node.Value.Enemy)
                sum -= 0.1;
            */
            return sum;
        }
    }
}
