using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTracker : MonoBehaviour  {

    private int roundWinsThisDeck;
    private int gameWinsThisDeck;

    private int gameWinsStreak;
    private int blackRedLossesStreak;

    public void AddRoundWin (string roundName, int pointsToAdd) {
        roundWinsThisDeck = roundWinsThisDeck + 1;
        blackRedLossesStreak = 0;

        PlayerPrefs.SetInt ("PointsEarned", PlayerPrefs.GetInt ("PointsEarned") + pointsToAdd);
        PlayerPrefs.SetInt ("RoundWins", PlayerPrefs.GetInt ("RoundWins") + 1);
        PlayerPrefs.SetInt (roundName + "Wins", PlayerPrefs.GetInt (roundName + "Wins") + 1);
    }

    public void AddRoundLoss (string roundName) {
        gameWinsStreak = 0;
        if (roundName == "BlackRed") {
            blackRedLossesStreak = blackRedLossesStreak + 1;
            if (blackRedLossesStreak == 5 && PlayerPrefs.GetInt ("AchievementBlackRedLossesStreak5") == 0) {
                PlayerPrefs.SetInt ("AchievementBlackRedLossesStreak5", 1);
            }
        }

        PlayerPrefs.SetInt ("PointsLost", PlayerPrefs.GetInt ("PointsLost") + 20);
        PlayerPrefs.SetInt ("Losses", PlayerPrefs.GetInt ("Losses") + 1);
        PlayerPrefs.SetInt (roundName + "Losses", PlayerPrefs.GetInt (roundName + "Losses") + 1);
    }
    
    public void AddGameWin () {
        gameWinsThisDeck = gameWinsThisDeck + 1;
        gameWinsStreak = gameWinsStreak + 1;
        if (gameWinsStreak == 2 && PlayerPrefs.GetInt ("AchievementWinsStreak2") == 0) {
            PlayerPrefs.SetInt ("AchievementWinsStreak2", 1);
        }

        PlayerPrefs.SetInt ("GameWins", PlayerPrefs.GetInt ("GameWins") + 1);
    }
    
    public void CheckMostPoints () {
        if (PlayerPrefs.GetInt ("CurrentPoints") > PlayerPrefs.GetInt ("MostPoints")) {
            PlayerPrefs.SetInt ("MostPoints", PlayerPrefs.GetInt ("CurrentPoints"));
        }
    }

    public void CheckMostWins () {
        if (roundWinsThisDeck >= 40 && PlayerPrefs.GetInt ("AchievementRoundWinsDeck40") == 0) {
            PlayerPrefs.SetInt ("AchievementRoundWinsDeck40", 1);
        }
        if (gameWinsThisDeck == 0 && PlayerPrefs.GetInt ("AchievementGameWinsDeck0") == 0) {
            PlayerPrefs.SetInt ("AchievementGameWinsDeck0", 1);
        }
        if (gameWinsThisDeck >= 3 && PlayerPrefs.GetInt ("AchievementGameWinsDeck3") == 0) {
            PlayerPrefs.SetInt ("AchievementGameWinsDeck3", 1);
        }
        
        if (roundWinsThisDeck > PlayerPrefs.GetInt ("MostRoundWins")) {
            PlayerPrefs.SetInt ("MostRoundWins", roundWinsThisDeck);
        }
        if (gameWinsThisDeck > PlayerPrefs.GetInt ("MostGameWins")) {
            PlayerPrefs.SetInt ("MostGameWins", gameWinsThisDeck);
        }
        roundWinsThisDeck = 0;
        gameWinsThisDeck = 0;
    }

    public void CheckCurrentPointsAchievements () {
        if (PlayerPrefs.GetInt ("CurrentPoints") >= 500 && PlayerPrefs.GetInt ("AchievementCurrentPoints500") == 0) {
            PlayerPrefs.SetInt ("AchievementCurrentPoints500", 1);
        } else if (PlayerPrefs.GetInt ("CurrentPoints") >= 1000 && PlayerPrefs.GetInt ("AchievementCurrentPoints1000") == 0) {
            PlayerPrefs.SetInt ("AchievementCurrentPoints1000", 1);
        } else if (PlayerPrefs.GetInt ("CurrentPoints") >= 2500 && PlayerPrefs.GetInt ("AchievementCurrentPoints2500") == 0) {
            PlayerPrefs.SetInt ("AchievementCurrentPoints2500", 1);
        }
    }
}
