using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    
    private AudioSource audioSource;
    
    public AudioClip[] backgroundMusic;
    private int counter = 0;
    
    void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag ("DontDestroyOnLoad");
        if (objs.Length > 1) {
            Destroy (this.gameObject);
        }
        DontDestroyOnLoad (this.gameObject);
    }

    void Start() {
        audioSource = GetComponent<AudioSource> ();
        PlayBackgroundMusic ();
    }

    void Update() {
        if (!audioSource.isPlaying) {
            if (counter < backgroundMusic.Length - 1) {
                counter = counter + 1;
            } else {
                counter = 0;
            }
            PlayBackgroundMusic ();
        }
    }

    void PlayBackgroundMusic () {
        audioSource.clip = backgroundMusic[counter];
        audioSource.Play ();
    }
}
