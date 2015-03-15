using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

	[SerializeField]
	float
		movementSpeed = 0.1f;
	[SerializeField]
	float
		projectileSpeed = 30f;
	[SerializeField]
	float
		jumpHeight = 3f;
	[SerializeField]
	GameObject
		projectile;
	[SerializeField]
	float
		shootingCooldown = 0.5f;
	[SerializeField]
	float
		jumpingCooldown = 0.5f;
	[SerializeField]
	float
		maximumJumpVelocity = 5f;

	bool lastFacingDirectionIsRight = true;
	bool canShoot = true;
	bool canJump = true;



	// Use this for initialization
	void Start ()
	{

	}

	void Update ()
	{


		Move ();
		Shoot ();

	}

	void Move ()
	{
		if (Input.GetKey ("right")) {
			transform.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * movementSpeed);
			lastFacingDirectionIsRight = true;
		}

		if (Input.GetKey ("left")) {
			transform.GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * movementSpeed);
			lastFacingDirectionIsRight = false;
		}

		if (Input.GetKey ("up")) {
			if (CheckIfInAir ()) {
				transform.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
			}
		}

		if (lastFacingDirectionIsRight) {
			transform.localScale = new Vector3 (1, 1, 1);

		} else {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		
	}

	void Shoot ()
	{
		if (canShoot) {
			if (Input.GetKey ("space")) {
				canShoot = false;
				StartCoroutine ("reload");

				if (lastFacingDirectionIsRight) {
					GameObject projectileObject = (GameObject)Instantiate (projectile, transform.position + Vector3.right, transform.rotation);
					projectileObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * projectileSpeed);
				} else {
					GameObject projectileObject = (GameObject)Instantiate (projectile, transform.position - Vector3.right, transform.rotation);
					projectileObject.GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * projectileSpeed);
				}
			}
		}
	}

	bool CheckIfInAir ()
	{
		if (canJump) {
			Debug.Log (transform.GetComponent<Rigidbody2D> ().velocity.y);
			if (transform.GetComponent<Rigidbody2D> ().velocity.y < 0) {
				return false;
			} else if (transform.GetComponent<Rigidbody2D> ().velocity.y > maximumJumpVelocity) {
				canJump = false;
				StartCoroutine ("reloadJump");	
			} else {
				return true;
			}
		}
		return false;
	}

	IEnumerator reload ()
	{
		yield return new WaitForSeconds (shootingCooldown);
		canShoot = true;
	}
	IEnumerator reloadJump ()
	{
		yield return new WaitForSeconds (jumpingCooldown);
		canJump = true;
	}
}
