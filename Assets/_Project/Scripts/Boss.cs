using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Shmup {
    public class Boss : MonoBehaviour {

        [SerializeField] float maxHealth = 100f;
        float health;

        Collider bossCollider;

        public List<BossStage> Stages;
        int currentStage = 0;

        private void Awake() {
            bossCollider = GetComponent<Collider>();
        }

        private void Start() {
            health = maxHealth;
            bossCollider.enabled = true;

            foreach (var system in Stages.SelectMany(stage => stage.enemySystems)) {
                system.OnSystemDestroyed.AddListener(CheckStageComplete);
            }

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
            bossCollider.enabled = !Stages[currentStage].IsBossInvulnerable;
        }

        private void OnCollisionEnter(Collision collision) {
            health -= 10f;

            if (health <= 0) {
                BossDefeated();
            }
        }

        private void BossDefeated() {

        }
    }
}
