using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
//using UnityEditor.Timeline;
using UnityEngine.Playables;

public class Player_Movement : MonoBehaviour
{
    public float playerMovement_speed;

    private float moveInput;
    private Rigidbody2D player_rigidBody;
    private bool playerFacing_right = false;

    private bool playerCanMove;


    public Animator player_Animator; 

    public PlayableDirector playableDirector;
  

    public PlayableAsset tutorialTimeline;
    public PlayableAsset redTimeline;
    public PlayableAsset orangeTimeline;
    public PlayableAsset yellowTimeline;
    public PlayableAsset greenTimeline;
    public PlayableAsset blueTimeline;
    public PlayableAsset greyTimeline;

    public GameObject tutorialTriggerBC;
    public GameObject redTriggerBC;
    public GameObject orangeTriggerBC;
    public GameObject yellowTriggerBC;
    public GameObject greenTriggerBC;
    public GameObject blueTriggerBC;
    public GameObject greyTriggerBC;

    private void Start()
    {
        player_rigidBody = GetComponent<Rigidbody2D>();

       // DisableMovement();
       EnableMovement();

        
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
        playerCanMove = true;
        player_rigidBody.isKinematic = false;
        player_Animator.enabled = false;
    }

    public void DisableMovement()
    {
        playerCanMove = false;
        player_rigidBody.isKinematic = true;
        player_rigidBody.velocity = Vector2.zero;
    }


    //TRIGGER TIMELINES
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //TUTORIAL SCENE
        if (collision.gameObject.tag == "Tutorial_Trigger")
        {
          
            tutorialTriggerBC.GetComponent<BoxCollider2D>().enabled = false;
          
            RunNewTimeline(tutorialTimeline);
        }


        //RED SCENE
        if (collision.gameObject.tag == "Red_Trigger")
        {
           
            redTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(redTimeline);

        }


        //ORANGE SCENE
        if (collision.gameObject.tag == "Orange_Trigger")
        {
            
            orangeTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(orangeTimeline);

        }

        //YELLOW SCENE
        if (collision.gameObject.tag == "Yellow_Trigger")
        {
           
            yellowTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(yellowTimeline);

        }


        //GREEN SCENE
        if (collision.gameObject.tag == "Green_Trigger")
        {
            
            greenTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(greenTimeline);

        }

        //BLUE SCENE
        if (collision.gameObject.tag == "Blue_Trigger")
        {
     
            blueTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(blueTimeline);

        }

        //GREY SCENE
        if (collision.gameObject.tag == "Grey_Trigger")
        {
        
            greyTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(greyTimeline);

        }
    }

    public void RunNewTimeline(PlayableAsset playableAsset)
    {
        Debug.Log(playableAsset.name);
        playableDirector.Play(playableAsset);
        playableDirector.time = 0;
    }
}

