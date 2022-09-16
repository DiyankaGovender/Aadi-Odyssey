using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEditor.Timeline;
using UnityEngine.Playables;

public class Player_Movement : MonoBehaviour
{
    public float playerMovement_speed;

    private float moveInput;
    private Rigidbody2D player_rigidBody;
    private bool playerFacing_right = false;

    private bool playerCanMove;


    public Animator player_Animator; 

    public PlayableDirector Tutorial_PlayableDirector;
    public GameObject Tutorial_PlayableDirectorGO;

    public PlayableDirector red_PlayableDirector;
    public GameObject red_PlayableDirectorGO;   

    public Animator UI_Animator;


    private void Start()
    {
        player_rigidBody = GetComponent<Rigidbody2D>();
        DisableMovement();
   
        player_Animator.Play("player_CutsceneToTutorial");
        UI_Animator.Play("UI_FullscreenToFilmbar");
        
        Tutorial_PlayableDirectorGO.SetActive(false);
        red_PlayableDirectorGO.SetActive(false);
      
      
    }

    public void FixedUpdate()
    {
        if (playerCanMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            player_rigidBody.velocity = new Vector2(moveInput * playerMovement_speed, player_rigidBody.velocity.y);

            if (playerFacing_right == false && moveInput < 0)
            {
                FlipPlayer();
            }
            else if (playerFacing_right == true && moveInput > 0)
            {
                FlipPlayer();
            }
            
        }
       
    }

    void FlipPlayer()
    {
        playerFacing_right = !playerFacing_right;
        Vector3 Scacler = transform.localScale;
        Scacler.x *= -1;
        transform.localScale = Scacler;
    }

    public void EnableMovement()
    {
        player_rigidBody.isKinematic = false;
        playerCanMove = true;
    }

    public void DisableMovement()
    {
        player_rigidBody.isKinematic = true;
        playerCanMove = false;
    }


    //TRIGGER TIMELINES
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //TUTORIAL SCENE
        if (collision.gameObject.tag == "Tutorial_Trigger")
        {
            Debug.Log("Yee");
            UI_Animator.Play("UI_FilmbarToDialogue");
            player_Animator.enabled = false;
            Tutorial_PlayableDirectorGO.SetActive(true);
        }


        //RED SCENE
        if (collision.gameObject.tag == "Red_Trigger")
        {
            Debug.Log("Yee2");
            UI_Animator.Play("UI_FilmbarToDialogue");
         
            red_PlayableDirectorGO.SetActive(true);
          
        }
    }
}

