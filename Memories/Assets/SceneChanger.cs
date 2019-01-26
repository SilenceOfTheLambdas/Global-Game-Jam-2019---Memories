using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private string newLevel;
    [SerializeField] private GameObject bedroomCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
        }
    }

    void Update()
    {
        if (GlobalControl.Instance._score < 4)
        {
            bedroomCollider.SetActive(false);
        }else if (GlobalControl.Instance._score == 4)
        {
            bedroomCollider.SetActive(true);
        }
    }
}
