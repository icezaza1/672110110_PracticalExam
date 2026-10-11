using UnityEngine;
using UnityEngine.Audio;

namespace Pattanakan_Methavikul.Managers
{
    [CreateAssetMenu(fileName = "SoundSettingsPreset", menuName = "Sounds/SoundSettingsPreset")]
    public class SoundSettings : ScriptableObject
    {
        public AudioMixer AudioMixer;

        [Header("BGMVolume")]
        public string BGMVolumeName = "BGMVolume";
        [Range(-80, 20)]
        public float BGMVolume;

        [Header("SFXVolume")]
        public string SFXVolumeName = "SFXVolume";
        [Range(-80, 20)]
        public float SFXVolume;
    }

}