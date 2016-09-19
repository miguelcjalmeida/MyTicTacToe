namespace MyTicTacToe.Algorithm
{
    public interface IEvaluationResult<T>
    {
        double Score { get; }
        INode<T> BestNode { get; }
    }
}
