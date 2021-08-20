using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    float MoveX = 0f;
    float MoveY = 0f;
    Vector3 AccelVect;

    bool Moved = false;

    public float Threshold = 1.5f;
    public float DetectionDelay = 1f;


    public Text directiontxt;
    public Text LRText;
    public Text UDText;

    public GameObject OrientationAlert;
    public GameObject Orienttxt;


    //threshold timer
    float tempTime=0;
    public float thresholdTimer=0.3f;
    bool isMoving = false;



    //detection of movement
    //if made a move should stop detecting for +-1f seconds

    private void Start()
    {
        directiontxt.text = "waiting";
    }

    private void Update()
    {
        AcceleHandler();
        //OrientHandler();
    }



    void AcceleHandler()
    {
        AccelVect = Input.acceleration;
        MoveX = AccelVect.x;//left right
        MoveY = AccelVect.y;//up down

        OrientHandler();


        LRText.text = "L/R: " + Mathf.Round(MoveX*10f)/10f;

        UDText.text = "U/D: " + Mathf.Round(MoveY * 10f) / 10f;




        if (MoveX > Threshold && Moved == false)//right
        {
            if (isMoving == false)
            {
                tempTime = Time.time;
                isMoving = true;
            }
            

            if (Time.time - tempTime >= thresholdTimer)
            {
                //do the thing
                Debug.Log("held or threshold time");

                Moved = true;
                directiontxt.text = "left";
                isMoving = false;
                StartCoroutine("PauseHandler");

            }
        
        }
        if (MoveX < -Threshold && Moved == false)//left
        {
            if (isMoving == false)
            {
                tempTime = Time.time;
                isMoving = true;
            }

            if (Time.time - tempTime >= thresholdTimer)
            {
                //do the thing
                Debug.Log("held or threshold time");

                Moved = true;
                directiontxt.text = "right";
                isMoving = false;
                StartCoroutine("PauseHandler");
            }
               
        }
        if (MoveY > Threshold && Moved == false)//up
        {

            if (isMoving == false)
            {
                tempTime = Time.time;
                isMoving = true;
            }
            if (Time.time - tempTime >= thresholdTimer)
            {
                Moved = true;
                directiontxt.text = "down";
                isMoving = false;
                StartCoroutine("PauseHandler");
            }
        }
        if (MoveY < -Threshold && Moved == false)//down
        {

            if (isMoving == false)
            {
                tempTime = Time.time;
                isMoving = true;
            }

            if (Time.time - tempTime >= thresholdTimer)
            {
                Moved = true;
                directiontxt.text = "up";
                isMoving = false;
                StartCoroutine("PauseHandler");
            }
            
        }



    }


    void ThresholdPassed()
    {
        //if ()
        //{
            tempTime = Time.time;
        //}

        if (Time.time - tempTime >= thresholdTimer)
        {
            //do the thing
            Debug.Log("held or threshold time");
        }
    }



    IEnumerator PauseHandler()
    {
        //directiontxt.text = "" + Direc;
        Debug.Log("MOVED");
        yield return new WaitForSeconds(DetectionDelay);
        directiontxt.text = "waiting";
        Moved = false;
    }


    void OrientHandler()
    {
        //change in orientation to account for gravity
        //Debug.Log(Input.deviceOrientation);
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {

            if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                MoveY += 1;
            }
            else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            {

                MoveX += -1;
            }

            Debug.Log(Input.deviceOrientation);
        }

    }

}
