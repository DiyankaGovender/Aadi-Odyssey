using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye_Movement : MonoBehaviour
{
    [Tooltip("Pupil that will be moved in the direction of the target")]
    [SerializeField]
    private Transform pupil;

    [Tooltip("Object the eye is looking at")]
    [SerializeField]
    private Transform lookAtTarget;

    [Tooltip("The distance the pupil is alowed to travel from the center of the eye.")]
    [SerializeField]
    private float movementDistance = 0.1f;

    void Update()
    {
        Vector3 direction = lookAtTarget.position - transform.position;
        Vector3 offset = direction.normalized * movementDistance;
        pupil.transform.localPosition = offset;
    }
}