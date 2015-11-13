using UnityEngine;
using System.Collections;

public class rockets : MonoBehaviour {

	public GameObject Projectile = null;
	public Transform Launcher = null;
	bool Ready = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			//shoot the shot
		}


		/*
		if(Ready == true)
		{
			//Ready = false;
			//FireProjectile();
		}
		else
		{
			//ReloadTimed += 0.1;
			//Debug.Log(ReloadTimed);
		}*/
	}
		
	void FireProjectile()
	{
		GameObject.Instantiate(Projectile,Launcher.transform.forward,transform.rotation);
	}

	//maybe set up some kind of timer to stop people from spamming, something like 1s or .5s
	void CheckReload()
	{
		if(ReloadTimed > ReloadTime)
		{
			ReloadTimed = 0;
			Ready = true;
		}
	}
	
}
