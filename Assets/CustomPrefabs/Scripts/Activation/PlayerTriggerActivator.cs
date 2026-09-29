using System;
using UnityEngine;

namespace Activation
{
    public class PlayerTriggerActivator : ActivatorBase
    {
        [SerializeField] private bool stayActivated;
        [SerializeField] private Material activateMaterial;
        [SerializeField] private Material inactivateMaterial;

        private MeshRenderer _mesh;

        protected override void Start()
        {
            base.Start();
            _mesh = GetComponent<MeshRenderer>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            ChangeState(true);
        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player") || stayActivated) return;
        
            ChangeState(false);
        }

        protected override void ChangeState(bool state)
        {
            base.ChangeState(state);
            
            _mesh.material = state ? activateMaterial : inactivateMaterial;
        }
    }
}
