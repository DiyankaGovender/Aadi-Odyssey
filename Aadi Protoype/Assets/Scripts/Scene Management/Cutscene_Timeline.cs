using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene_Timeline : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public PlayableAsset titleScreenTimeline;
    public PlayableAsset quotecutscene1_Timeline;


    public PlayableAsset creditsFadeIn_Timeline;
    public PlayableAsset creditsFadeOut_Timeline;   

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
        //titleScreenCanvas.SetActive(false);
        RunNewCutsceneTimeline(quotecutscene1_Timeline);
    }


    public void creditsEntryTimeline()
    {
        RunNewCutsceneTimeline(creditsFadeIn_Timeline);
    }


    public void creditsExitTimeline()
    {
        RunNewCutsceneTimeline(creditsFadeOut_Timeline);
    }

}
