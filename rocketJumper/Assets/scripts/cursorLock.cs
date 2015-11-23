using UnityEngine;
using System.Collections;

public class cursorLock : MonoBehaviour {

    bool locked = true;

	// Use this for initialization
	void Start () {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (locked == true)
            {
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
            else
            {
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }
        }

	}
}
