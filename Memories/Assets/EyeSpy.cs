using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SocialPlatforms.Impl;

public class EyeSpy : MonoBehaviour
{

    [SerializeField] private GameObject item;
    public int tries;

    void Start()
    {
        if (GlobalControl.Instance.boardGamePickedUp)
        {
            Destroy(item);
        }        
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        Destroy(item);
        GlobalControl.Instance.boardGamePickedUp = true;
        GlobalControl.Instance._score++;
    }
}
