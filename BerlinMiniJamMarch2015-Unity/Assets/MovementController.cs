using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	[SerializeField]
	float movementSpeed = 10f;

	[SerializeField]
	float jumpHeight = 3f;

	bool lastFacingDirectionIsRight = true;

	// Use this for initialization
	void Start () {
	
	}
	

	void Update () {
		Move();
		Shoot();

	}


	void Move()
	{
		if (Input.GetKey("right")){
			transform.GetComponent<Rigidbody2D>().velocity = Vector2.right * movementSpeed;
			lastFacingDirectionIsRight = true;
		}

		if (Input.GetKey("left")){
			transform.GetComponent<Rigidbody2D>().velocity = -Vector2.right * movementSpeed;
			lastFacingDirectionIsRight = false;
		}

		if (Input.GetKey("up")){
			transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHeight;
		}
	}

	void Shoot ()
	{
		if (Input.GetKey("space"))
			transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHeight;
	}
}
