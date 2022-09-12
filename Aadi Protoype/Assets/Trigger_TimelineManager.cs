using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_TimelineManager : MonoBehaviour
{
    public Player_Movement player_Movement;

    
    public Animator player_Animator;
    public Animator ui_Animator;

    public GameObject tutorial_Message;

    void Start()
    {
        ui_Animator.Play("UI_FullscreenToFilmbar");
        player_Movement.enabled = false;
        tutorial_Message.SetActive(false);  
        player_Animator.Play("player_CutsceneToTutorialMessage");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "tutorial_Trigger")
        {
           ui_Animator.Play("UI_FilmbarToDialogue");
           
            Debug.Log("ffeeh");
            player_Movement.enabled = true;
            tutorial_Message.SetActive(true);
        }
    }



}
