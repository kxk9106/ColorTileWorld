using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class rockets : MonoBehaviour {

    // Variable Declaration
    public Rigidbody Projectile = null;
    public Transform Launcher = null;
    private const float SPAWN_DISTANCE = .5f;
    public int power = 50;
	public Button rock;
	public Button vortex;
	public bool rocketTrue;
	public bool vineTrue;
	public bool vortexTrue;
	GameObject[] blocks;

    public float reloadTime = 0.5f;
    private float timeLast = 0.0f;



    // Use this for initialization
    void Start()
    {
		rock.GetComponent<Image> ().color = Color.red;
		vortex.GetComponent<Image> ().color = Color.white;
		rocketTrue = true;
		vineTrue = false;
		vortexTrue = false; //added
		blocks = GameObject.FindGameObjectsWithTag ("block");
    }

    // Update is called once per frame
    void Update()
    {
	    //if button chosen changes color to red
	    //if not chosen changes color to white
	   /* if (Input.GetKeyDown (KeyCode.Q)) 
	    {
			vortex.GetComponent<Image>().color = Color.white;
	    	rock.GetComponent<Image>().color = Color.red;
	    	rocketTrue = true;
	    	vineTrue = false;
	    	vortexTrue = false; //added
	    	foreach (GameObject blo in blocks)
	    	{
	    		blo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	    	}

	    }

        if (Input.GetKeyDown (KeyCode.Alpha2)) 
	    {
	    	rock.GetComponent<Image>().color = Color.white;
	    	vin.GetComponent<Image>().color = Color.red;
	    	rocketTrue = false;
	    	vineTrue = true;
	    	vortexTrue = false; //added
	    	foreach (GameObject blo in blocks)
	    	{
	    		blo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	    	}
	    }

	    if (Input.GetKeyDown (KeyCode.E)) 
	    {
			rock.GetComponent<Image>().color = Color.white;
			vortex.GetComponent<Image>().color = Color.red;
	    	rocketTrue = false;
	    	vineTrue = false;
	    	vortexTrue = true; //added

	    	foreach (GameObject blo in blocks)
	    	{
	    		blo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	    	}
	    }*/
	    if (Input.GetMouseButton(0))
	    {
            if(Time.time - timeLast > reloadTime)
            {
				vortex.GetComponent<Image>().color = Color.white;
				rock.GetComponent<Image>().color = Color.red;
				rocketTrue = true;
				vineTrue = false;
				vortexTrue = false; //added
				foreach (GameObject blo in blocks)
				{
					blo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				}
				FireProjectile();
                timeLast = Time.time;
            }//reload time
	    }
		if (Input.GetMouseButton(1))
		{
			if(Time.time - timeLast > reloadTime)
			{
				rock.GetComponent<Image>().color = Color.white;
				vortex.GetComponent<Image>().color = Color.red;
				rocketTrue = false;
				vineTrue = false;
				vortexTrue = true; //added
				FireProjectile();
				timeLast = Time.time;
			}//reload time
		}
		
	}
	
	void FireProjectile()
	{
		Rigidbody clone;
        clone = Instantiate(Projectile, Launcher.transform.position + SPAWN_DISTANCE * Launcher.transform.forward, Launcher.transform.rotation) as Rigidbody;
        clone.velocity = transform.TransformDirection(Vector3.forward * power);
        Explode explo = (Explode)clone.gameObject.AddComponent(typeof(Explode)); //clone.AddComponent<Explode>();
        //Destroy(clone);
    }

	void FireVine()
	{
		
	}

	/*void FireVortex()
	{
		Rigidbody cloneV;
		cloneV = Instantiate(Projectile, Launcher.transform.position + SPAWN_DISTANCE * Launcher.transform.forward, Launcher.transform.rotation) as Rigidbody;
		cloneV.velocity = transform.TransformDirection(Vector3.forward * power);
		Explode explo = (Explode)cloneV.gameObject.AddComponent(typeof(Explode)); //clone.AddComponent<Explode>();
		//Destroy(clone);
	}*/
}
