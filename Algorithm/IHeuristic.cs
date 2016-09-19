namespace MyTicTacToe.Algorithm
{
    public interface IHeuristic<T>
    {
        double Score(INode<T> node);
    }
}
