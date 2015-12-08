using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class checkPoints : MonoBehaviour {
	public Texture notActiveTexture;
	public Texture activeTexture;

	Vector3 restartLoc;
	GameObject[] checkPointFlags;

	public AudioClip flag;
	AudioSource here;

	// Use this for initialization
	void Start () {
		restartLoc = this.transform.position;
		checkPointFlags = GameObject.FindGameObjectsWithTag ("checkPoint");
		here = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y <= -1.5f) {
			this.transform.position = restartLoc;
			Debug.Log("triggered");
			here.PlayOneShot(flag,0.7F);
		}

		for(int i = 0; i< checkPointFlags.Length; i++){
			float distance = Vector3.Distance(this.transform.position,checkPointFlags[i].transform.position);
			if(restartLoc != checkPointFlags[i].transform.position){
				if(distance < 3.0f){
					restartLoc = checkPointFlags[i].transform.position; 
					checkPointFlags[i].GetComponent<Renderer>().material.mainTexture = activeTexture;
					Debug.Log("checkPoint");
					here.PlayOneShot(flag,0.7F);
				}
				else{
					checkPointFlags[i].GetComponent<Renderer>().material.mainTexture = notActiveTexture;
				}
			}
		}
		
	}

}
