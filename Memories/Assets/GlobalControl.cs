using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;

    [Header("The Global Item Score")]
    public int _score; // Stores the global score

    public Text counter; // The counter text
    public Text winText; // The win text

    public bool gameOver;

    public bool boardGamePickedUp = false; // Has the board game been picked up?
    public bool magnifyingGlassPickedUp = false; // Has the magnifying glass been picked up?
    public bool penPickedUp = false; // Has the pen been picked up?
    public bool journalPickedUp = false; // Has the journal been picked up?
    public bool applePickedUp = false; // Has the apple been picked up?
    public bool chocolateBarPickedUp = false; // Has the chocolate bar been picked up?
    public bool skippingRopePickedUp = false; // Has the skipping rope been picked up?

    void FixedUpdate()
    {
        SetCountText();
        winText.text = "";
    }

    void SetCountText()
    {
        counter.text = "Count: " + _score.ToString();
    }

    void ObjectsCollectedDestroy()
    {
        if (boardGamePickedUp)
        {
            Destroy(GameObject.FindWithTag("BoardGame"));
        }

        if (penPickedUp)
        {
            Destroy(GameObject.FindWithTag("Pen"));
        }
        if (journalPickedUp)
        {
            Destroy(GameObject.FindWithTag("Jpurnal"));
        }
        if (applePickedUp)
        {
            Destroy(GameObject.FindWithTag("Apple"));
        }
        if (chocolateBarPickedUp)
        {
            Destroy(GameObject.FindWithTag("ChocolateBar"));
        }

        if (skippingRopePickedUp)
        {
            Destroy(GameObject.FindWithTag("SkippingRope"));
        }
    }

    void onGameOver()
    {
        if (gameOver)
        {
            SceneManager.LoadScene(0); // TODO: Change to game over menu
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
