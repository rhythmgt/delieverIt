using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonInteractPlay()
    {
        SceneManager.LoadScene("runIt");
        //StartCoroutine(JumpDur2());

    }

    public void ButtonInteractInst()
    {
        SceneManager.LoadScene("instructions");

        //StartCoroutine(JumpDur2());

    }
}
