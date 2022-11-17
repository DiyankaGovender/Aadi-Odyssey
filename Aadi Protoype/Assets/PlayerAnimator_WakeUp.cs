using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator_WakeUp : MonoBehaviour
{
    public Animator playerAnimator;
    void Awake()
    {
        playerAnimator.GetComponent<Animator>().enabled = true;
    }
}
