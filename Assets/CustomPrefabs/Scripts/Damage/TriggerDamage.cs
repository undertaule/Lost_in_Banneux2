using System;
using UnityEngine;

namespace Damage
{
    public class TriggerDamage : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
        
            damageable.TakeDamage(1, Vector3.zero);
        }
    }
}
