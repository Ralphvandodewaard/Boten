using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFade : MonoBehaviour {
    
    public Animator logoAnimator;
    private Navigator navigator;
    
    void Start () {
        navigator = GetComponent<Navigator> ();
        
        logoAnimator.SetTrigger ("FadeInOut");
        Invoke ("AnimationEnd", 2.95f);
    }

    void AnimationEnd () {
        navigator.GoToMenu ();
    }
}
