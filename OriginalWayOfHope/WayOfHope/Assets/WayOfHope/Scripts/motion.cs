using UnityEngine;
using System.Collections;

public class motion : MonoBehaviour
{
	public Transform PlayerCam;
	public int pridgok = 5;
	public int speed = 1, speed2=40;
	public float mouse = 0.1f, cat = 600;
	float a;
	void Update()
	{
		float x = Input.GetAxis("Mouse X");
		if (Mathf.Abs(x) > mouse)
		{
			transform.Rotate(Vector3.up, x * Time.deltaTime * cat);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(-Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(-Vector3.right * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.X))
		{
			transform.Translate(Vector3.up * pridgok * Time.deltaTime);
		}
		if( Input.GetKey(KeyCode.LeftShift)&& a<=400)
		{
			a = a + 1;
			if (Input.GetKey(KeyCode.W))
			{
				a = a + 1;
				transform.Translate(Vector3.forward * speed2 * Time.deltaTime);
			}
		}
		if (a!=0)
		{
			a = a - 0.5f;
		}

	}
}