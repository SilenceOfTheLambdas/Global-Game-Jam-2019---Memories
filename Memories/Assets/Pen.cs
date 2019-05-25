using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pen : MonoBehaviour {

    [SerializeField]
    private GameObject item;

    void Start()
    {
        if (GlobalControl.Instance.penPickedUp)
        {
            Destroy(item);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene("Game");
        }
    }
}
