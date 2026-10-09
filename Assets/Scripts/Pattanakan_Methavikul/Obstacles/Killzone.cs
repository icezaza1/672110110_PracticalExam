using Pattanakan_Methavikul.Managers;
using UnityEngine;

namespace Pattanakan_Methavikul.Obstacles
{
    public class Killzone : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            gameManager.EndGame(false);
        }
    }
}