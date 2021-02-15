using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameInterface : MonoBehaviour {
    
    public GameObject[] buttonObject;
    private TextMeshProUGUI[] textComponent;
    private RectTransform[] imageTransform;
    private Image[] imageComponent;

    public Sprite blackIcon;
    public Sprite redIcon;
    public Sprite lowerIcon;
    public Sprite higherIcon;
    public Sprite insideIcon;
    public Sprite outsideIcon;
    public Sprite diamondsIcon;
    public Sprite heartsIcon;
    
    public TextMeshProUGUI cardsInDeckText;
    public TextMeshProUGUI currentPointsText;
    
    public TextMeshProUGUI addedPointsText;
    public Animator addedPointsAnimator;

    public TextMeshProUGUI newDeckText;

    public GameObject menuOverlay;
    
    void Start () {
        textComponent = new TextMeshProUGUI[buttonObject.Length];
        imageTransform = new RectTransform[buttonObject.Length];
        imageComponent = new Image[buttonObject.Length];
        for (int i = 0; i < buttonObject.Length; i++) {
            textComponent[i] = buttonObject[i].GetComponentInChildren<TextMeshProUGUI> ();
            imageTransform[i] = buttonObject[i].transform.GetChild (0).GetComponent<RectTransform> ();
            imageComponent[i] = imageTransform[i].gameObject.GetComponent<Image> ();
        }
        currentPointsText.text = "Points: " + PlayerPrefs.GetInt ("CurrentPoints", 0).ToString ();
    }
    
    public void SetButtonsZeroThree (bool falseTrue) {
        buttonObject[0].SetActive (falseTrue);
        buttonObject[3].SetActive (falseTrue);
    }

    public void SetButtonsOneTwo (string textOne, string textTwo, Sprite spriteOne, Sprite spriteTwo, float xOne, float xTwo) {
        textComponent[1].text = textOne;
        textComponent[2].text = textTwo;
        imageComponent[1].sprite = spriteOne;
        imageComponent[2].sprite = spriteTwo;
        imageTransform[1].localPosition = new Vector3 (xOne, imageTransform[1].localPosition.y, imageTransform[1].localPosition.z);
        imageTransform[2].localPosition = new Vector3 (xTwo, imageTransform[2].localPosition.y, imageTransform[1].localPosition.z);
    }
    
    public void UpdateCurrentPoints (int pointsToAdd) {
        if (pointsToAdd > 0) {
            addedPointsText.text = "+ ";
        } else if (pointsToAdd < 0) {
            addedPointsText.text = "- ";
        }
        addedPointsText.text += Mathf.Abs (pointsToAdd);
        addedPointsAnimator.SetTrigger ("FadeUp");
        currentPointsText.text = "Points: " + PlayerPrefs.GetInt ("CurrentPoints").ToString ();
    }
    
    public void UpdateCardsInDeck (int cardsInDeck) {
        cardsInDeckText.text = cardsInDeck.ToString ();
    }

    public void DisableNewDeckText () {
        if (newDeckText.enabled == true) {
            newDeckText.enabled = false;
        }
    }

    public void OpenOverlay () {
        menuOverlay.SetActive (true);
    }

    public void CloseOverlay () {
        menuOverlay.SetActive (false);
    }
}
