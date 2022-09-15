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


    public Animator UI_Animator;


    private void Start()
    {
        player_rigidBody = GetComponent<Rigidbody2D>();
        DisableMovement();
        //EnableMovement();
      
        player_Animator.Play("player_CutsceneToTutorial");

        Tutorial_PlayableDirectorGO.SetActive(false);

        UI_Animator.Play("UI_FullscreenToFilmbar");
      
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


    //TRIGGER STUFF

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tutorial_Trigger")
        {
            Debug.Log("Yee");
            UI_Animator.Play("UI_FilmbarToDialogue");
            player_Animator.enabled = false;
            Tutorial_PlayableDirectorGO.SetActive(true);
        }

        if (collision.gameObject.tag == "Red_Trigger")
        {
            Debug.Log("Yee2");
        }
    }
}

