using Pattanakan_Methavikul.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Pattanakan_Methavikul.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private InputHandler inputHandler;
        private bool interactPressed;

        private readonly HashSet<Collectible> nearbyCollectibles = new HashSet<Collectible>();

        private void Awake()
        {
            inputHandler = GetComponent<InputHandler>();
        }

        private void Update()
        {
            interactPressed = inputHandler.InteractPressed;

            if (interactPressed)
                CollectNearestNearbyItem();
        }

        public void RegisterNearbyCollectible(Collectible collectible)
        {
            if (collectible != null)
                nearbyCollectibles.Add(collectible);
        }

        public void UnregisterNearbyCollectible(Collectible collectible)
        {
            nearbyCollectibles.Remove(collectible);
        }

        private void CollectNearestNearbyItem()
        {
            Collectible nearest = null;
            float nearestDistance = float.PositiveInfinity;

            foreach (Collectible collectible in nearbyCollectibles)
            {
                if (collectible == null) continue;

                float distance = (collectible.transform.position - transform.position).sqrMagnitude;
                if (distance < nearestDistance)
                {
                    nearest = collectible;
                    nearestDistance = distance;
                }
            }

            nearest?.CollectItem();
        }

    }
}