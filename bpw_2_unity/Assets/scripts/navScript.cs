
using UnityEngine;
using UnityEngine.SceneManagement;

public class navScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Scene01");
        SoundManager.PlaySound("MenuClick");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        SoundManager.PlaySound("MenuClick");
    }

    public void ExitButton()
    {
        Application.Quit();
        SoundManager.PlaySound("MenuClick");
    }
}
