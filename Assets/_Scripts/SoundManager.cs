using System;
using UnityEngine;

namespace _Scripts
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { private set; get; }
        
        public AudioSource musicAudioSource;
        public AudioSource sfxAudioSource;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }
        
        public void PlaySound(AudioClip clip)
        {
            sfxAudioSource.PlayOneShot(clip);
        }        
    }
}
