using UnityEngine;
using System.Collections;

public class Daycycle : MonoBehaviour {

	[Tooltip("Set number minutes in day")]
	public float timeScale = 8f;

	private Quaternion sunRotation;
	// Use this for initialization
	void Start () {
	

		sunRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		float angleThisFrame= (6f/timeScale)*Time.deltaTime;
		transform.RotateAround(transform.position,Vector3.forward, angleThisFrame);


	}


}
