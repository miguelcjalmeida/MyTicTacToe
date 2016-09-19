using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTicTacToe.Game
{
    public class TicTacToeBoard : ITicTacToeBoard
    {
        public TicTacToeBoard(PlayerEnum[][] cells, int size)
        {
            Cells = cells;
            Size = size;
        }

        public int Size { get; private set; }

        public PlayerEnum[][] Cells { get; set; }

        public IEnumerable<TicTacToeCell> GetEmptyCells()
        {
            return Cells.SelectMany((row, rowIndex) 
                => row.Select((cell, cellIndex) => BuildCell(cell, rowIndex, cellIndex))
                      .Where(x => x.Player == PlayerEnum.None));
        }

        public void SetCellPlayer(PlayerEnum player, int row, int column)
        {
            Cells[row][column] = player;
        }

        public bool IsPlayerInLine(PlayerEnum player, int minimumInLine)
        {
            for(var i=0; i< Size; i++)
            {
                if (CountPlayersInAColumn(player, i) >= minimumInLine)
                    return true;

                if (CountPlayersInARow(player, i) >= minimumInLine)
                    return true;
            }

            return CountPlayersInDiagonal(player) >= minimumInLine;
        }

        public bool HasEmptyCells()
        {
            return Cells.Any(x => x.Contains(PlayerEnum.None));
        }

        public object Clone()
        {
            var newCells = (PlayerEnum[][])Cells.Clone();

            for (var i=0; i<newCells.Length; i++)
                newCells[i] = (PlayerEnum[])Cells[i].Clone();

            return new TicTacToeBoard(newCells, Size);
        }

        private TicTacToeCell BuildCell(PlayerEnum player, int row, int column)
        {
            return new TicTacToeCell
            {
                Row = row,
                Column = column,
                Player = player
            };
        }

        private int CountPlayersInAColumn(PlayerEnum player, int column)
        {
            var count = 0;

            for (var i = 0; i < Size; i++)
            {
                if (Cells[i][column] == player)
                    count++;
            }
            return count;
        }

        private int CountPlayersInARow(PlayerEnum player, int row)
        {
            var count = 0;

            for (var i = 0; i < Size; i++)
            {
                if (Cells[row][i] == player)
                    count++;
            }
            return count;
        }

        private int CountPlayersInDiagonal(PlayerEnum player)
        {
            var count1 = 0;
            var count2 = 0;

            for (var i = 0; i < Size; i++)
            {
                if (Cells[i][i] == player)
                    count1++;

                if (Cells[i][Size - i - 1] == player)
                    count2++;
            }

            return Math.Max(count1, count2);
        }
    }
}
