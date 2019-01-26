using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EyeSpy : MonoBehaviour
{

    [SerializeField] private GameObject item;
    [SerializeField] private float timer = 15f;
    [SerializeField] private GameObject ISpyText;

    public Text TimerText;

    void Start()
    {
        if (GlobalControl.Instance.boardGamePickedUp)
        {
            Destroy(item);
            Destroy(ISpyText);
            Destroy(TimerText);
        }     

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(0); // TODO: Change to hallway scene
        } else { setTimerText(); }
    }

    void setTimerText()
    {
        TimerText.text = "Timer: " + timer.ToString();
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        Destroy(item);
        Destroy(ISpyText);
        Destroy(TimerText);
        GlobalControl.Instance.boardGamePickedUp = true;
        GlobalControl.Instance._score++;
    }
}
