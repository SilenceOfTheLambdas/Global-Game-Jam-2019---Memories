using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Kitchen : MonoBehaviour
{
	public Text tutorial;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "player")
		{
			tutorial.gameObject.SetActive(true);
		}
	}
}
