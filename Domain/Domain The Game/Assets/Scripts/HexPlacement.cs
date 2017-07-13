using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPlacement : MonoBehaviour {
	public GameObject hexPrefab;
	public int xstart = 0;
	public int zstart = 0;
	public int xend = 10;
	public int zend = 10;
	float xfactor = 0.882f;
	float zfactor = 0.764f;
	float xcorrection = 0.441f;
	// Use this for initialization
	void Start () {
		for (int i = xstart; i < xend; i++) {
			for (int j = zstart; j < zend; j++){
				float xPos = i*xfactor;
				float zPos = j*zfactor;
				if (j%2 == 1){
					xPos += xcorrection;
				}
				GameObject minihex = GameObject.Instantiate(hexPrefab, new Vector3(xPos, 0, zPos), Quaternion.Euler(new Vector3(-90, 0, 0)));
				minihex.name = hexPrefab.name + "(" + i + "," + j + "" + ")";
				minihex.transform.SetParent (this.transform);
			}
		}
	}

}
