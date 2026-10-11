using Pattanakan_Methavikul.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pattanakan_Methavikul.UIs
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private AudioClip endSound;
        private AudioSource audioSource;

        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            scoreText.text = $"Final Score: {gameManager.Score}";
            audioSource.PlayOneShot(endSound);
        }

        public void Retry()
        {
            // Find game manager in that scene then reload it
            string stageSceneName = gameManager.gameObject.scene.name;
            SceneManager.LoadSceneAsync(stageSceneName, LoadSceneMode.Single);
        }
    }
}
