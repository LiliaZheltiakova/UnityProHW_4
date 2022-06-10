using System.Collections;
using UnityEngine;

namespace Services
{
    public class ConfigManager : MonoBehaviour
    {
        [SerializeField] private ConfigRequestList requestList;
        private IEnumerator Start()
        {
            foreach (var config in requestList.GetConfigs())
            {
                yield return config.Do();
            }
        }
    }
}