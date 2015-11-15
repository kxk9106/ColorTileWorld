﻿using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

    public GameObject Projectile = null;
    public float force = 100; // for AddExplosionForce - explosionForce
    Vector3 pos; //// for AddExplosionForce - explosionPosition
    public float radius = 10; // for AddExplosionForce - explosionRadius
    public float upMod = 0; // for AddExplosionForce - upwardsModifier - leaving this at zero, so that the explosion force will be easier to control and utilize
    public ForceMode fMode = ForceMode.Impulse; // for AddExplosionForce - ForceMode - 4 options: Force, Acceleration, Impulse and VelocityChange, no idea which is best

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //OnCollisionEnter();

	}

    //collision - rocket with anything else
    void OnCollisionEnter(Collision other)
    {
        //
        pos = transform.position; //should be the projectile itself
        Collider[] colliders = Physics.OverlapSphere(pos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, pos, radius, upMod, fMode);
            }//if

        }//foreach

        Destroy(gameObject); // destroys the projectile after impact
    }
}