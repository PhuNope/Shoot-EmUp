using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shmup {
    public class EnemySpawner : MonoBehaviour {

        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        private void OnValidate() {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Start() {
            enemyFactory = new EnemyFactory();
        }

        private void Update() {
            spawnTimer += Time.deltaTime;

            if (enemiesSpawned < maxEnemies && spawnTimer >= spawnnInterval) {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        private void SpawnEnemy() {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];

            // TODO: Possible optimization - pool enemies
            GameObject enemy = enemyFactory.CreateEnemy(enemyType, spline);
            enemiesSpawned++;
        }
    }
}
