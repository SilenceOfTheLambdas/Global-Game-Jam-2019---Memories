using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollect : MonoBehaviour
{
	public AudioSource _as;
	public AudioClip collisionSound;

	public SpriteRenderer sprite;
	// Use this for initialization
	void Start ()
	{
		_as = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		_as.Play();
		if (other.CompareTag("Player"))
		{
			_as.Play();
			Destroy(sprite);
			if (this.gameObject.CompareTag("Pen"))
			{
				GlobalControl.Instance.penPickedUp = true;
			}
			else if (this.gameObject.CompareTag("Journal"))
			{
				GlobalControl.Instance.journalPickedUp = true;
			}
			else if (this.gameObject.CompareTag("Rose"))
			{
				GlobalControl.Instance.rosePickedUp = true;
			}

		}
	}
}