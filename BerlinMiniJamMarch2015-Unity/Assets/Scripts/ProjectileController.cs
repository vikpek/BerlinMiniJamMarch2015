using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public int projectileType{get; set;}

	void OnTriggerEnter2D (Collider2D other)
	{
		StartCoroutine(DestroyDelayed());
		transform.GetComponent<ParticleSystem>().Play();
	}

	IEnumerator DestroyDelayed ()
	{
		this.GetComponent<SpriteRenderer>().enabled = false;
		transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		yield return new WaitForSeconds (10f);
		Destroy(this);
	}
}
