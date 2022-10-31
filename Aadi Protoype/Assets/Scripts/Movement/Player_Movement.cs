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
    public Animator player_WalkAnimator;

    public PlayableDirector playableDirector;
  

    public PlayableAsset tutorialTimeline;
    public PlayableAsset nameTimeline;
    public PlayableAsset redTimeline;
    public PlayableAsset orangeTimeline;
    public PlayableAsset yellowTimeline;
    public PlayableAsset greenTimeline;
    public PlayableAsset blueTimeline;
    public PlayableAsset greyTimeline;
    public PlayableAsset postGreyTimeline;
    public PlayableAsset startPaisleyTimeline;
    public PlayableAsset familyPotraitTimeline;
    public PlayableAsset endPaisleyTimeline;

    public GameObject tutorialTriggerBC;
    public GameObject nameTriggerBC;
    public GameObject redTriggerBC;
    public GameObject orangeTriggerBC;
    public GameObject yellowTriggerBC;
    public GameObject greenTriggerBC;
    public GameObject blueTriggerBC;
    public GameObject greyTriggerBC;
    public GameObject postGreyBC;
    public GameObject startPaisleysBC;
    public GameObject familyPotraitsBC;
    public GameObject endPaisleysBC;

    private void Start()
    {
        player_rigidBody = GetComponent<Rigidbody2D>();

       DisableMovement();
       //EnableMovement();

        
    }

    public void FixedUpdate()
    {
        if (playerCanMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            player_rigidBody.velocity = new Vector2(moveInput * playerMovement_speed, player_rigidBody.velocity.y);

            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput)); 

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
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput=0));
        }

        //NAME SCENE
        if (collision.gameObject.tag == "Name_Trigger")
        {

            nameTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(nameTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }

        //RED SCENE
        if (collision.gameObject.tag == "Red_Trigger")
        {
           
            redTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(redTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));

        }


        //ORANGE SCENE
        if (collision.gameObject.tag == "Orange_Trigger")
        {
            
            orangeTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(orangeTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }

        //YELLOW SCENE
        if (collision.gameObject.tag == "Yellow_Trigger")
        {
           
            yellowTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(yellowTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }


        //GREEN SCENE
        if (collision.gameObject.tag == "Green_Trigger")
        {
            
            greenTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(greenTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }

        //BLUE SCENE
        if (collision.gameObject.tag == "Blue_Trigger")
        {
     
            blueTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(blueTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }

        //GREY SCENE
        if (collision.gameObject.tag == "Grey_Trigger")
        {
        
            greyTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(greyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }


        //POST GREY SCENE
        if (collision.gameObject.tag == "PostGrey_Trigger")
        {

            postGreyBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(postGreyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }



        //PAISLEY START SCENE
        if (collision.gameObject.tag == "PaisleyStart_Trigger")
        {

            startPaisleysBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(startPaisleyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }


        //FAMILY POTRAIT SCENE
        if (collision.gameObject.tag == "FamilyPotrait_Trigger")
        {

            familyPotraitsBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(familyPotraitTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }


        //PAISLEY END SCENE
        if (collision.gameObject.tag == "PaisleyEnd_Trigger")
        {

            endPaisleysBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(endPaisleyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
        }
    }

    public void RunNewTimeline(PlayableAsset playableAsset)
    {
        Debug.Log(playableAsset.name);
        playableDirector.Play(playableAsset);
        playableDirector.time = 0;
    }
}

