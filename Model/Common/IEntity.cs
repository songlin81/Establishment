namespace Model.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
