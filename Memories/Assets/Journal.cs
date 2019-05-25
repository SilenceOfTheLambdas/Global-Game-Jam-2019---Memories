using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Journal : MonoBehaviour {

    [SerializeField]
    private GameObject item;

    void Start()
    {
        if (GlobalControl.Instance.journalPickedUp)
        {
            Destroy(item);
            SceneManager.LoadScene(9);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalControl.Instance._score++;
            SceneManager.LoadScene(9);
        }
    }
}
