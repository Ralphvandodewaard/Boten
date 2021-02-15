using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {
    
    private AudioSource audioSource;

    public Image volumeButton;
    
    public Sprite volumeIcon;
    public Sprite MuteIcon;
    
    void Start () {
        audioSource = GameObject.FindWithTag ("DontDestroyOnLoad").GetComponent<AudioSource> ();
        if (audioSource.volume == 0) {
            volumeButton.sprite = MuteIcon;
        } else {
            volumeButton.sprite = volumeIcon;
        }
    }

    public void ChangeVolume () {
        if (audioSource.volume == 0) {
            audioSource.volume = 1;
            volumeButton.sprite = volumeIcon;
        } else {
            audioSource.volume = 0;
            volumeButton.sprite = MuteIcon;
        }
    }
}
