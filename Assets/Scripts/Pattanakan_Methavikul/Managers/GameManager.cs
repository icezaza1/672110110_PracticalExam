using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pattanakan_Methavikul.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float startingTime = 60f;

        public int Score { get; private set; }
        public float TimeRemaining { get; private set; }

        public event Action<int> ScoreChanged;
        public event Action<float> TimeChanged;

        private bool timerRunning;
        private bool gameEnded = false;

        private void Awake()
        {
            TimeRemaining = startingTime;
        }

        private void Start()
        {
            StartTimer();
        }
        private void Update()
        {
            if (!timerRunning || TimeRemaining <= 0f || gameEnded)
                return;

            TimeRemaining = Mathf.Max(0f, TimeRemaining - Time.deltaTime);
            TimeChanged?.Invoke(TimeRemaining);

            if (TimeRemaining <= 0f)
            {
                if (Score >= 10000)
                {
                    EndGame(true);
                }
                else
                {
                    EndGame(false);
                }
            }
        }

        public void StartTimer() => timerRunning = true;

        public void Apply(ItemEffectScriptableObjects effect)
        {
            if (effect == null) return;

            Score += effect.scoreChange;
            TimeRemaining = Mathf.Max(0f, TimeRemaining + effect.timeChange);

            ScoreChanged?.Invoke(Score);
            TimeChanged?.Invoke(TimeRemaining);
        }

        public void EndGame(bool win)
        {
            timerRunning = false;
            gameEnded = true;
            if (win)
                SceneManager.LoadSceneAsync("WinScene", LoadSceneMode.Additive);
            else
                SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
        }
    }
}
