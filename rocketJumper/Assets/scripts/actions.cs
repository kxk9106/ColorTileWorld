using UnityEngine;
using System.Collections;

public class actions : MonoBehaviour {
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	GameObject con;
	CharacterController charControl;

	// Use this for initialization
	void Start () {
		con = GameObject.Find ("FPSController");
		//charControl = con.GetComponent<CharacterController> ();
        charControl = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other){
		if (gameObject.GetComponent<Renderer>().material.color == Color.green) {
			Debug.Log("Greenss");
			if(charControl.isGrounded){
				Debug.Log("YOOOO");
				moveDirection = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				if(Input.GetButton ("Jump"))
				{
					moveDirection.y = jumpSpeed;
				}
			}
			moveDirection.y -=gravity * Time.deltaTime;
			charControl.Move(moveDirection * Time.deltaTime);
			//charControl.Move(transform.TransformDirection(Vector3.forward));
		}

	}
}
