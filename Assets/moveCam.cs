using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(0,  myStatVar.upwardVel, myStatVar.forwardVel);

        
    }
    void OnTriggerEnter(Collider cld)
    {
        if (cld.gameObject.name == "MyTrigger3")
        {
            transform.Rotate(0, -17, 0);
        }
    }
}
