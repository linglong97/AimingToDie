using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile{
	public GameObject tile;
	private Unit unit;
	public static float xfactor = 0.882f;
	public static float zfactor = 0.764f;
	public static float xcorrection = 0.441f;
	public Vector3 position3D;
	public Vector2 coords;


	public GridTile(Vector2 _coords){
		coords = _coords;
		position3D = convertToPos(_coords);
		unit = null;
	}

	public static Vector2 convertToGrid(Vector3 pos){
		int zPos = (int)(pos.z / zfactor);
		if (zPos % 2 == 1) {
			pos.x -= xcorrection;
		}
		int xPos = (int)(pos.x / xfactor);
		return new Vector2 (xPos, zPos);
	}

	public static Vector3 convertToPos(Vector2 grid){
		float xPos = grid.x*xfactor;
		float zPos = grid.y*zfactor;
		if (grid.y%2 == 1){
			xPos += xcorrection;
		}
		Vector3 _position3D = new Vector3(xPos, 0, zPos);
		return _position3D;
	}

	bool hasObject(){
		return (unit == null);
	}

	public void setUnit(){
		unit = new Unit(position3D);
	}

	public Unit getUnit(){
		return unit;
	}

	public void destroyUnit(){
		UnityEngine.Object.Destroy (Unit.unitname);
	}
		
	public void setGrass(){
		GameObject tileObject = GameObject.FindGameObjectWithTag ("Grass");;
		tile = GameObject.Instantiate(tileObject, position3D, Quaternion.Euler(new Vector3(-90, 0, 0)));
	}

}
