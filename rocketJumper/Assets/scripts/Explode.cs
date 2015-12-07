﻿using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

    public GameObject Projectile = null;
    public float force = 100; // for AddExplosionForce - explosionForce
    Vector3 pos; //// for AddExplosionForce - explosionPosition
    public float radius = 10; // for AddExplosionForce - explosionRadius
    public float upMod = 0; // for AddExplosionForce - upwardsModifier - leaving this at zero, so that the explosion force will be easier to control and utilize
    public ForceMode fMode = ForceMode.Impulse; // for AddExplosionForce - ForceMode - 4 options: Force, Acceleration, Impulse and VelocityChange, no idea which is best

	public float forceV = 10; // for AddExplosionForce - explosionForce
	public float radiusV = 30; // for AddExplosionForce - explosionRadius
	public ForceMode fModeV = ForceMode.VelocityChange;

    //Vector3 TossDirection;
    //public float speed = 10;

	GameObject thing;
	public rockets rocketa;
    
	// Use this for initialization
    void Start () {
		thing = GameObject.Find ("f");
		rocketa = thing.GetComponent<rockets> ();
	}
	
	// Update is called once per frame
	void Update () {
        //OnCollisionEnter();

	}

    //collision - rocket with anything else
    void OnCollisionEnter(Collision other)
    {
		if (rocketa.vineTrue == true) 
		{
			if(other.gameObject.tag == "block")
			{
				other.gameObject.GetComponent<Renderer>().material.color = Color.green;
				Destroy(gameObject); // destroys the projectile after impact

			}
		} 
		if (rocketa.vortexTrue == true) 
		{
			pos = transform.position; //should be the projectile itself
			Collider[] colliders = Physics.OverlapSphere(pos, radiusV);
			foreach (Collider hit in colliders)
			{
				Rigidbody rb = hit.GetComponent<Rigidbody>();
				if (rb != null)
				{
					rb.AddExplosionForce(-forceV, pos, radiusV, upMod, fModeV);
				}//if
			}//foreach
			
			Destroy(gameObject); // destroys the projectile after impact
		} 
		else 
		{
			pos = transform.position; //should be the projectile itself
			Collider[] colliders = Physics.OverlapSphere(pos, radius);
			foreach (Collider hit in colliders)
			{
				Rigidbody rb = hit.GetComponent<Rigidbody>();
				if (rb != null)
				{
					rb.AddExplosionForce(force, pos, radius, upMod, fMode);
				}//if
                    /*
				else if (hit.transform.gameObject.tag == "Player")
                {
                    TossDirection = hit.transform.position - pos;
                    //hit.transform.gameObject.GetComponent<CharacterController>().Move(TossDirection * speed); //error - script is trying to access character controller of capsule which doesn't exist
                    //hit.gameObject.GetComponent<CharacterController>().Move(TossDirection * speed); //error - script is trying to access character controller of capsule which doesn't exist
                    //hit.transform.parent.gameObject.GetComponent<CharacterController>().Move(TossDirection * speed); //error - no character controller attached to firstpersoncontroller. We have to go deeper.
                    hit.transform.parent.parent.gameObject.GetComponent<CharacterController>().Move(TossDirection * speed); //holy shit it actually works
                    //hit.transform.parent.transform.parent.gameObject.GetComponent<CharacterController>().Move(TossDirection * speed);
                }*/
			}//foreach
			
			Destroy(gameObject); // destroys the projectile after impact
		}
		Destroy(gameObject); // destroys the projectile after impact

    }
}
