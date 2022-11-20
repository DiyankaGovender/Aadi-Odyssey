using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSeagull_FadeIn : MonoBehaviour
{
    public AudioSource seagullAudioSource;
    public AudioClip seagullAudioclip;

    public AudioSource oceanAudioSource;
    public AudioClip oceanAudioclip;

    public GameObject seagullGO;
    public GameObject oceanGO;

    public float targetVolume = 0.5f;
    void Start()
    {
       
    }


    public void Awake()
    {
        seagullGO.SetActive(true);
        oceanGO.SetActive(true);
        StartCoroutine(StartFade(seagullAudioSource, 2f,targetVolume));
        StartCoroutine(StartFade(oceanAudioSource, 2f, targetVolume));
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
