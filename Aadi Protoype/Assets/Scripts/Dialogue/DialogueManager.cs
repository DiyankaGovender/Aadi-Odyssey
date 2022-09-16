using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor.Timeline;
using UnityEngine.Playables;

public class DialogueManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayableDirector _playableDirector;
    [SerializeField] GameObject _dialogueUI;
    [SerializeField] Dialogue _startDialogue;
    [SerializeField] TextMeshProUGUI _dialogueDisplay;
    [SerializeField] Image _faceDisplayImage;

    //private Animator _animator;

    //private GameManager _gameManager;

    [Header("Data")]
    private int _onSentence;
    private Dialogue _currentDialogue;

    private void Start()
    {
      
    }

    //Loads up a dialogue instance
    public void StartDialogue(Dialogue dialogue)
    {
   
        _dialogueUI.SetActive(true);

        _currentDialogue = dialogue;
        _onSentence = 0;
        _dialogueDisplay.text = _currentDialogue.sentences[_onSentence].sentence;

       
        SetFace(_currentDialogue.sentences[_onSentence].faceSprite);
    }


    //Moves to next sentence in currently loaded dialogue
    public void NextDialogue()
    {
        if (_currentDialogue != null  && _playableDirector.state== PlayState.Paused)
        {
            _playableDirector.Play();
            _onSentence++;

            if(_onSentence > _currentDialogue.sentences.Count-1)
            {
                EndDialogue();
            }
            else
            {
                _dialogueDisplay.text = _currentDialogue.sentences[_onSentence].sentence;
                SetFace(_currentDialogue.sentences[_onSentence].faceSprite);
            }
        }
    }

    //Closes current dialogue and hides uneeded UI & text
    public void EndDialogue()
    {
        

        _currentDialogue = null;
      
        _dialogueDisplay.text = "";
      

        _playableDirector.Play();
    }

    public void SetFace(Sprite s)
    {
        _faceDisplayImage.sprite = s;
    }
}
