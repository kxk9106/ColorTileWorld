using UnityEngine;
using System.Collections;

public class restartCheck : MonoBehaviour {
	Vector3 restartLoc;
	GameObject player;

	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		restartLoc = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y <= -1.5f) {
			player.transform.position = restartLoc;
			Debug.Log("triggered");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player") {
			player.transform.position = restartLoc;
			Debug.Log ("hi");
		}

	}
}
