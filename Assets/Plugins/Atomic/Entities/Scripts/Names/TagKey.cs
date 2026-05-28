namespace Atomic.Entities
{
    public readonly struct TagKey
    {
        public readonly int Id;
        
        public static implicit operator TagKey(int name) => new(name);
        public static implicit operator TagKey(string name) => new(name);

        public TagKey(string name) => Id = EntityNames.NameToId(name);
        public TagKey(int id) => this.Id = id;

        public override string ToString() => EntityNames.IdToName(Id);
    }
    
    // public readonly struct TagKey<E> where E : IEntity
    // {
    //     public readonly int Id;
    //     
    //     public static implicit operator TagKey<E>(int name) => new(name);
    //     public static implicit operator TagKey<E>(string name) => new(name);
    //
    //     public TagKey(string name) => Id = EntityKeyStore.NameToId(name);
    //     public TagKey(int id) => this.Id = id;
    //
    //     public override string ToString() => EntityKeyStore.IdToName(Id);
    // }
}