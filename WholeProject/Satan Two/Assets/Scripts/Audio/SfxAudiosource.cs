using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxAudiosource : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] PlayerSettings playerSettings;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.volume = playerSettings.sfxVolume;
        
    }
    public void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        Invoke("AutoDestroy", audioClip.length);
    }
    private void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
