using UnityEngine;

namespace Shmup {
    [CreateAssetMenu(fileName = "enemyType", menuName = "Shmup/Type", order = 0)]
    public class EnemyType : ScriptableObject {

        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;

    }
}
