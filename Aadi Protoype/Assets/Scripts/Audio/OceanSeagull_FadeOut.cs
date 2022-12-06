using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Audio_FadeOut;

public class OceanSeagull_FadeOut : MonoBehaviour
{
    public AudioSource seagullAudioSource;
    public AudioClip seagullAudioclip;

    public AudioSource oceanAudioSource;
    public AudioClip oceanAudioclip;

    public GameObject seagullGO;
    public GameObject oceanGO;

    public float fadeTime = 5f;
    public void Awake()
    {
        seagullGO.SetActive(true);
      
        StartCoroutine(AudioControllerSeagull.SeagullFadeOut(seagullAudioSource, fadeTime));

        oceanGO.SetActive(true);

        StartCoroutine(AudioControllerOcean.OceanFadeOut(oceanAudioSource, fadeTime));

    }

    public static class AudioControllerSeagull
    {
        public static IEnumerator SeagullFadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }
            audioSource.Stop();
        }
    }



    public static class AudioControllerOcean
    {
        public static IEnumerator OceanFadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }
            audioSource.Stop();
        }
    }


}
