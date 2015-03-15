using UnityEngine;
using System.Collections;

public class MapRotate : MonoBehaviour {


	float rotationSpeed = 2;
	public int rotationAmount = 90;
	public int rotationTime = 2;
	public float rotationPause = 2;	
	private bool rotateIt=false;
	public bool active = true;
	// Use this for initialization
	void Start () {
		rotationSpeed=rotationAmount/rotationTime;
//		StartCoroutine(rotate());

	}
	
	// Update is called once per frame
	void Update () {
		if(rotateIt){
		transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
		}
	}
	public void StartRotation(){
		StartCoroutine(rotate());
	}
	IEnumerator rotate(){
		while (active){
			yield return new WaitForSeconds(rotationPause);
			rotateIt=true;
			yield return new WaitForSeconds(rotationTime);
			rotateIt=false;
		}

	}

}
