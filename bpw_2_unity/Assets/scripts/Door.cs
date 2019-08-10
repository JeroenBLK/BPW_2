using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameObject DoorType;

    Manager gm;

    //strack the state of the door
    int stateOfDoor = 1;

    public int nexLevel;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(GetDoorState() == 3)
        {
            gm.LoadNextLevel(nexLevel);
        }
    }

    public void Start()
    {
        gm = FindObjectOfType<Manager>();

        if (DoorType.name == "ExitDoor")
            LockDoor();
    }

    public void LockDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            stateOfDoor = 1;
        }
    }

    public void UnlockDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            stateOfDoor = 2;
        }
    }

    public void OpenDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            stateOfDoor = 3;
        }
    }

    public void SetDoorState(int state)
    {
        if (state == 1 && DoorType.name == "ExitDoor")
            LockDoor();
        if (state == 2 && DoorType.name == "ExitDoor")
            UnlockDoor();
        if (state == 3 && DoorType.name == "ExitDoor")
            OpenDoor();
    }

    public int GetDoorState()
    {
        return stateOfDoor;
    }
}
