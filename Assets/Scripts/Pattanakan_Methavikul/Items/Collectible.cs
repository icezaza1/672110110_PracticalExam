using Pattanakan_Methavikul.Managers;
using Pattanakan_Methavikul.Player;
using UnityEngine;

namespace Pattanakan_Methavikul.Items
{
    public enum CollectType
    {
        Collision,
        Interaction
    }

    public class Collectible : MonoBehaviour
    {
        [SerializeField] private ItemEffectScriptableObjects effect;
        [SerializeField] private CollectType collectType;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            if (collectType == CollectType.Collision)
            {
                CollectItem();
                return;
            }

            PlayerInteraction playerInteract = other.GetComponent<PlayerInteraction>();
            if (playerInteract != null)
                playerInteract.RegisterNearbyCollectible(this);
        }

        private void OnTriggerExit(Collider other)
        {
            if (collectType != CollectType.Interaction) return;

            PlayerInteraction playerInteract = other.GetComponent<PlayerInteraction>();
            if (playerInteract != null)
                playerInteract.UnregisterNearbyCollectible(this);
        }

        public void CollectItem()
        {
            gameManager.Apply(effect);
            Destroy(gameObject);
        }
    }
}
