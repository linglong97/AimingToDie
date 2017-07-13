using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteract : MonoBehaviour {
	Grid grid;
	// Use this for initialization
	void Start () {
		grid = GameObject.FindGameObjectWithTag ("Grid").GetComponent<Grid>();
	}

	// Update is called once per frame
	void Update () {
		
		if (grid.movementFlag == true){
			grid.movement();

		}
			
	}

	void OnMouseDown() {
		grid.setMovementFlag ();
		grid.changeActiveTile(transform.position);
	}
}
