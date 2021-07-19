using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudiosource : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] PlayerSettings playerSettings;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.volume = playerSettings.musicVolume;
    }
}
