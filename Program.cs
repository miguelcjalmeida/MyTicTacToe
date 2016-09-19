using MyTicTacToe.Algorithm;
using MyTicTacToe.Algorithm.MinMax;
using MyTicTacToe.Game;
using System;

namespace MyTicTacToe
{
    public class Program
    {
        private const int BOARD_SIZE = 4;

        public static void Main(string[] args)
        {
            var engine = new MinMaxAlgorithm<ITicTacToeGame>(new TicTacToeHeuristic(), 5);

            while (true)
            {
                var gamePosition = GenerateEmptyGame();

                gamePosition = KeepPlayingUntilEndOfGame(engine, gamePosition);

                Console.ReadLine();
            }
        }

        private static INode<ITicTacToeGame> GenerateEmptyGame()
        {
            PlayerEnum[][] cells = new PlayerEnum[BOARD_SIZE][];

            for (var i = 0; i < BOARD_SIZE; i++)
            {
                cells[i] = new PlayerEnum[BOARD_SIZE];

                for (var j = 0; j < BOARD_SIZE; j++)
                {
                    cells[i][j] = PlayerEnum.None;
                }
            }

            return new TicTacToeNode(new TicTacToeGame(PlayerEnum.Player1, new TicTacToeBoard(cells, BOARD_SIZE)));
        }

        private static INode<ITicTacToeGame> KeepPlayingUntilEndOfGame(MinMaxAlgorithm<ITicTacToeGame> engine, INode<ITicTacToeGame> gamePosition)
        {
            while (true)
            {
                var currentPositionEvaluation = engine.Evaluate(gamePosition);

                PrintGame(gamePosition.Value, currentPositionEvaluation.Score);

                if (currentPositionEvaluation.BestNode == null)
                    break;

                var positionToPlay = ReadNumber();

                if (positionToPlay != -1)
                {
                    var row = Convert.ToInt32(Math.Floor((double)(positionToPlay / BOARD_SIZE)));
                    var column = positionToPlay % BOARD_SIZE;

                    gamePosition = new TicTacToeNode(gamePosition.Value.PlayAt(row, column));
                    continue;
                }

                gamePosition = currentPositionEvaluation.BestNode;
            }

            return gamePosition;
        }

        public static void PrintGame(ITicTacToeGame game, double score)
        {
            Console.Clear();

            Console.WriteLine(game.CurrentPlayer.ToString() + " Turn");
            Console.WriteLine();

            for (var i = 0; i < game.Board.Size; i++)
            {
                for (var j = 0; j < game.Board.Size; j++)
                {
                    var playerSymbol = GetPlayerSymbol(game.Board.Cells[i][j]);
                    Console.Write("{0} ",  playerSymbol);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Player 1 Score: " +  (game.CurrentPlayer == PlayerEnum.Player1 ? score : -score));
            Console.WriteLine("Player 2 Score: " + (game.CurrentPlayer == PlayerEnum.Player2 ? score : -score));
        }

        private static string GetPlayerSymbol(PlayerEnum player)
        {
            if (player == PlayerEnum.Player1)
                return "x";

            if (player == PlayerEnum.Player2)
                return "o";

            return "_";
        }

        private static int ReadNumber()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
    }
}
