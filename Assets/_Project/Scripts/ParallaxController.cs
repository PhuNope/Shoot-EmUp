using UnityEngine;

namespace Shmup {
    public class ParallaxController : MonoBehaviour {

        [SerializeField] Transform[] background; // Array of background layers
        [SerializeField] float smoothing = 10f; // How smooth the parallax effect is
        [SerializeField] float multiplier = 15f; // how much the parallax effect increments per layer

        Transform cam; // Reference to the main camera
        Vector3 previousCamPos; // Position of the camera in the previous frame

        private void Awake() {
            cam = Camera.main.transform;
        }

        private void Start() {
            previousCamPos = cam.position;
        }

        private void Update() {
            // Iterate through each background layer
            for (int i = 0; i < background.Length; i++) {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = background[i].position.y + parallax;

                var targetPosition = new Vector3(background[i].position.x, targetY, background[i].position.z);

                background[i].position = Vector3.Lerp(background[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
