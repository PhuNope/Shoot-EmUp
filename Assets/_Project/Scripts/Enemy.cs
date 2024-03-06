using System;
using UnityEngine;
using UnityEngine.Events;

namespace Shmup {
    public class Enemy : Plane {

        [SerializeField] GameObject explosionPrefab;

        public UnityEvent OnSystemDestroyed;

        protected override void Die() {
            GameManager.Instance.AddScore(10);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
