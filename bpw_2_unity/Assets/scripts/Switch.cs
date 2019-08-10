using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    [SerializeField]
    GameObject switchOn;

    [SerializeField]
    GameObject SwitchOff;

    public bool isOn = false;

    private void Start()
    {
        //set the switch to off sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //set the switch to off sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOn.GetComponent<SpriteRenderer>().sprite;

        //set the isonn to true when triggered
        isOn = true;
        SoundManager.PlaySound("Pickup");
    }
}
