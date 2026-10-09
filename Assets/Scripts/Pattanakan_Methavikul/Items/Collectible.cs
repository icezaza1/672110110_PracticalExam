using Pattanakan_Methavikul.Managers;
using UnityEngine;

namespace Pattanakan_Methavikul.Items
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private ItemEffectScriptableObjects effect;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            gameManager.Apply(effect);
            Destroy(gameObject);
        }
    }
}