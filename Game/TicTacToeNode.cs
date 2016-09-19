using System;
using System.Collections.Generic;
using MyTicTacToe.Algorithm;
using System.Linq;

namespace MyTicTacToe.Game
{
    public class TicTacToeNode : INode<ITicTacToeGame>
    {
        public TicTacToeNode(ITicTacToeGame value)
        {
            Value = value;
        }

        public ITicTacToeGame Value { get; private set; }

        IEnumerable<INode<ITicTacToeGame>> INode<ITicTacToeGame>.GetChildren()
        {
            var emptyCells = Value.Board.GetEmptyCells();

            return emptyCells.Select(x => 
                (INode<ITicTacToeGame>) new TicTacToeNode(Value.PlayAt(x.Row, x.Column)));
        }

        public bool IsTerminal()
        {
            return Value.IsGameOver();
        }
    }
}
