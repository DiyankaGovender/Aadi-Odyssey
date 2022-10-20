using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene_Timeline : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public PlayableAsset titleScreenTimeline;


    public GameObject titleScreenCanvas;

    void Start()
    {
     
        RunNewCutsceneTimeline(titleScreenTimeline);
    }


    void Update()
    {

    }


    public void RunNewCutsceneTimeline(PlayableAsset playableAsset)
    {
        Debug.Log(playableAsset.name);
        playableDirector.Play(playableAsset);
        playableDirector.time = 0;
    }

    public void disableTitleScreen()
    {
        titleScreenCanvas.SetActive(false);
    }
}
