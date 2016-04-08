using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	private bool isClear;
	private bool objInArea;
	private bool checkedArea=false;
	public float lastCheckedTime=0;


	
	void Start () {
		isClear = false;
	}

	void Update () {
		lastCheckedTime +=Time.deltaTime;
		if (lastCheckedTime > 3.0f && Time.realtimeSinceStartup>10  && checkedArea==false){
			checkedArea =true;
			SendMessageUpwards("CanCallHeli");
		}
	}

	void OnTriggerStay(Collider collider){
		GameObject obj = collider.gameObject;
		if(obj && obj.name != "Player"){
		isClear = false;
		lastCheckedTime= 0f;
		}
	
	}
	



}
