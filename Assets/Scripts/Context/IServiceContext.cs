namespace Services
{
    public interface IServiceContext
    {
        bool TryGetService<T>(out T service);

        T GetService<T>();

        T[] GetServices<T>();

        void AddService(object service);

        void RemoveService(object service);
    }
}