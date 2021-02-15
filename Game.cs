using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour {
    
    private Dealer dealer;
    private GameInterface gameInterface;
    private StatsTracker statsTracker;

    public GameObject[] buttonObject;
    private Button[] buttonComponent;
    
    private int roundsWon = 0;
    private bool roundSet;
    private bool buttonPressed;
    public float delayBetweenRounds = 0.7f;

    private int lowerCard;
    private int higherCard;

    void Start () {
        dealer = GetComponent<Dealer> ();
        gameInterface = GetComponent<GameInterface> ();
        statsTracker = GetComponent<StatsTracker> ();

        buttonComponent = new Button[buttonObject.Length];
        for (int i = 0; i < buttonObject.Length; i++) {
            buttonComponent[i] = buttonObject[i].GetComponent<Button> ();
        }
    }

    void Update () {
        if (!roundSet) {
            RemoveListeners ();
            if (roundsWon == 0) {
                gameInterface.SetButtonsZeroThree (false);
                buttonComponent[1].onClick.AddListener (() => BlackRed (0));
                buttonComponent[2].onClick.AddListener (() => BlackRed (1));
                gameInterface.SetButtonsOneTwo ("Black", "Red", gameInterface.blackIcon, gameInterface.redIcon, -50f,-36f);
            } else if (roundsWon == 1) {
                buttonComponent[1].onClick.AddListener (() => LowerHigher (0));
                buttonComponent[2].onClick.AddListener (() => LowerHigher (1));
                gameInterface.SetButtonsOneTwo ("Lower", "Higher", gameInterface.lowerIcon, gameInterface.higherIcon, -52f,-54f);
            } else if (roundsWon == 2) {
                buttonComponent[1].onClick.AddListener (() => InsideOutside (0));
                buttonComponent[2].onClick.AddListener (() => InsideOutside (1));
                gameInterface.SetButtonsOneTwo ("Inside", "Outside", gameInterface.insideIcon, gameInterface.outsideIcon, -52f,-64f);
            } else if (roundsWon == 3) {
                buttonComponent[0].onClick.AddListener (() => FourOptions (0));
                buttonComponent[1].onClick.AddListener (() => FourOptions (1));
                buttonComponent[2].onClick.AddListener (() => FourOptions (2));
                buttonComponent[3].onClick.AddListener (() => FourOptions (3));
                gameInterface.SetButtonsOneTwo ("Diamonds", "Hearts", gameInterface.diamondsIcon, gameInterface.heartsIcon, -77f,-57f);
                gameInterface.SetButtonsZeroThree (true);
            }
            roundSet = true;
            buttonPressed = false;
        }
    }

    void RemoveListeners () {
        buttonComponent[0].onClick.RemoveAllListeners ();
        buttonComponent[1].onClick.RemoveAllListeners ();
        buttonComponent[2].onClick.RemoveAllListeners ();
        buttonComponent[3].onClick.RemoveAllListeners ();
    }

    IEnumerator RoundWon (string roundName, int pointsToAdd) {
        yield return new WaitForSeconds (delayBetweenRounds);

        gameInterface.DisableNewDeckText ();
        
        AddPoints (pointsToAdd);
        gameInterface.UpdateCurrentPoints (pointsToAdd);
        
        statsTracker.AddRoundWin (roundName, pointsToAdd);
        statsTracker.CheckMostPoints ();

        if (roundsWon == 3) {
            statsTracker.AddGameWin ();
            NewGame ();
        } else {
            roundsWon = roundsWon + 1;    
            roundSet = false;
        }
    }
    
    IEnumerator GameLost (string roundName) {
        yield return new WaitForSeconds (delayBetweenRounds);

        gameInterface.DisableNewDeckText ();

        AddPoints (-20);
        gameInterface.UpdateCurrentPoints (-20);

        statsTracker.AddRoundLoss (roundName);

        NewGame ();
    }

    void AddPoints (int pointsToAdd) {
        PlayerPrefs.SetInt ("CurrentPoints", PlayerPrefs.GetInt ("CurrentPoints") + pointsToAdd);
        if (PlayerPrefs.GetInt ("CurrentPoints") < 0) {
            PlayerPrefs.SetInt ("CurrentPoints", 0);
        }
    }
    
    void NewGame () {
        dealer.DealCards (roundsWon);
        roundsWon = 0;
        roundSet = false;
    }

    void BlackRed (int i) {
        if (!buttonPressed) {
            buttonPressed = true;
            dealer.TurnCard (0);
            if ((i == 0 && (dealer.table[0].suit == 0 || dealer.table[0].suit == 3)) ||
                (i == 1 && (dealer.table[0].suit == 1 || dealer.table[0].suit == 2))) {
                StartCoroutine (RoundWon ("BlackRed", 10));
            } else {
                StartCoroutine (GameLost ("BlackRed"));
            }
        }
    }

    void LowerHigher (int i) {
        if (!buttonPressed) {
            buttonPressed = true;
            dealer.TurnCard (1);
            if ((i == 0 && (dealer.table[1].number < dealer.table[0].number)) ||
                (i == 1 && (dealer.table[1].number > dealer.table[0].number))) {
                StartCoroutine (RoundWon ("LowerHigher", 20));
            } else {
                StartCoroutine (GameLost ("LowerHigher"));
            }
        }
    }
    
    void InsideOutside (int i) {
        if (!buttonPressed) {
            buttonPressed = true;
            dealer.TurnCard (2);
            if (dealer.table[0].number > dealer.table[1].number) {
                lowerCard = dealer.table[1].number;
                higherCard = dealer.table[0].number;
            } else if (dealer.table[1].number > dealer.table[0].number) {
                lowerCard = dealer.table[0].number;
                higherCard = dealer.table[1].number;
            }
            
            if ((i == 0 && (dealer.table[2].number > lowerCard && dealer.table[2].number < higherCard)) ||
                (i == 1 && (dealer.table[2].number < lowerCard || dealer.table[2].number > higherCard))) {
                StartCoroutine (RoundWon ("InsideOutside", 30));
            } else {
                StartCoroutine (GameLost ("InsideOutside"));
            }
        }
    }

    void FourOptions (int i) {
        if (!buttonPressed) {
            buttonPressed = true;
            dealer.TurnCard (3);
            if (i == dealer.table[3].suit) {
                StartCoroutine (RoundWon ("WhichSuit", 40));
            } else {
                StartCoroutine (GameLost ("WhichSuit"));
            }
        }
    }
}
