using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScenenToTitleScreen : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void Awake()
    {

        SceneManager.LoadScene(0);
    }


}
