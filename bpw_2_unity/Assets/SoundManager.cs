using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip defeatSound, explosionSound, menuClickSound, pickupSound, victorySound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        defeatSound = Resources.Load<AudioClip>("Defeat");
        explosionSound = Resources.Load<AudioClip>("Explosion");
        menuClickSound = Resources.Load<AudioClip>("MenuClick");
        pickupSound = Resources.Load<AudioClip>("Pickup");
        victorySound = Resources.Load<AudioClip>("Victory");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "Defeat":
                audioSrc.PlayOneShot(defeatSound);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(explosionSound);
                break;
            case "MenuClick":
                audioSrc.PlayOneShot(menuClickSound);
                break;
            case "Pickup":
                audioSrc.PlayOneShot(pickupSound);
                break;
        }
    }
}