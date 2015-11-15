using UnityEngine;
using System.Collections;

public class ImpactReciever : MonoBehaviour {

    public float mass = 3.0f; //the characters mass
    Vector3 impact = Vector3.zero;
    CharacterController character;

	// Use this for initialization
	void Start () {

        character = GetComponent<CharacterController>();
        //character = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<CharacterController>();
	}

    void AddImpact(Vector3 force)
    {
        impact += force / mass;
    }
	
	// Update is called once per frame
	void Update () {
	    if(impact.magnitude > 0.2f)
        {
            character.Move(impact * Time.deltaTime);
        }

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
	}
}
