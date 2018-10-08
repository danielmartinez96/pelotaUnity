using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
	
	private Transform TFromCamera;
	private Transform TFromParent;
	private Vector3 localRotation;
	private float cameraDistance=10f;

	public float MouseSensitivity=4f;
	public float ScrollSensitivity=2f;
	public float OrbitSpeed=10f;
	public float ScrollSpeed=6f;

	private bool cameraDisabled=true;

	// Use this for initialization
	void Start () {
		TFromCamera= this.transform;
		TFromParent= this.transform.parent;
		localRotation.y=45f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			cameraDisabled=!cameraDisabled;
		}

		if(!cameraDisabled)
		{
			if(Input.GetAxis("Mouse X")!=0 || Input.GetAxis("Mouse Y")!=0)
			{
				localRotation.x+=Input.GetAxis("Mouse X")*MouseSensitivity;
				localRotation.y-=Input.GetAxis("Mouse Y")*MouseSensitivity;

				localRotation.y= Mathf.Clamp(localRotation.y,0f,90f);
			}

			if(Input.GetAxis("Mouse ScrollWheel")!=0f)
			{
				float ScrollAmount= Input.GetAxis("Mouse ScrollWheel")*ScrollSensitivity;
				
				// segun la distancia
				ScrollAmount= ScrollAmount *(this.cameraDistance * 0.3f);
				
				this.cameraDistance +=(ScrollAmount * -1f);
				
				this.cameraDistance= Mathf.Clamp(this.cameraDistance,1.5f,100f);

			}
		//Rotacion
		Quaternion qt= Quaternion.Euler(localRotation.y,localRotation.x,0);
		this.TFromParent.rotation= Quaternion.Lerp(this.TFromParent.rotation,qt,Time.deltaTime * OrbitSpeed);
		//Zoom
		if(TFromCamera.localPosition.z != cameraDistance * -1f)
		{
			TFromCamera.localPosition = new Vector3(0f,0f,Mathf.Lerp(TFromCamera.localPosition.z,cameraDistance*-1f,Time.deltaTime*ScrollSpeed));
		}
	  }

		
	}


}
