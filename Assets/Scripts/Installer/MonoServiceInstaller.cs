using UnityEngine;

namespace Services
{
    [AddComponentMenu("Service Locator/Mono Service Installer")]
    public sealed class MonoServiceInstaller : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private MonoBehaviour[] monoServices;

        [Space]
        [SerializeField]
        private ScriptableServiceLoader[] serviceLoaders;
        
        private void Awake()
        {
            this.InstallServicesFromBehaviours();
            this.InstallServicesFromLoaders();
        }

        private void InstallServicesFromBehaviours()
        {
            for (int i = 0, count = this.monoServices.Length; i < count; i++)
            {
                var service = this.monoServices[i];
                ServiceLocator.AddService(service);
            }   
        }

        private void InstallServicesFromLoaders()
        {
            for (int i = 0, count = this.serviceLoaders.Length; i < count; i++)
            {
                var serviceLoader = this.serviceLoaders[i];
                var services = serviceLoader.LoadServices();
                for (int j = 0, length = services.Length; j < length; j++)
                {
                    var service = services[j];
                    ServiceLocator.AddService(service);
                }
            }   
        }
    }
}