using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public int xsize;
	public int zsize;
	public GridTile[,] gridArray;
	public Vector2 activeTilePos;
	public Vector2 prevActiveTilePos;
	public bool movementFlag = false;

	public void generateGrid(){
		for (int i=0; i<xsize; i++){
			for (int j=0; j<zsize; j++){
				gridArray[i,j] = new GridTile(new Vector2(i,j));
				gridArray[i,j].setGrass();
			}
		}
		gridArray [0, 0].setUnit ();
		activeTilePos = new Vector2 (-1, -1);
		prevActiveTilePos = new Vector2 (-1, -1);
	}

	void Start () {
		gridArray = new GridTile[xsize,zsize];
		generateGrid();
	}

	void ChangeHeight(int xcoord, int ycoord, int height){
		gridArray[xcoord, ycoord].tile.transform.position = 
			new Vector3 (gridArray [xcoord, ycoord].tile.transform.position.x, 
				height, gridArray [xcoord, ycoord].tile.transform.position.z);
	}
			
	public void changeActiveTile(Vector3 pos){
		Vector2 coords = new Vector2();
		coords = GridTile.convertToGrid(pos);
		int xPos = (int)coords.x;
		int zPos = (int)coords.y;

		if (activeTilePos != new Vector2 (-1, -1)){
			ChangeHeight ((int)activeTilePos.x, (int)activeTilePos.y, (int)0);
		}
		ChangeHeight (xPos, zPos, 1);
		prevActiveTilePos = activeTilePos;
		activeTilePos = new Vector2 (xPos, zPos);
	}

	public void setMovementFlag(){
		if ((prevActiveTilePos != activeTilePos)&(activeTilePos!=new Vector2 (-1, -1)))
				movementFlag = true;
	}

	public void movement(){
		gridArray [(int)prevActiveTilePos.x, (int)prevActiveTilePos.y].destroyUnit ();
		gridArray [(int)activeTilePos.x, (int)activeTilePos.y].setUnit();
		movementFlag = false;
	}
		

}
