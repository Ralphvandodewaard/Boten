using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsInterface : MonoBehaviour {

    public TextMeshProUGUI currentPoints;
    public TextMeshProUGUI mostPoints;
    public TextMeshProUGUI pointsEarned;

    public TextMeshProUGUI gamesWonLost;
    public TextMeshProUGUI roundsWonLost;
    public TextMeshProUGUI blackRed;
    public TextMeshProUGUI lowerHigher;
    public TextMeshProUGUI insideOutside;
    public TextMeshProUGUI whichSuit;

    public TextMeshProUGUI totalDecks;
    public TextMeshProUGUI mostWins;
    public TextMeshProUGUI mostRounds;
    
    void Start () {
        currentPoints.text = PlayerPrefs.GetInt ("CurrentPoints", 0).ToString ();
        mostPoints.text = PlayerPrefs.GetInt ("MostPoints", 0).ToString ();
        pointsEarned.text = PlayerPrefs.GetInt ("PointsEarned", 0).ToString ();
        gamesWonLost.text = PlayerPrefs.GetInt ("GameWins", 0).ToString () + " / " + PlayerPrefs.GetInt ("Losses", 0).ToString () + " (" + Mathf.Round (((float)PlayerPrefs.GetInt ("GameWins", 0) / ((float)PlayerPrefs.GetInt ("GameWins", 0) + (float)PlayerPrefs.GetInt ("Losses", 0))) * 1000f) / 10f + "%)";
        roundsWonLost.text = PlayerPrefs.GetInt ("RoundWins", 0).ToString () + " / " + PlayerPrefs.GetInt ("Losses", 0).ToString () + " (" + Mathf.Round (((float)PlayerPrefs.GetInt ("RoundWins", 0) / ((float)PlayerPrefs.GetInt ("RoundWins", 0) + (float)PlayerPrefs.GetInt ("Losses", 0))) * 1000f) / 10f + "%)";
        blackRed.text = PlayerPrefs.GetInt ("BlackRedWins", 0).ToString () + " / " + PlayerPrefs.GetInt ("BlackRedLosses", 0).ToString () + " (" + Mathf.Round (((float)PlayerPrefs.GetInt ("BlackRedWins", 0) / ((float)PlayerPrefs.GetInt ("BlackRedWins", 0) + (float)PlayerPrefs.GetInt ("BlackRedLosses", 0))) * 1000f) / 10f + "%)";
        lowerHigher.text = PlayerPrefs.GetInt ("LowerHigherWins", 0).ToString () + " / " + PlayerPrefs.GetInt ("LowerHigherLosses", 0).ToString () + " (" + Mathf.Round (((float)PlayerPrefs.GetInt ("LowerHigherWins", 0) / ((float)PlayerPrefs.GetInt ("LowerHigherWins", 0) + (float)PlayerPrefs.GetInt ("LowerHigherLosses", 0))) * 1000f) / 10f + "%)";
        insideOutside.text = PlayerPrefs.GetInt ("InsideOutsideWins", 0).ToString () + " / " + PlayerPrefs.GetInt ("InsideOutsideLosses", 0).ToString () + " (" + Mathf.Round (((float)PlayerPrefs.GetInt ("InsideOutsideWins", 0) / ((float)PlayerPrefs.GetInt ("InsideOutsideWins", 0) + (float)PlayerPrefs.GetInt ("InsideOutsideLosses", 0))) * 1000f) / 10f + "%)";
        whichSuit.text = PlayerPrefs.GetInt ("WhichSuitWins", 0).ToString () + " / " + PlayerPrefs.GetInt ("WhichSuitLosses", 0).ToString () + " (" + Mathf.Round (((float)PlayerPrefs.GetInt ("WhichSuitWins", 0) / ((float)PlayerPrefs.GetInt ("WhichSuitWins", 0) + (float)PlayerPrefs.GetInt ("WhichSuitLosses", 0))) * 1000f) / 10f + "%)";
        totalDecks.text = PlayerPrefs.GetInt ("Decks", 0).ToString ();
        mostWins.text = PlayerPrefs.GetInt ("MostGameWins", 0).ToString ();
        mostRounds.text = PlayerPrefs.GetInt ("MostRoundWins", 0).ToString ();
    }
}
