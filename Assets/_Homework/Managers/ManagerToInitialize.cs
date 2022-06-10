using System.Collections;
using UnityEngine;

namespace Services
{
    public class ManagerToInitialize : IInitializable
    {
        public void Initialize()
        {
            Debug.Log("Initialize");
        }
    }
}