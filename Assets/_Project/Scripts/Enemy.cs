using System;
using UnityEngine.Events;

namespace Shmup {
    public class Enemy : Plane {
        public UnityEvent OnSystemDestroyed;

        protected override void Die() {
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
