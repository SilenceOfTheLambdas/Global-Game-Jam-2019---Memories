using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private string newLevel;
    [SerializeField] public GameObject bedroomCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.B))
            {
                SceneManager.LoadScene("SecretRoom");
            }
            else
            {    
                SceneManager.LoadScene(newLevel);
            }
        }
    }

    void Update()
    {
        bedroomCollider = GameObject.FindGameObjectWithTag("lockedRoom");
        if (GlobalControl.Instance._score < 4)
        {

            bedroomCollider.SetActive(false);
        }else if (GlobalControl.Instance._score == 4)
        {
            bedroomCollider.SetActive(true);
        }

    }
}
