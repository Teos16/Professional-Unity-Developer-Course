namespace Atomic.Entities
{
    public readonly struct ValueKey<T>
    {
        public readonly int Id;

        public static implicit operator ValueKey<T>(int name) => new(name);
        public static implicit operator ValueKey<T>(string name) => new(name);

        public ValueKey(string name) => Id = EntityNames.NameToId(name);
        public ValueKey(int id) => this.Id = id;

        public override string ToString() => EntityNames.IdToName(Id);
    }


    // public static implicit operator ValueKey<T>(ValueKey<IEntity, T> it) => new(it.Id);
    // public static implicit operator ValueKey<IEntity, T>(ValueKey<T> it) => new(it.Id);

    // public readonly struct ValueKey<E, T> where E : IEntity
    // {
    //     public readonly int Id;
    //     
    //     public static implicit operator ValueKey<E, T>(int name) => new(name);
    //     public static implicit operator ValueKey<E, T>(string name) => new(name);
    //     
    //
    //     public ValueKey(string name) => Id = EntityKeyStore.NameToId(name);
    //     public ValueKey(int id) => this.Id = id;
    //
    //     public override string ToString() => EntityKeyStore.IdToName(Id);
    // }
}