using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject controls;

    // Update is called once per frame
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controls.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void controlsMenu()
    {
        controls.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void Options()
    {
        controls.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void exitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
