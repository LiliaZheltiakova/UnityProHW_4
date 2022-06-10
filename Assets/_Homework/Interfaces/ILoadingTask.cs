using System.Collections;

namespace Services
{
    public interface ILoadingTask
    {
        public IEnumerator Do();
    }
}