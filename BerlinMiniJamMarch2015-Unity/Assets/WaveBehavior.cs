using UnityEngine;
using System.Collections;

public class WaveBehavior : MonoBehaviour {


	int up = 1;

	[SerializeField]
	float movementSpeed = 10f;

	[SerializeField]
	float torqueSpeed = 10f;

	[SerializeField]
	float waveSize = 3f;

	// Use this for initialization
	void Start () {

		InvokeRepeating("SwitchForce", 0f, waveSize);

	}
	
	void SwitchForce()
	{
		GetComponent<ConstantForce2D>().relativeForce = (new Vector2(0f, movementSpeed * up));
		GetComponent<ConstantForce2D>().torque = torqueSpeed * up;
		up = up * -1;
	}
}
