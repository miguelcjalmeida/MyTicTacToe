using System;

namespace MyTicTacToe.Algorithm.MinMax
{
    public class MinMaxAlgorithm<T> : IAlgorithm<T>
    {
        private readonly int _depth;
        private readonly IHeuristic<T> _heuristic;

        public MinMaxAlgorithm(IHeuristic<T> heuristic)
        {
            _heuristic = heuristic;
            _depth = -1;
        }

        public MinMaxAlgorithm(IHeuristic<T> heuristic, int depth)
        {
            _heuristic = heuristic;
            _depth = depth;
        }

        public IEvaluationResult<T> Evaluate(INode<T> node)
        {
            return RecursiveEvaluate(node, _depth);
        }

        public IEvaluationResult<T> RecursiveEvaluate(INode<T> node, int depth)
        {
            var results = new EvaluationResult<T>();

            if (depth == 0 || node.IsTerminal())
            {
                results.Score = _heuristic.Score(node);
                return results;
            }

            results.Score = double.MinValue;

            foreach(var childNode in node.GetChildren())
            {
                var evaluation = RecursiveEvaluate(childNode, depth - 1);

                if(-evaluation.Score > results.Score)
                {
                    results.Score = -evaluation.Score;
                    results.BestNode = childNode;
                }
            }

            return results;
        } 
    }
}
