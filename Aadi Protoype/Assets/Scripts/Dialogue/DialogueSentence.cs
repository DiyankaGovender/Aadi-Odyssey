using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueSentence
{
    [TextArea(1,3)]
    public string sentence;
    public Sprite faceSprite;
}
