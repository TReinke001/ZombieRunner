using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {


	public AudioClip callSound;
	private bool called = false;
	private AudioSource heliAudio;
	private Rigidbody rigidBody;
	private Animator animator;
	private Transform transform;
	private Vector3 destination;
	private bool landing = false;
	private LandingArea landingArea;
	private PlayerController player;
	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody>();
		heliAudio =GetComponent<AudioSource>();
		animator =GetComponent<Animator>();
		transform =GetComponent<Transform>();
		destination= new Vector3(250f,250f,250f);
		player = FindObjectOfType<PlayerController>();


	}
	

	void Update () {
		Helifly();
		HeliLand ();

	}
	

	public void Helifly(){

		if(called == true){
			landingArea = FindObjectOfType <LandingArea>();
		transform.position =Vector3.MoveTowards(transform.position,destination,30*Time.deltaTime);
			}
		if(transform.position ==  destination ){
			called=false;
			landing=true;
		}
	}

	public void HeliLand(){

		if(landing==true){
			Vector3 overLanding = new Vector3 (landingArea.transform.position.x,250f, landingArea.transform.position.z ) ;
			Vector3 atLanding = new Vector3  (landingArea.transform.position.x,landingArea.transform.position.y, landingArea.transform.position.z ) ;
			float HeliX = transform.position.x;
			float HeliY = transform.position.y;
			float HeliZ = transform.position.z;

			if (landing==true && HeliX != landingArea.transform.position.x && HeliZ  != landingArea.transform.position.z ){

				transform.position = Vector3.MoveTowards( transform.position, overLanding, 25f*Time.deltaTime);
			}
			else if(landing==true && HeliX == landingArea.transform.position.x && HeliZ  == landingArea.transform.position.z ){

				transform.position = Vector3.MoveTowards( transform.position ,atLanding, 25f*Time.deltaTime);
			}else if( landing==true && HeliX == landingArea.transform.position.x && HeliY  == landingArea.transform.position.y && HeliZ  == landingArea.transform.position.z){
				landing = false;
			}
		}


	}

	void OnTriggerEnter(Collider collider){
		Collider obj = collider;

		if(obj.name == "Player"){
			player.ReSpawn();
		}

	}


	public void CallHeli(){
		called=true;
	}

}
