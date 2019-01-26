using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HiddenRose : MonoBehaviour {

    [SerializeField]
    private GameObject item;

    [SerializeField] private float timer = 20f;

    public Text TimerText;

    void Start()
    {
        if (GlobalControl.Instance.boardGamePickedUp)
        {
            Destroy(item);
            Destroy(TimerText);
        }

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(0); // TODO: Change to hallway scene
        }
        else { setTimerText(); }
    }

    void setTimerText()
    {
        TimerText.text = "Timer: " + timer.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(item);
            Destroy(TimerText);
            GlobalControl.Instance.rosePickedUp = true;
            GlobalControl.Instance._score++;
        }
    }
}
