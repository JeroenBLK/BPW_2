using UnityEngine;
using UnityEngine.UI;
public class settingScript : MonoBehaviour
{
    public GameObject menuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                menuPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                menuPanel.SetActive(false);
            }
        }
    }
}