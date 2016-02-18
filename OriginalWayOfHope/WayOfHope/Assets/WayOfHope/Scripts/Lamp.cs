using UnityEngine;
using System.Collections;

public class Lamp: MonoBehaviour {
	private int i;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			GetComponent<Light> ().enabled = !GetComponent<Light> ().enabled;
		}
	}
}
