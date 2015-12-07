using UnityEngine;
using System.Collections;

public class blockMovement : MonoBehaviour {
	public Vector3 translate;
	public Vector3 maxTranslate;
	Vector3 minTranslate;
	public Vector3 rotation;
	// Use this for initialization
	void Start () {
		minTranslate = this.transform.position - maxTranslate;
		maxTranslate += this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//translate the object over time
		if ((this.transform.position.x > minTranslate.x || this.transform.position.y > minTranslate.y || this.transform.position.z > minTranslate.z) && (
			this.transform.position.x < maxTranslate.x || this.transform.position.y < maxTranslate.y || this.transform.position.z < maxTranslate.z)) {
			this.transform.position += translate;
		} 
		else 
		{
			translate *= -1.0f;
			this.transform.position += translate;
		}
		// Rotate the object over time
		this.transform.Rotate (rotation * Time.deltaTime);
	}
}
