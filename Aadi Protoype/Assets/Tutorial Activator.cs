using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialActivator : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public PlayableAsset tutorialTimeline;

    public void Awake()
    {
        playableDirector.Play(tutorialTimeline);
        playableDirector.time = 0;
    }
}
