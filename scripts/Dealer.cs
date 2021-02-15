using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour {
    
    public List<Card> fullDeck = new List<Card> ();
    public List<Card> playingDeck = new List<Card> ();
    public List<Card> table = new List<Card> ();

    private GameInterface gameInterface;
    private StatsTracker statsTracker;
    private AudioSource audioSource;
    
    public GameObject cardHolder;
    private GameObject[] spawnedCard;
    private float xOffset = -9f;
    private float yOffset = 0f;

    public AudioClip cardFlipSound;
    
    void Start () {
        gameInterface = GetComponent<GameInterface> ();
        statsTracker = GetComponent<StatsTracker> ();
        audioSource = GameObject.FindWithTag ("DontDestroyOnLoad").GetComponent<AudioSource> (); 

        spawnedCard = new GameObject[4];
        FillDeck ();
        DealCards (0);
    }

    void FillDeck () {
        table.Clear ();
        playingDeck.Clear ();

        for (int i = 0; i < fullDeck.Count; i++) {
            playingDeck.Add (fullDeck[i]);
        }
        gameInterface.UpdateCardsInDeck (playingDeck.Count);
    }
    
    public void DealCards (int roundsWon) {
        if (roundsWon < playingDeck.Count) {
            for (int i = 0; i < 4; i++) {
                int randomNumber = Random.Range (0, playingDeck.Count);
                if (table.Count != 4 || i <= roundsWon) {
                    if (table.Count == 4) {
                        table.RemoveAt (i);
                    }
                    table.Insert (i, playingDeck[randomNumber]);
                    playingDeck.Remove (playingDeck[randomNumber]);

                    spawnedCard[i] = Instantiate (table[i].card, new Vector3 (table[i].card.transform.position.x + xOffset, table[i].card.transform.position.y + yOffset, table[i].card.transform.position.z), Quaternion.identity);
                    spawnedCard[i].transform.parent = cardHolder.transform;
                    spawnedCard[i].transform.eulerAngles = new Vector3 (spawnedCard[i].transform.eulerAngles.x, spawnedCard[i].transform.eulerAngles.y, spawnedCard[i].transform.eulerAngles.z + 180f);
                }
                xOffset = xOffset + 6f;
            }    
        } else {
            FillDeck ();
            DealCards (0);
            
            PlayerPrefs.SetInt ("Decks", PlayerPrefs.GetInt ("Decks") + 1);
            statsTracker.CheckMostWins ();
            gameInterface.newDeckText.enabled = true;
        }
        xOffset = -9f;
        yOffset = yOffset + 0.001f;
        gameInterface.UpdateCardsInDeck (playingDeck.Count);
    }

    public void TurnCard (int i) {
        spawnedCard[i].transform.eulerAngles = new Vector3 (spawnedCard[i].transform.eulerAngles.x, spawnedCard[i].transform.eulerAngles.y + Random.Range (-8f, 8f), spawnedCard[i].transform.eulerAngles.z + 180f);
        spawnedCard[i].transform.position = new Vector3 (spawnedCard[i].transform.position.x + Random.Range (-0.5f, 0.5f), spawnedCard[i].transform.position.y, spawnedCard[i].transform.position.z + + Random.Range (-0.5f, 0.5f));     
        audioSource.PlayOneShot (cardFlipSound);
    }
}
