using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup {
    public class GameManager : MonoBehaviour {

        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;

        public static GameManager Instance { get; private set; }
        public Player Player => player;

        Player player;
        Boss boss;
        int score;
        float restartTimer = 3f;

        public bool IsGameOver() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0 || boss.GetHealthNormalized() <= 0;
        // TODO Add a next level instead of game over when boss dies

        private void Awake() {
            //if (Instance == null) {
            Instance = this;
            //    DontDestroyOnLoad(gameObject);
            //}
            //else {
            //    Destroy(gameObject);
            //}

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }

        private void Update() {
            if (IsGameOver()) {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false) {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0f) {
                    Loader.Load(mainMenuScene);
                }
            }
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;


    }
}
