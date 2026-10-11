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
        private MeshRenderer meshRenderer;
        private Collider myCollider;
        private GameManager gameManager;
        private AudioSource audioSource;
        private bool isCollected = false;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
            audioSource = GetComponent<AudioSource>();
            meshRenderer = GetComponent<MeshRenderer>();
            myCollider = GetComponent<Collider>();

            audioSource.clip = effect.onCollectedSound;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player") || isCollected) return;

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
            if (isCollected) return;

            gameManager.Apply(effect);
            audioSource.Play();
            meshRenderer.enabled = false;
            myCollider.enabled = false;
            isCollected = true;
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
