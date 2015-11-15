using UnityEngine;
using System.Collections;

public class checkPoints : MonoBehaviour {

	Vector3 restartLoc;
	
	// Use this for initialization
	void Start () {
		restartLoc = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y <= -1.5f) {
			this.transform.position = restartLoc;
		}
		
	}
	
	void OnCollisionEnter(Collision other){
		//if ball goes over tile -> changes color
		if(other.gameObject.tag=="checkPoint"){
			restartLoc = other.gameObject.transform.position;
		}//if
	}
}
