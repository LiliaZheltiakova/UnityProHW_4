using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Services
{
    public class ManagerToUpdate : IManagerToUpdate
    {
        public void OnUpdate()
        {
            Debug.Log("OnUpdate");
        }
    }
}