namespace FullStack.Interfaces
{
    public interface IEventStore
    {
        Task Save<T>(T evento, int level) where T : class;
    }
}
