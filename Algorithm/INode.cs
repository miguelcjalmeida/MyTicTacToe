using System.Collections.Generic;

namespace MyTicTacToe.Algorithm
{
    public interface INode<T>
    {
        T Value { get; }
        IEnumerable<INode<T>> GetChildren();
        bool IsTerminal();
    }
}
