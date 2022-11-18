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
  

    //PANEL TIMELINE
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
    


    public PlayableAsset cutscene2;
    public PlayableDirector cutscenePD;


    //CUE DIALOGUE 
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

    public GameObject cutscene2BC;

    //PANEL ANIMATORS
    public Animator redPanel;
    public Animator orangePanel;
    public Animator yellowPanel;
    public Animator greenPanel;
    public Animator bluePanel;
    public Animator greyPanel;

    //PANEL BOX COLLIDERS IN THE MIDDLE
    public GameObject redMidBC;
    public GameObject orangeMidBC;
    public GameObject yellowMidBC;
    public GameObject greenMidBC;
    public GameObject blueMidBC;
    public GameObject greyMidBC;


    public GameObject timelineManagerGO;
    private void Start()
    {
        player_rigidBody = GetComponent<Rigidbody2D>();


        //ENABLE THIS LINE IN THE FINAL BUILD
        //DisableMovement();
       
        //ENABLE THIS LINE DURING TESTING
        EnableMovement();

        
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

    public void enableAnimator()
    {
        player_Animator.enabled = true;
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
            player_Animator.Play("Player_WalkCycle_Idle");
        }

        //NAME SCENE
        if (collision.gameObject.tag == "Name_Trigger")
        {

            nameTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(nameTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");

        }

        //RED SCENE
        if (collision.gameObject.tag == "Red_Trigger")
        {
           
            redTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(redTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");

        }


        //ORANGE SCENE
        if (collision.gameObject.tag == "Orange_Trigger")
        {
            
            orangeTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(orangeTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }

        //YELLOW SCENE
        if (collision.gameObject.tag == "Yellow_Trigger")
        {
           
            yellowTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(yellowTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }


        //GREEN SCENE
        if (collision.gameObject.tag == "Green_Trigger")
        {
            
            greenTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(greenTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }

        //BLUE SCENE
        if (collision.gameObject.tag == "Blue_Trigger")
        {
     
            blueTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(blueTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }

        //GREY SCENE
        if (collision.gameObject.tag == "Grey_Trigger")
        {
        
            greyTriggerBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(greyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }


        //POST GREY SCENE
        if (collision.gameObject.tag == "PostGrey_Trigger")
        {

            postGreyBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(postGreyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }



        //PAISLEY START SCENE
        if (collision.gameObject.tag == "PaisleyStart_Trigger")
        {

            startPaisleysBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(startPaisleyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }


        //FAMILY POTRAIT SCENE
        if (collision.gameObject.tag == "FamilyPotrait_Trigger")
        {

            familyPotraitsBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(familyPotraitTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }


        //PAISLEY END SCENE
        if (collision.gameObject.tag == "PaisleyEnd_Trigger")
        {
            timelineManagerGO.SetActive(true);
            endPaisleysBC.GetComponent<BoxCollider2D>().enabled = false;

            RunNewTimeline(endPaisleyTimeline);
            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }

        //CUTSCENE 2
        if (collision.gameObject.name == "Cutscene2_Trigger")
        {
           
            RunNewTimeline(cutscene2);


            cutscene2BC.GetComponent<BoxCollider2D>().enabled = false;

            player_WalkAnimator.SetFloat("Speed", Mathf.Abs(moveInput = 0));
            player_Animator.Play("Player_WalkCycle_Idle");
        }



        //RED MID PANEL
        if (collision.gameObject.tag == "RedMid_Trigger")
        {
            Debug.Log("shbhsdhdsf");
            redPanel.Play("RedPanel_FadeOut");
        }

        //ORANGE MID PANEL
        if (collision.gameObject.tag == "OrangeMid_Trigger")
        {
            orangePanel.Play("OrangePanel_FadeOut");
        }

        //YELLOW MID PANEL
        if (collision.gameObject.tag == "YellowMid_Trigger")
        {
            yellowPanel.Play("YellowPanel_FadeOut");
        }

        //GREEN MID PANEL
        if (collision.gameObject.tag == "GreenMid_Trigger")
        {
            greenPanel.Play("GreenPanel_FadeOut");
        }

        //BLUE MID PANEL
        if (collision.gameObject.tag == "BlueMid_Trigger")
        {
            bluePanel.Play("BluePanel_FadeOut");
        }

        //GREY MID PANEL
        if (collision.gameObject.name == "GreyMid_Trigger")
        {
            greyPanel.Play("GreyPanel_FadeOut");
            Debug.Log("sshshs");
        }
    }

    public void RunNewTimeline(PlayableAsset playableAsset)
    {
        Debug.Log(playableAsset.name);
        playableDirector.Play(playableAsset);
        playableDirector.time = 0;
    }


    public void RunNewCUTSCENETimeline(PlayableAsset playableAsset)
    {
        Debug.Log(playableAsset.name);
        cutscenePD.Play(playableAsset);
        cutscenePD.time = 0;
    }
}

