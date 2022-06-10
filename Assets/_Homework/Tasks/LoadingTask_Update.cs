using System.Collections;
using UnityEngine;

namespace Services
{
    public class LoadingTask_Update : ILoadingTask
    {
        public IEnumerator Do()
        {
            var managers = ServiceLocator.GetServices<IManagerToUpdate>();
            var appManager = ServiceLocator.GetService<ApplicationManager>();
            foreach (var manager in managers)
            {
                appManager.UpdateEvent += manager.OnUpdate;
            }
            yield return null;
        }
    }
}