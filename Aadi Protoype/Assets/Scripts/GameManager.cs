using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator _noteAnimator;
    [SerializeField] AudioClip _sceneMusic;
    [SerializeField] GameObject _pauseMenu;

   

    [Header("Data")]
    private bool _showNote = false;

    private void Start()
    {
       
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void OpenNotes()
    {
        Pause();
        _showNote = true;
        _noteAnimator.SetTrigger("PopUp");
    }

    public void CloseNotes()
    {
        UnPause();
        _showNote = false;
        _noteAnimator.SetTrigger("PopDown");
    }

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void OpenPauseMenu()
    {
        _pauseMenu.SetActive(true);
        Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !_showNote && Time.timeScale == 1)
        {
            OpenNotes();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            OpenPauseMenu();
        }
    }
}
