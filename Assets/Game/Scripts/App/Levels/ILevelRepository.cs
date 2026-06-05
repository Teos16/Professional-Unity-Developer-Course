namespace Game.App
{
    public interface ILevelRepository
    {
        bool LoadLevel(out int level);

        void Save(int level);
    }
}