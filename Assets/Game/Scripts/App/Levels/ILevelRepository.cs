namespace Game.App
{
    public interface ILevelRepository
    {
        bool Load(out int level);

        void Save(int level);
    }
}