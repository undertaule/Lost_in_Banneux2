using System;
using UnityEngine;

namespace Damage
{
    public class TriggerDamage : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.TryGetComponent(out IDamageable damageable)) return;
        
            damageable.TakeDamage(1, Vector3.zero);
        }
    }
}
