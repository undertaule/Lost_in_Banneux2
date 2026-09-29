using UnityEngine;

namespace Activation
{
    public abstract class ActivatorBase : MonoBehaviour
    {
        [Header("Activator Settings")]
        [SerializeField] private ActivableBase[] activables;
        private bool _isActive;

        protected virtual void Start()
        {
            foreach (var activable in activables)
            {
                activable.RegisterActivator(this);
            }
        }

        protected virtual void ChangeState(bool isActive)
        {
            _isActive = isActive;
        
            foreach (var activable in activables)
            {
                activable.ChangeActivatorState(this, _isActive);
            }
        }
    }
}
