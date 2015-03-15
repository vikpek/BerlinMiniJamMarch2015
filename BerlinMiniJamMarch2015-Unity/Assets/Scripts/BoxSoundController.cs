using UnityEngine;
using System.Collections;

public class BoxSoundController : MonoBehaviour {

	[SerializeField]
	AudioClip explosionClip; 
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playExplosion()
	{
		GetComponent<AudioSource>().clip = explosionClip;
		GetComponent<AudioSource>().Play();
	}
}
