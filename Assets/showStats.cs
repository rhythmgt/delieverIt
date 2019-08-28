using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class showStats : MonoBehaviour {

    public Text finalscore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        finalscore.text =  "SCORE: " +  myStatVar.score.ToString();


    }
    public void ButtonInteract2()
    {

        SceneManager.LoadScene("runIt");
    }

    public void gameOvertoMainMenu()
    {

        SceneManager.LoadScene("mainMenu");
    }

}
