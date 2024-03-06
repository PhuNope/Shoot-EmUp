using UnityEngine;
using UnityEngine.UI;

namespace Shmup {
    public class BossHealthBar : MonoBehaviour {

        [SerializeField] Boss boss;
        [SerializeField] Image healthBar;

        private void Awake() {
            boss.OnHealthChange += Boss_OnHealthChange;
        }

        private void Boss_OnHealthChange() {
            healthBar.fillAmount = boss.GetHealthNormalized();
        }
    }
}
