using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Shmup {
    public class Boss : MonoBehaviour {

        [SerializeField] float maxHealth = 100f;
        [SerializeField] GameObject explosionPrefab;
        float health;

        Collider bossCollider;

        public List<BossStage> Stages;
        int currentStage = 0;

        public event Action OnHealthChange;

        private void Awake() {
            bossCollider = GetComponent<Collider>();
        }

        private void Start() {
            health = maxHealth;
            bossCollider.enabled = true;

            InitializeStage();
        }

        public float GetHealthNormalized() => health / maxHealth;

        void CheckStageComplete() {
            if (Stages[currentStage].IsStageComplete()) {
                AdvanceToNextStage();
            }
        }

        void AdvanceToNextStage() {
            currentStage++;
            bossCollider.enabled = true;

            if (currentStage < Stages.Count) {
                InitializeStage();
            }
        }

        private void InitializeStage() {
            Stages[currentStage].InitializeStage();

            foreach (var system in Stages.SelectMany(stage => stage.enemySystems)) {
                system.OnSystemDestroyed.AddListener(CheckStageComplete);
            }

            bossCollider.enabled = !Stages[currentStage].IsBossInvulnerable;
        }

        private void OnCollisionEnter(Collision collision) {
            health -= 10f;
            OnHealthChange?.Invoke();

            if (health <= 0) {
                BossDefeated();
            }
        }

        private void BossDefeated() {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
