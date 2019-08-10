using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject exitDoor;

    int noOfSwitches = 0;

    [SerializeField]
    Text switchCount;

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
        SoundManager.PlaySound("Victory");
    }

    void Start()
    {
        GetNoOfSwitches();
    }

    public int GetNoOfSwitches()
    {
        int x = 0;

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<Switch>().isOn == false)
                x++;
            else if (switches[i].GetComponent<Switch>().isOn == true)
                noOfSwitches--;
        }

        noOfSwitches = x;

        return noOfSwitches;
    }

    public void GetExitDoorState()
    {
        if (noOfSwitches <= 0)
        {
            exitDoor.GetComponent<Door>().OpenDoor();
        }
    }

    void Update()
    {
        switchCount.text = GetNoOfSwitches().ToString();

        GetExitDoorState();
    }
}
