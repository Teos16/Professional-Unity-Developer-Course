namespace Modules.Repositories
{
    public interface IVersionProvider
    {
        int GetCurrentVersion();
        int GetNextVersion();
    }
}