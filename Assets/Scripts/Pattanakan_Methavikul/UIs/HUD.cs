using Pattanakan_Methavikul.Managers;
using TMPro;
using UnityEngine;

namespace Pattanakan_Methavikul.UIs
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text scoreText;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        private void OnEnable()
        {
            if (gameManager == null) return;

            gameManager.TimeChanged += UpdateTimer;
            gameManager.ScoreChanged += UpdateScore;
            UpdateTimer(gameManager.TimeRemaining);
            UpdateScore(gameManager.Score);
        }

        private void OnDisable()
        {
            if (gameManager != null)
                gameManager.TimeChanged -= UpdateTimer;
        }

        private void UpdateTimer(float seconds)
        {
            int totalSeconds = Mathf.CeilToInt(seconds);
            timerText.text = $"{totalSeconds}";
        }

        private void UpdateScore(int scores)
        {
            scoreText.text = $"Score: {scores}";
        }
    }

}