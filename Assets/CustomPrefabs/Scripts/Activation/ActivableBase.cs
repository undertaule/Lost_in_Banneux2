using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Activation
{
    public abstract class ActivableBase : MonoBehaviour
    {
        private Dictionary<ActivatorBase, bool> activators = new Dictionary<ActivatorBase, bool>();
        protected bool _activated;
    
        public void RegisterActivator(ActivatorBase activator)
        {
            activators.TryAdd(activator, false);
        }

        public void ChangeActivatorState(ActivatorBase activator, bool isActivate)
        {
            if (!activators.ContainsKey(activator)) return;
            
            activators[activator] = isActivate;
        
            TryActivate();
        }

        private void TryActivate()
        {
            if (activators.Any(activator => activator.Value == false) != _activated) return;

            SwitchActivation();
        }

        protected virtual void SwitchActivation()
        {
            _activated = !_activated;
        }
    }
}