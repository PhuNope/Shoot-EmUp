﻿using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Shmup {
    public class MainMenuUI : MonoBehaviour {

        [SerializeField] SceneReference startingLevel;
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;

        private void Awake() {
            playButton.onClick.AddListener(() => Loader.Load(startingLevel));
            quitButton.onClick.AddListener(() => Helpers.QuitGame());
            Time.timeScale = 1.0f;
        }
    }
}
