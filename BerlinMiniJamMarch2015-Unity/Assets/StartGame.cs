using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public MapRotate rotationScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit2D(Collider2D other) {
		//print ("collision");
		if(other.tag=="Player"){
			print ("StartGame");
			rotationScript.StartRotation();
			Destroy(this.gameObject);
		}

	}


}
