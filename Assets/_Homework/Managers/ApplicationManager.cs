using System;
using System.Collections;
using UnityEngine;

namespace Services
{
    public class ApplicationManager : MonoBehaviour
    {
        public event Action UpdateEvent;

        private void Update()
        {
            this.UpdateEvent?.Invoke();
        }
    }
}