using Pattanakan_Methavikul.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pattanakan_Methavikul.UIs
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private string mainSceneName = "Stage_1";

        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        private void Start()
        {
            scoreText.text = $"Final Score: {gameManager.Score}";
        }

        public void Retry()
        {
            // Remove the currently loaded result scene.
            SceneManager.UnloadSceneAsync(gameObject.scene);

            // Reload the main stage as a fresh run.
            SceneManager.LoadSceneAsync(mainSceneName, LoadSceneMode.Single);
        }
    }
}