using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_FadeOut : MonoBehaviour
{
    public AudioSource rainAudioSource;
    public AudioClip RainAudioclip;
    private bool isPlayed;

    public AudioSource stormAudioSource;
    public AudioClip stormAudioclip;


    public float fadeTime;

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cutscene1_AudioFadeOut")
        {
            Debug.Log("AUDIO MUTHAFUCKAS");
            StartCoroutine(AudioControllerRainAudio.FadeOut(rainAudioSource, fadeTime));
            StartCoroutine(AudioControllerStormAudio.FadeOut(stormAudioSource, fadeTime));
        }
    }


    public static class AudioControllerRainAudio
    {
        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
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

    public static class AudioControllerStormAudio
    {
        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
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