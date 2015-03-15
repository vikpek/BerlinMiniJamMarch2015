using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public MapRotate rotationScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		//print ("collision");
		if(other.tag=="Player"){
			print ("EndGame");
			rotationScript.active=false;
			Cursor.visible = true;
			//Cursor.lockState = false;
			//Destroy(this.gameObject);
		}
		
	}
}
