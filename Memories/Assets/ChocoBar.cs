using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChocoBar : MonoBehaviour {

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private float timer = 20f;

    public Text TimerText;

    void Start()
    {
        if (GlobalControl.Instance.chocolateBarPickedUp)
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
            SceneManager.LoadScene(1);
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
            Destroy(TimerText);
            Destroy(this.gameObject);
            GlobalControl.Instance.chocolateBarPickedUp = true;
            GlobalControl.Instance._score++;
        }
    }
}
