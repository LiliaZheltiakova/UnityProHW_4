using System;
using UnityEditor;
using UnityEngine;

namespace Services
{
    [CreateAssetMenu(
        fileName = "ScriptableServiceLoader",
        menuName = "Service Locator/New ScriptableServiceLoader"
    )]
    public class ScriptableServiceLoader : ScriptableObject
    {
        [Space]
        [SerializeField]
        private bool editorMode;
        
        [SerializeField]
        private MonoScript[] releaseScripts;

        [SerializeField]
        private MonoScript[] editorScripts;

        public virtual object[] LoadServices()
        {
#if UNITY_EDITOR
            object[] result;
            if (this.editorMode)
            {
                result = LoadServices(this.editorScripts);
            }
            else
            {
                result = LoadServices(this.releaseScripts);
            }
#else
            result = LoadServices(this.scripts);
#endif
            return result;
        }

        protected static object[] LoadServices(MonoScript[] scripts)
        {
            var count = scripts.Length;
            var result = new object[count];
            for (var i = 0; i < count; i++)
            {
                var script = scripts[i];
                result[i] = CreateService(script);
            }

            return result;
        }

        private static object CreateService(MonoScript script)
        {
            var type = script.GetClass();
            return Activator.CreateInstance(type);
        }
    }
}