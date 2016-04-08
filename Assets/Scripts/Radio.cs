using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

	private Helicopter heli;
	private AudioSource audioSourcePlayer;
	public AudioClip helicopterResponse;
	public AudioClip callHeli;
	private bool heliLocationFound = false;
	private bool heliCalled=false;


	void Start(){
		audioSourcePlayer = GetComponent<AudioSource>();
		heli = FindObjectOfType<Helicopter>();
	}



	void Update () {
		if( Input.GetButton("Call Heli") && heliLocationFound ==true){
			callHelicopter();
		}
	}
	
	public void callHelicopter(){
		if(heliCalled==false){
			audioSourcePlayer.clip = callHeli;
			audioSourcePlayer.Play();
			Invoke("HeliResponse",callHeli.length+1);
			heli.Helifly();
		}
		heliCalled = true;
	}


	void HeliResponse(){
			audioSourcePlayer.clip = helicopterResponse;
			audioSourcePlayer.Play();
			heli.CallHeli();
	}

	public void HeliLocationConfirmed(){
		heliLocationFound = true;
	}

}