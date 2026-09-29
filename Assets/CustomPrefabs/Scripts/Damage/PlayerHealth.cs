using System;
using System.Collections;
using Damage;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Player
{
    /*[RequireComponent(typeof(CharacterController))]*/
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float maxHealth = 1;
        [SerializeField] private float currentHealth = 1;
        [SerializeField] private float respawnDelay = 2;
        private bool _isDead;

        /// <summary>
        /// Restart the level when the player takes damage.
        /// </summary>
        public void TakeDamage(int damage, Vector3 hitPoint)
        {
            if (_isDead) return;
            currentHealth -= damage;

            if (currentHealth > 0) return;
            Die();
        }

        private void Die()
        {
            _isDead = true;
            StartCoroutine(Reset());
            onDeath?.Invoke();
        }
        private IEnumerator Reset()
        {
            yield return new WaitForSeconds(respawnDelay);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public UnityEvent onDeath;
    }
}