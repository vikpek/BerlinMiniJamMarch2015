using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
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

	[SerializeField]
	float 
		normalizationRoationSpeed = 0.1f;

	bool lastFacingDirectionIsRight = true;
	bool canShoot = true;
	bool canJump = true;



	// Use this for initialization
	void Start ()
	{

	}

	void Update ()
	{

		LarpToZeroRotation();
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
	
		Vector3 tmp = transform.localScale;

		if (lastFacingDirectionIsRight) {
			tmp.x = Mathf.Abs(tmp.x);
			transform.localScale = tmp;

		} else {
			tmp.x = -Mathf.Abs(tmp.x);
			transform.localScale = tmp;
		}
		
	}

	void Shoot ()
	{
		if (canShoot) {
			if (Input.GetKey ("space")) {
				canShoot = false;
				StartCoroutine ("reload");

				if (lastFacingDirectionIsRight) {
					InstantiateProjectile(1);
				} else {
					InstantiateProjectile (-1);
				}
			}
		}
	}

	void LarpToZeroRotation ()
	{

		transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, normalizationRoationSpeed);
	}

	void InstantiateProjectile (int right)
	{
		GameObject projectileObject = (GameObject)Instantiate (projectile, transform.position + (right * Vector3.right), transform.rotation);
		projectileObject.GetComponent<ProjectileController> ().projectileType = 1;
		projectileObject.GetComponent<Rigidbody2D> ().AddForce (right * Vector2.right * projectileSpeed);
	}

	bool CheckIfInAir ()
	{
		if (canJump) {
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
