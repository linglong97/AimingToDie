using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public int xsize;
	public int zsize;
	public GridTile[,] gridArray;
	public Vector2 activeTilePos;

	/*public Grid (int _xsize, int _zsize, GameObject _hexPrefab){
		xsize = _xsize;
		zsize = _zsize;
		gridArray = new GridTile[xsize,zsize];
		hexPrefab = _hexPrefab;
	}*/
	public void generateGrid(){
		for (int i=0; i<xsize; i++){
			for (int j=0; j<zsize; j++){
				gridArray[i,j] = new GridTile(new Vector2(i,j));
				gridArray[i,j].setGrass();
			}
		}
		gridArray [0, 0].setUnit ();
		activeTilePos = new Vector2 (-1, -1);
	}

	void Start () {
		//Grid gameGrid = new Grid(xsize, zsize, hexPrefab);
		gridArray = new GridTile[xsize,zsize];
		generateGrid();
	}

	public void changeActiveTile(Vector3 pos){
		float xfactor = 0.882f;
		float zfactor = 0.764f;
		float xcorrection = 0.441f;

		float xPos;
		int zPos;

		zPos = (int)(pos.z / zfactor);
		if (zPos % 2 == 1) {
			pos.x -= xcorrection;
		}
		xPos = pos.x / xfactor;

		if (activeTilePos != new Vector2 (-1, -1)){
			gridArray [(int)activeTilePos.x, (int)activeTilePos.y].tile.transform.position = 
				new Vector3 (gridArray [(int)activeTilePos.x, (int)activeTilePos.y].tile.transform.position.x, 0, gridArray [(int)activeTilePos.x, (int)activeTilePos.y].tile.transform.position.z);
		}
		gridArray[(int)xPos,(int)zPos].tile.transform.position=  
			new Vector3 (gridArray [(int)xPos,(int)zPos].tile.transform.position.x, 1, gridArray [(int)xPos,(int)zPos].tile.transform.position.z);

		activeTilePos = new Vector2 (xPos, zPos);
	}
}
