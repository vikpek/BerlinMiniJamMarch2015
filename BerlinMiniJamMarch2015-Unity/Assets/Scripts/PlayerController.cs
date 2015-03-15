using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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


	int currentWeapon = 1;

	string hudText;

	// Use this for initialization
	void Start ()
	{
		hudText = "" +
			"1 : Turquoise \n " +
			"2 : Yellow \n " +
			"3 : Red \n " +
			"4 : Orange \n " +
			"Current Weapon: \n";
	}

	void Update ()
	{

		LarpToZeroRotation();
		Move ();
		Shoot ();
		SelectWeapon();

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
				GetComponent<AudioSource>().Play ();
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

	void SelectWeapon ()
	{
		if (Input.GetKey ("1")) {
			currentWeapon = 1;
			GameObject.FindGameObjectWithTag("WeaponText").GetComponent<Text>().text = hudText + "Turquoise";
		}else if (Input.GetKey ("2")) {
			currentWeapon = 2;
			GameObject.FindGameObjectWithTag("WeaponText").GetComponent<Text>().text = hudText + "Yellow";
		}else if (Input.GetKey ("3")) {
			currentWeapon = 3;
			GameObject.FindGameObjectWithTag("WeaponText").GetComponent<Text>().text = hudText + "Red";
		}else if (Input.GetKey ("4")) {
			currentWeapon = 4;
			GameObject.FindGameObjectWithTag("WeaponText").GetComponent<Text>().text = hudText + "Orange";
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
		projectileObject.GetComponent<ProjectileController> ().projectileType = currentWeapon;
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
