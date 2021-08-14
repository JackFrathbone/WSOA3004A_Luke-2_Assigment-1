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
            Moved = true;
            directiontxt.text = "left";
            StartCoroutine("PauseHandler");
        }
        if (MoveX < -Threshold && Moved == false)//left
        {
            Moved = true;
            directiontxt.text = "right";
            StartCoroutine("PauseHandler");
        }
        if (MoveY > Threshold && Moved == false)//up
        {
            Moved = true;
            directiontxt.text = "down";
            StartCoroutine("PauseHandler");
        }
        if (MoveY < -Threshold && Moved == false)//down
        {
            Moved = true;
            directiontxt.text = "up";
            StartCoroutine("PauseHandler");
            
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
            OrientationAlert.SetActive(false);
            Orienttxt.SetActive(false);
            Time.timeScale = 1f;

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
        else
        {
            OrientationAlert.SetActive(true);
            Orienttxt.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
