using DG.Tweening;
using UnityEngine;

namespace Activation
{
    public class DoorActivable : ActivableBase
    {
        [Header("Door Settings")]
        [SerializeField] private float openTime;
        [SerializeField] private float closeTime;
        [SerializeField] private Vector3 openRotation;
        private Vector3 _closeRotation;

        private void Start()
        {
            _closeRotation = transform.rotation.eulerAngles;
        }

        protected override void SwitchActivation()
        {
            base.SwitchActivation();
            
            transform.DOKill();
            
            if (_activated)
                transform.DORotate(openRotation, openTime);
            else
                transform.DORotate(_closeRotation, closeTime);
        }
    }
}
