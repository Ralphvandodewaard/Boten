using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour  {

    private int roundWinsThisDeck;
    private int gameWinsThisDeck;

    public void AddRoundWin (string roundName, int pointsToAdd) {
        roundWinsThisDeck = roundWinsThisDeck + 1;

        PlayerPrefs.SetInt ("PointsEarned", PlayerPrefs.GetInt ("PointsEarned") + pointsToAdd);
        PlayerPrefs.SetInt ("RoundWins", PlayerPrefs.GetInt ("RoundWins") + 1);
        PlayerPrefs.SetInt (roundName + "Wins", PlayerPrefs.GetInt (roundName + "Wins") + 1);
    }

    public void AddRoundLoss (string roundName) {
        PlayerPrefs.SetInt ("PointsLost", PlayerPrefs.GetInt ("PointsLost") + 20);
        PlayerPrefs.SetInt ("Losses", PlayerPrefs.GetInt ("Losses") + 1);
        PlayerPrefs.SetInt (roundName + "Losses", PlayerPrefs.GetInt (roundName + "Losses") + 1);
    }
    
    public void AddGameWin () {
        gameWinsThisDeck = gameWinsThisDeck + 1;
        PlayerPrefs.SetInt ("GameWins", PlayerPrefs.GetInt ("GameWins") + 1);
    }
    
    public void CheckMostPoints () {
        if (PlayerPrefs.GetInt ("CurrentPoints") > PlayerPrefs.GetInt ("MostPoints")) {
            PlayerPrefs.SetInt ("MostPoints", PlayerPrefs.GetInt ("CurrentPoints"));
        }
    }

    public void CheckMostWins () {
        if (roundWinsThisDeck > PlayerPrefs.GetInt ("MostRoundWins")) {
            PlayerPrefs.SetInt ("MostRoundWins", roundWinsThisDeck);
        }
        if (gameWinsThisDeck > PlayerPrefs.GetInt ("MostGameWins")) {
            PlayerPrefs.SetInt ("MostGameWins", gameWinsThisDeck);
        }
        roundWinsThisDeck = 0;
        gameWinsThisDeck = 0;
    }
}
