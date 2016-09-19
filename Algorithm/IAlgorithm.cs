namespace MyTicTacToe.Algorithm
{
    public interface IAlgorithm<T>
    {
        IEvaluationResult<T> Evaluate(INode<T> node);
    }
}
