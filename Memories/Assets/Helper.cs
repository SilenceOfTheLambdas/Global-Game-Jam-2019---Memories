using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{

	private bool alreadyCalled = false;
	[SerializeField] private GameObject canvas;

	void Start()
	{
		if (alreadyCalled)
		{
			Destroy(canvas);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			alreadyCalled = true;
			Destroy(this.gameObject);
		}
	}
}
