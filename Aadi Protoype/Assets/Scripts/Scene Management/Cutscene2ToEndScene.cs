using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2ToEndScene : MonoBehaviour
{
    private void Awake()
    {

        SceneManager.LoadScene(1);
    }

}
