using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit {
	public GameObject sprite;
	public Unit(Vector3 pos){
		sprite = GameObject.FindGameObjectWithTag ("Builder");
		GameObject.Instantiate (sprite, new Vector3(pos.x, pos.y+0.2f, pos.z), Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
