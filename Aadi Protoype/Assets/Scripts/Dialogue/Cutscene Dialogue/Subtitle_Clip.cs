using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Subtitle_Clip : PlayableAsset
{
    public string subtitle_text;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Subtitle_Behaviour>.Create(graph);
        Subtitle_Behaviour subtitle_Behaviour = playable.GetBehaviour();
        subtitle_Behaviour.subtitle_text = subtitle_text;
        return playable;
    }
}
