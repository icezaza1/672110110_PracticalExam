using System;
using UnityEngine;

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
            if (!timerRunning || TimeRemaining <= 0f)
                return;

            TimeRemaining = Mathf.Max(0f, TimeRemaining - Time.deltaTime);
            TimeChanged?.Invoke(TimeRemaining);

            if (TimeRemaining <= 0f)
                timerRunning = false;
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
    }
}
