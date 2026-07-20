namespace SampleGame
{
    public interface ICommand
    {
        public bool CanExecute();
        public bool Execute();
        public void Cancel();
    }
}