using UnityEngine;
using System.Collections;

public class rockets : MonoBehaviour {

    // Variable Declaration
    public Rigidbody Projectile = null;
    public Transform Launcher = null;
    private const int SPAWN_DISTANCE = 0;
    public int power = 50;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Rigidbody clone;
        clone = Instantiate(Projectile, Launcher.transform.position + SPAWN_DISTANCE * Launcher.transform.forward, transform.rotation) as Rigidbody;
        clone.velocity = transform.TransformDirection(Vector3.forward * power);
        Explode explo = (Explode)clone.gameObject.AddComponent(typeof(Explode)); //clone.AddComponent<Explode>();
        //Destroy(clone);
    }
}
