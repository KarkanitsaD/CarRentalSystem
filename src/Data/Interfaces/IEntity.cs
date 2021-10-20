namespace Data.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}