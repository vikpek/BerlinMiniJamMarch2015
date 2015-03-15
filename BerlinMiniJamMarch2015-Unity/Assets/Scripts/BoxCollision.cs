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

			if(Type == 0)
			{
				GetComponentInParent<BoxSoundController>().playExplosion();	
				GetComponent<BoxCollider2D>().enabled = false;
				GetComponent<SpriteRenderer>().enabled = false;
				StartCoroutine(DestroyDelayed());
			}
			if (other.gameObject.GetComponent<ProjectileController> ().projectileType == Type) {
				GetComponentInParent<BoxSoundController>().playExplosion();	
				this.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
				this.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
				StartCoroutine(DestroyDelayed());
			}
		}
	}

	IEnumerator DestroyDelayed ()
	{
		yield return new WaitForSeconds (1f);
		Destroy (this.transform.parent.gameObject);
	}
	/*
	void OnCollisionEnter2D(Collision2D other) {
		print ("collsion");
		if(other.gameObject.tag=="Projectile"){
			print ("collsion2");
		}

	}*/
}
