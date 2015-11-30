using UnityEngine;
using System.Collections;

public class moveUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (Input.GetKeyDown(KeyCode.W)) {
			Debug.Log("hi");
		}
	}
}
