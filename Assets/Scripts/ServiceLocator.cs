namespace Services
{
    public static class ServiceLocator
    {
        private static readonly ServiceContext instance;

        static ServiceLocator()
        {
            instance = new ServiceContext();
        }

        public static bool TryGetService<T>(out T service)
        {
            return instance.TryGetService(out service);
        }

        public static T GetService<T>()
        {
            return instance.GetService<T>();
        }

        public static T[] GetServices<T>()
        {
            return instance.GetServices<T>();
        }

        public static void AddService(object service)
        {
            instance.AddService(service);
        }

        public static void RemoveService(object service)
        {
            instance.RemoveService(service);
        }
    }
}