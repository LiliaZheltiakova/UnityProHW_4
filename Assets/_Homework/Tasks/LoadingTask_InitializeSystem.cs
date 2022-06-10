using System.Collections;
using UnityEngine;

namespace Services
{
    public class LoadingTask_InitializeSystem : ILoadingTask
    {
        public IEnumerator Do()
        {
            var managers = ServiceLocator.GetServices<IInitializable>();
            foreach (var manager in managers)
            {
                manager.Initialize();
            }
            yield break;
        }
    }
}