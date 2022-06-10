using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Services
{
    [Serializable]
    [CreateAssetMenu(fileName = "RequestingConfig", menuName = "App/Requesting/RequestingConfig")]
    public class ConfigRequestList : ScriptableObject
    { 
        [SerializeField] private List<MonoScript> configs = new List<MonoScript>();
        public List<ILoadingTask> GetConfigs()
        {
            var result = new List<ILoadingTask>();
            foreach (var config in configs)
            {
                result.Add(Activator.CreateInstance(config.GetClass()) as ILoadingTask);
            }
            return result;
        }
    }
}