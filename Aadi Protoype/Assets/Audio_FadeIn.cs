using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_FadeIn : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicAudioclip;
    private bool isPlayed;

    public float fadeTime;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Red_Trigger")
        {
            
            StartCoroutine(AudioControllerMusicAudio.FadeIn(musicAudioSource, fadeTime));
  
        }
    }


    public static class AudioControllerMusicAudio
    {
        public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
        {
            //audioSource.Play();
            float startVolume = audioSource.volume;
            if (audioSource.volume == 0)
            {
                audioSource.volume += startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }
           
        }
    }




}