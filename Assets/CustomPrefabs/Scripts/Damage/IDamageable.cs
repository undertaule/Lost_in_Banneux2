using UnityEngine;

namespace Damage
{
    public interface IDamageable
    {
        void TakeDamage(int damage, Vector3 hitPoint);
    }
}