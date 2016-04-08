using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private GameObject playerSpawner;
	private InnerVoice innerVoice;
	public bool spawned;
	public GameObject flareArea;

	// Use this for initialization
	void Start () {
		playerSpawner = GameObject.Find("Player Spawn Points");
		spawned= false;
		innerVoice = GetComponent<InnerVoice>();


	}
	
	// Update is called once per frame
	void Update () {
		if(spawned ==false){
			ReSpawn();
		}
	
	}

	public void ReSpawn (){

		innerVoice.WhatHappened();
		Transform[] spawnLocations = playerSpawner.GetComponentsInChildren<Transform>();
		transform.position = spawnLocations[Random.Range(1,spawnLocations.Length)].position;
		spawned = true;
	}

	public void DropFlare(){
		GameObject	flare =Instantiate(flareArea,transform.position,Quaternion.identity) as GameObject;
		
	}
}
