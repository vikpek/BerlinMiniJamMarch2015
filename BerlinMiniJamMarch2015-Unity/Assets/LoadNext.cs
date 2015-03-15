using UnityEngine;
using System.Collections;

public class LoadNext : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadMain(){
		Application.LoadLevel("Main");
	}
	public void Close(){
		//print ("");
		Application.Quit();
	}
}
