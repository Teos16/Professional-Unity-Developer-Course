namespace SampleGame
{
    public interface IMergeableCommand
    {
        bool TryMerge(ICommand next);
    }
}