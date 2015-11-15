using UnityEngine;
using System.Collections;

public class restartCheck : MonoBehaviour {
	Vector3 restartLoc;
	GameObject player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		restartLoc = player.transform.position;
	}

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y <= -1.5f) {
			player.transform.position = new Vector3(restartLoc.x,restartLoc.y,restartLoc.z);
			Debug.Log ("position: " + restartLoc);

		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player") {
			player.transform.position = restartLoc;
			Debug.Log ("hi");
		}

	}
}
