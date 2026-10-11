using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffectScriptableObjects", menuName = "Items/Score and Time Effect")]
public class ItemEffectScriptableObjects : ScriptableObject
{
    public int scoreChange;
    public float timeChange;
    public AudioClip onCollectedSound;
}
