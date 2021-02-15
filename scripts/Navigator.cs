using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour  {

    public void GoToMenu () {
        SceneManager.LoadScene ("Menu");
    }

    public void GoToPlay () {
        SceneManager.LoadScene ("Play");
    }

    public void GoToStats () {
        SceneManager.LoadScene ("Stats");
    }

    public void GoToAchievements () {
        SceneManager.LoadScene ("Achievements");
    }
}
