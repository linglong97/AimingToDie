using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit{
	public GameObject sprite;
	public Vector3 pos;
	public Vector2 coords;
	public static GameObject unitname;


	public Unit(Vector3 _pos){
		sprite = GameObject.FindGameObjectWithTag ("Builder");
		pos = _pos;
		coords = GridTile.convertToGrid (_pos);
		unitname = GameObject.Instantiate (sprite, new Vector3(_pos.x, _pos.y+0.2f, _pos.z), Quaternion.Euler(new Vector3(0, 0, 0)));
	}


}
