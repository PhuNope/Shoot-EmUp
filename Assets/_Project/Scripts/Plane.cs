﻿using UnityEngine;

namespace Shmup {
    public abstract class Plane : MonoBehaviour {

        [SerializeField] int maxHealth;
        int health;

        protected virtual void Awake() {
            health = maxHealth;
        }

        public void SetmaxHealth() => health = maxHealth;

        public void TakeDamage(int amount) {
            health -= amount;
            if (health < 0) {
                Die();
            }
        }

        public void AddHealth(int amount) {
            health += amount;
            if (health > maxHealth) {
                health = maxHealth;
            }
        }

        public float GetHealthNormalized() => health / maxHealth;

        protected abstract void Die();
    }
}
