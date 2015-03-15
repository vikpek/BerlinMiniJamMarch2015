using UnityEngine;
using System.Collections;

public class BoxCollision : MonoBehaviour
{
	// Use this for initialization
	public int Type = 1;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Projectile") {
			if (other.gameObject.GetComponent<ProjectileController> ().projectileType == Type) {
				Destroy (other.gameObject);
				Destroy (this.transform.parent.gameObject);

			}else {
				Destroy (other.gameObject);
			}
		}
		
	}
	/*
	void OnCollisionEnter2D(Collision2D other) {
		print ("collsion");
		if(other.gameObject.tag=="Projectile"){
			print ("collsion2");
		}

	}*/
}
