using System;
using System.Collections.Generic;

namespace Services
{
    public sealed class ServiceContext : IServiceContext
    {
        private readonly List<object> services;

        private readonly List<object> cache;

        public ServiceContext()
        {
            this.services = new List<object>();
            this.cache = new List<object>();
        }

        public T GetService<T>()
        {
            for (int i = 0, count = this.services.Count; i < count; i++)
            {
                var service = this.services[i];
                if (service is T result)
                {
                    return result;
                }
            }
            
            throw new Exception($"Service of type {typeof(T).Name} is not found!");
        }

        public ServiceContext(List<object> services)
        {
            this.services = new List<object>(services);
            this.cache = new List<object>();
        }

        public bool TryGetService<T>(out T result)
        {
            for (int i = 0, count = this.services.Count; i < count; i++)
            {
                var service = this.services[i];
                if (service is T tService)
                {
                    result = tService;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public T[] GetServices<T>()
        {
            this.cache.Clear();
            for (int i = 0, count = this.services.Count; i < count; i++)
            {
                var service = this.services[i];
                if (service is T tService)
                {
                    this.cache.Add(tService);
                }
            }

            var length = this.cache.Count;
            var result = new T[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = (T) this.cache[i];
            }

            return result;
        }

        public void RemoveService(object service)
        {
            this.services.Remove(service);
        }

        public void AddService(object service)
        {
            this.services.Add(service);
        }
    }
}