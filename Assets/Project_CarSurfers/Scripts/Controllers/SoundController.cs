using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    public static SoundController Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
}
