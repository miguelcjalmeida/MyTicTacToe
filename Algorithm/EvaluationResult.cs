using System;

namespace MyTicTacToe.Algorithm
{
    public class EvaluationResult<T> : IEvaluationResult<T>
    {
        public INode<T> BestNode { get; set; }
        public double Score { get; set; }
    }
}
