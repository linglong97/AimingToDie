using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {
	public int x = 0;
	public int z = 0;
	public GameObject commandCentre;
	float xfactor = 0.882f;
	float zfactor = 0.764f;
	float xcorrection = 0.441f;
	// Use this for initialization


	void Start () {
		float xPos = x*xfactor;
		float zPos = z*zfactor;
		if (z%2 == 1){
			xPos += xcorrection;
		}
		GameObject minicommand = GameObject.Instantiate (commandCentre, new Vector3 (xPos, 0.2f, zPos), Quaternion.identity);
		minicommand.name = "Command Number:(" + x + "," + z + ")"; 
		minicommand.transform.SetParent (this.transform);
	}
}
