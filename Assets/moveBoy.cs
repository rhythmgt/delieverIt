using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveBoy : MonoBehaviour {

    private static ILogger logger = Debug.unityLogger;

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveU;
    private const float Sec = 0.5f;
    private const float Sec2 = 0.5f;
    public int position = 0;
    public float velRL = 0;
    public float velUP = 0;
    public int height = 0;
    public float velFor = 8;
    public Text scoretext;
    public int ctr = 0;
    public int level;

    public Text leveltext;

    public float currZ = -20;
    public float currY = -4;
    
    public Vector3 direction = new Vector3(0,0,0);


    public Transform toBeRepeated;
    public Gyroscope abc;

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        //Input.gyro.enabled = true;
        rb = this.GetComponent<Rigidbody>();
        myStatVar.forwardVel = 10;
        myStatVar.upwardVel = 0;
        myStatVar.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Quaternion rot = Input.gyro.attitude;
        //Debug.Log("x:" + rot.x + " y:" + rot.y + " z:" + rot.z);

        rb.velocity = new Vector3(velRL, velUP, myStatVar.forwardVel);

        float idharUdhar = Input.acceleration.x;

        
            velRL = idharUdhar * 20;
        
        /*
        if (Input.GetKeyDown(moveL) && position >-1)
        {
            velRL = -12;
            StartCoroutine(MyCoroutine());
            position--;
            logger.Log(position);

        }
        else if (Input.GetKeyDown(moveR) && position < 1)
        {
            velRL = 12;
            StartCoroutine(MyCoroutine());
            position++;
            logger.Log(position);
        }

        */

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            myStatVar.forwardVel = 0;
            SceneManager.LoadScene("gameOver");
        }
    }


    void OnTriggerEnter(Collider cld)
    {
        if (cld.gameObject.name == "MyTrigger")
        {
            //float posY = transform.position.y;
            //float posZ = transform.position.z;
            //Debug.Log("HO GYA");
            //currY += 24.8f;
            currZ += 280f;
            myStatVar.upwardVel = (float) 0.5*myStatVar.forwardVel;
            velUP = myStatVar.upwardVel;
            Instantiate(toBeRepeated, new Vector3(0, currY, currZ), toBeRepeated.rotation);
        }
        if (cld.gameObject.name == "MyTrigger2")
        {
            //Debug.Log("HO GYA 2");
            myStatVar.upwardVel = 0;
            velUP = myStatVar.upwardVel;
            myStatVar.forwardVel += 2;
            ctr++;
            if (ctr==2)
            {
                level++;
                ctr = 0;
            }
            GetComponent<Rigidbody>().velocity = new Vector3(velRL, velUP, 8);
        }
        if (cld.gameObject.name == "Trigger3")
        {
            myStatVar.upwardVel = (float)-0.5 * myStatVar.forwardVel;
            velUP = myStatVar.upwardVel;
        }
        if (cld.gameObject.name == "Trigger4")
        {
            myStatVar.upwardVel = 0;
            velUP = myStatVar.upwardVel;
        }
        if (cld.gameObject.name == "TriggerLeft" || cld.gameObject.name == "TriggerRight")
        {
            Destroy(gameObject);
            myStatVar.forwardVel = 0;
            SceneManager.LoadScene("gameOver");
        }
    }



    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(Sec);
        //yield return new WaitForSeconds(seconds : Sec);
        velRL = 0;
    }

    IEnumerator JumpDur()
    {
        yield return new WaitForSeconds(Sec2);
        height++;

        
       

        velUP = -12;
        yield return new WaitForSeconds(Sec2);
        height--;
        velUP = 0;
        transform.position = new Vector3(transform.position.x,-1.76f, transform.position.z);


    }


    public void ButtonInteract()
    {
       if (height == 0)
        {
            velUP = 12;
            StartCoroutine(JumpDur());
        }
           
            //StartCoroutine(JumpDur2());
        
    }
    public void ButtonQuit()
    {
        SceneManager.LoadScene("mainMenu");

        //StartCoroutine(JumpDur2());

    }

    private void FixedUpdate()
    {
        myStatVar.score += 1;
        scoretext.text = myStatVar.score.ToString();
        leveltext.text = "Level: " + level.ToString();


        /*
        float temp = Input.acceleration.x;
        if (temp < -0.3)
        {
velRL = -12;
            StartCoroutine(MyCoroutine());
            position--;

            Debug.Log(position);

        }
        else if (temp > 0.3)
        {
            velRL = 12;
            StartCoroutine(MyCoroutine());
            position++;
            Debug.Log(position);
            }
            */
        
    }

}
