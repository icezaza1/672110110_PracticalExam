using NUnit.Framework.Internal;
using Pattanakan_Methavikul.Managers;
using UnityEngine;
using UnityEngine.Audio;

namespace Pattanakan_Methavikul.Obstacles
{
    public class Killzone : MonoBehaviour
    {
        private GameManager gameManager;
        private AudioSource audioSource;
        [SerializeField] private AudioClip collideSound;

        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
            audioSource = GetComponent<AudioSource>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            audioSource.PlayOneShot(collideSound);
            gameManager.EndGame(false);
        }
    }
}