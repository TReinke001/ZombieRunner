using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	private Camera eyes;
	private float defaultFOV = 60;


	// Use this for initialization
	void Start () {
	
		eyes = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButton("Zoom")){
			VisionZoom();
		}
		else if(eyes.fieldOfView < defaultFOV){
			eyes.fieldOfView += 2f;
		}
		else{eyes.fieldOfView = defaultFOV;
		}
	
	}

	public void VisionZoom(){

		if(eyes.fieldOfView> (defaultFOV*0.5f))

		eyes.fieldOfView -= 1f;

		else{

		eyes.fieldOfView = (defaultFOV*0.5f);
		}
	}
}
