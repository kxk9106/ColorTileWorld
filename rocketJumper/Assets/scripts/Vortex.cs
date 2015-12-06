using UnityEngine;
using System.Collections;

public class Vortex : MonoBehaviour {

    public GameObject Projectile = null;
    Vector3 pos; //// for AddExplosionForce - explosionPosition
    public float upMod = 0; // for AddExplosionForce - upwardsModifier - leaving this at zero, so that the explosion force will be easier to control and utilize

    public float forceV = 35; // for AddExplosionForce - explosionForce
    public float radiusV = 50; // for AddExplosionForce - explosionRadius
    public ForceMode fModeV = ForceMode.Impulse;// for AddExplosionForce - ForceMode - 4 options: Force, Acceleration, Impulse and VelocityChange, no idea which is best

    GameObject thing;
    public rockets rocketa;

    // Use this for initialization
    void Start()
    {
        thing = GameObject.Find("f");
        rocketa = thing.GetComponent<rockets>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //collision - rocket with anything else
    void OnCollisionEnter(Collision other)
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
}
