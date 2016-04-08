using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

	public AudioSource audioSourcePlayer;
	public AudioClip areaConfirmed;
	public AudioClip whatHappened;
	private Radio radio;
	private PlayerController playerController;

	void Start () {
		radio = FindObjectOfType<Radio>();
		playerController = FindObjectOfType<PlayerController>();
	}

	public void PlayAudio(){
		audioSourcePlayer.Play();
	}

	public void CanCallHeli(){
		audioSourcePlayer.clip = areaConfirmed;
		Invoke("PlayAudio", 0.00001f);
		radio.HeliLocationConfirmed();
		playerController.DropFlare();
	}

	public void WhatHappened(){
		audioSourcePlayer.clip = whatHappened;
		audioSourcePlayer.Play();
	}


}
