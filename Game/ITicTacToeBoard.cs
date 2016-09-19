using System;
using System.Collections.Generic;

namespace MyTicTacToe.Game
{
    public interface ITicTacToeBoard : ICloneable
    {
        IEnumerable<TicTacToeCell> GetEmptyCells();
        void SetCellPlayer(PlayerEnum player, int row, int column);
        bool IsPlayerInLine(PlayerEnum player, int minimumInLine);
        bool HasEmptyCells();
        int Size { get; }
        PlayerEnum[][] Cells { get; }
    }
}
