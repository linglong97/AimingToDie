using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapCamera : MonoBehaviour {

	//swivel allows us to change angle of map, and stick alllows us to determine how far the camera is
	//technically don't need both, but better for documentation

	//TODO:
	// Limit movement to certain areas of map

	Transform swivel, stick;

	public float zoom = 1f; //default zoom
	public float stickMinZoom, stickMaxZoom, swivelMin, swivelMax;
	public float moveSpeed1, moveSpeed2;
	public float rotSpeed; 
	float angle;

	// Use this for initialization
	void Start () {
		swivel = transform.GetChild (0);
		stick = swivel.GetChild (0);
	}

	// Update is called once per frame
	void Update () {
		float zoomDistance = Input.GetAxis ("Mouse ScrollWheel");   //zoom distance from scroll wheel
		float xDistance = Input.GetAxis("Horizontal");	// x coordinate
		float zDistance = Input.GetAxis("Vertical");		//z coordinate
		float rotationDistance = Input.GetAxis("Rot"); //


		if (zoomDistance != 0f) {
			AdjustZoom (zoomDistance);
			}
		if (xDistance != 0f || zDistance !=0f){
			AdjustPos(xDistance,zDistance);
			}
		if (rotationDistance != 0f) {
			AdjustRot (rotationDistance);
		}
		}
	void AdjustRot(float delta){
		angle += delta * rotSpeed * Time.deltaTime;
		if (angle >= 360f) {
			angle = angle - 360f;
		} else if (angle < 0f) {
			angle = angle + 360f;
		}
			
		transform.localRotation = Quaternion.Euler (0f, angle, 0f);
	
	}
	
	void AdjustZoom(float delta){
		
		zoom = Mathf.Clamp01 (zoom + delta);
		float distance = Mathf.Lerp (stickMinZoom, stickMaxZoom, zoom); // distance viewing from camera
		stick.localPosition = new Vector3 (0f, 0f, distance);

		float angle = Mathf.Lerp (swivelMin, swivelMax, zoom);
		swivel.localRotation = Quaternion.Euler (angle, 0f, 0f);	// convert swivel angle to angle
	}


	void AdjustPos(float xDistance, float zDistance){
		float damper = Mathf.Max (Mathf.Abs (xDistance), Mathf.Abs (zDistance)); // makes the stopping smoother
		float dist = Mathf.Lerp(moveSpeed2, moveSpeed1, zoom) * Time.deltaTime * damper; // normalises the speed of moving zoomed in and out

		Vector3 pos = transform.localPosition;
		pos += transform.localRotation*new Vector3(xDistance, 0f, zDistance).normalized*dist;  //normalises movement in 2 directions at once
		transform.localPosition = pos;	

	}
}