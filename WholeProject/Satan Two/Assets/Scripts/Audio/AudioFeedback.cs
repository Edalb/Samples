using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject audioPrefab;
    public void PlayAudio()
    {
        GameObject sfxSource = Instantiate(audioPrefab);
        sfxSource.GetComponent<SfxAudiosource>().PlayClip(audioClip);
    }
}
