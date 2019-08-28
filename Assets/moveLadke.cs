using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLadke : MonoBehaviour {
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

    public float currZ = -20;
    public float currY = -4;

    public Vector3 direction = new Vector3(0, 0, 0);


    public Transform toBeRepeated;
    public Gyroscope abc;

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector3(velRL, velUP, 8);

        float idharUdhar = Input.acceleration.x;


        velRL = idharUdhar * 20;




    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider cld)
    {
        if (cld.gameObject.name == "MyTrigger")
        {
            //float posY = transform.position.y;
            //float posZ = transform.position.z;
            //Debug.Log("HO GYA");
            currY += 24.8f;
            currZ += 180f;
            myStatVar.upwardVel = 4;
            velUP = myStatVar.upwardVel;
            Instantiate(toBeRepeated, new Vector3(0, currY, currZ), toBeRepeated.rotation);
        }
        if (cld.gameObject.name == "MyTrigger2")
        {
            //Debug.Log("HO GYA 2");
            myStatVar.upwardVel = 0;
            velUP = myStatVar.upwardVel;
            GetComponent<Rigidbody>().velocity = new Vector3(velRL, velUP, 8);
        }
        if (cld.gameObject.name == "MyTrigger3")
        {
            transform.Rotate(0, -17, 0);
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


    }


    public void ButtonInteract()
    {

        velUP = 12;
        StartCoroutine(JumpDur());
        //StartCoroutine(JumpDur2());

    }

    

}
