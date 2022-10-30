using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackBindingType(typeof(TextMeshProUGUI))]
[TrackClipType(typeof(Subtitle_Clip))]
public class Subtitle_Track : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SubtitleTrack_Mixer>.Create(graph, inputCount);
    }
}
