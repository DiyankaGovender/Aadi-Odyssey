using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPalette_AnimationChecker : MonoBehaviour
{
    public GameObject colour_palette;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colour_palette.activeSelf == true)
        {
            Debug.Log("IS ACTIVE");
        }

        else if (colour_palette.activeSelf ==false)
        {
            Debug.Log("not active");
        }
    }
}
