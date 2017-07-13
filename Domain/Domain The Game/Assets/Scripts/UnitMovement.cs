using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitMovement : MonoBehaviour
{
	public int x = 0;
	public int z = 0;
	public GameObject commandCentre;
	Rigidbody rb;
	float xfactor = 0.882f;
	float zfactor = 0.764f;
	float xcorrection = 0.441f;
	Transform firePosition;
	GameObject minicommand;
	// Use this for initialization

	void Start () 
	{
		float xPos = x*xfactor;
		float zPos = z*zfactor;
		if (z%2 == 1){
			xPos += xcorrection;
		}
		GameObject minicommand = GameObject.Instantiate (commandCentre, new Vector3 (xPos, 0.2f, zPos), Quaternion.identity);
		minicommand.name = "Command Number:(" + x + "," + z + ")"; 
		minicommand.transform.SetParent (this.transform);
		Rigidbody rb = minicommand.GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}

	public class Stuff
	{
		public int bullets;
		public int grenades;
		public int rockets;

		public Stuff(int bul, int gre, int roc)
		{
			bullets = bul;
			grenades = gre;
			rockets = roc;
		}
	}


	public Stuff myStuff = new Stuff(10, 7, 25);
	public float speed;
	public float turnSpeed;
	public Rigidbody bulletPrefab;

	public float bulletSpeed;


	void Update ()
	{
		Movement();

	}


	void Movement ()
	{
		float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

		transform.Translate(Vector3.forward * forwardMovement);
		transform.Rotate(Vector3.up * turnMovement);
	}
}