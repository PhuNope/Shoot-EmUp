using MEC;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Shmup {
    public class ItemSpawner : MonoBehaviour {

        [SerializeField] Item[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;

        private void Start() {
            Timing.RunCoroutine(SpawnItems());
        }

        private IEnumerator<float> SpawnItems() {
            while (true) {
                yield return Timing.WaitForSeconds(spawnInterval);

                Item item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = (transform.position + Random.insideUnitSphere).With(z: 0) * spawnRadius;
            }
        }
    }
}
