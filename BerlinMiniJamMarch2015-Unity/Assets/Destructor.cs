using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Projectile")
		{
			Destroy(collider.gameObject);
		}
	}

}
