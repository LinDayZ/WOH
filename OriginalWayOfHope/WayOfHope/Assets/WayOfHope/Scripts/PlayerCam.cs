using UnityEngine;

public class PlayerCam : MonoBehaviour {

	public float sensY = 25f;

	void Update () {

		float y = Input.GetAxis("Mouse Y");
		transform.Rotate(-Vector3.right, y * Time.deltaTime * sensY);
	}
}

