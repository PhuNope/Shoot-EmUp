using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shmup {
    public class BossStage : MonoBehaviour {

        public List<Enemy> enemySystems;
        public bool IsBossInvulnerable = true;

        private void Awake() {
            foreach (Enemy enemy in enemySystems) {
                enemy.gameObject.SetActive(false);
            }
        }

        public void InitializeStage() {
            foreach (Enemy enemy in enemySystems) {
                enemy.gameObject.SetActive(true);
            }
        }

        public bool IsStageComplete() {
            return enemySystems.All(enemy => enemy == null || !(enemy.GetHealthNormalized() > 0));
        }
    }
}
