using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInteract : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		Grid grid;
		grid = GameObject.FindGameObjectWithTag ("Grid").GetComponent<Grid>();
		grid.changeActiveTile(transform.position);
	}
}
