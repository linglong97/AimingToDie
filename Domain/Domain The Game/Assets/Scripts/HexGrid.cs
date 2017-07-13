using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour {
	public GameObject hexPrefab;
	public GameObject commandCentre;
	public GameObject builder;
	public int size1 = 4;
	public int size2 = 4;
	float xfactor = 0.882f;
	float zfactor = 0.764f;
	public int builderx = 3;
	public int builderz = 3;
	// Use this for initialization

	void Start () {
		for (int x = 0; x < size1; x++) {
			for (int z = 0; z < size2; z++) {
				float xPos = x * xfactor;
				if (x == 1 && z == 1) {
					GameObject minicommand = GameObject.Instantiate (commandCentre, new Vector3 (0, 0.2f, 0), Quaternion.identity);
					minicommand.name = "Command Number: 1"; 
				}
				if (x == 3 && z == 3) {
					GameObject builder1 = GameObject.Instantiate (builder, new Vector3 (builderx*xfactor+0.441f, 0.2f	, builderz*zfactor), Quaternion.identity);
					builder1.name = "Builder: 1"; 
				}
				if (z % 2 == 1) {
					xPos += 0.441f;	
				}
				GameObject minihex = GameObject.Instantiate (hexPrefab, new Vector3 (xPos, 0, z * zfactor ),  Quaternion.Euler(new Vector3(-90, 0, 0)));
				minihex.name = "Hex(" + x + "," + z + "" + ")";
				minihex.transform.SetParent (this.transform);
			}
		}
	}
	new Vector3 newPos;


		
	// Update is called once per frame
	void Update () {
//		GameObject builder = GetComponent<GameObject>();
//		newPos = builder.transform.position;
//				if(Input.GetMouseButtonDown(0)){
//					RaycastHit hit;
//					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//					if(Physics.Raycast(ray, out hit)){
//						newPos = hit.point;
//
//						builder.transform.position=newPos;
					
				
					
	}
}
