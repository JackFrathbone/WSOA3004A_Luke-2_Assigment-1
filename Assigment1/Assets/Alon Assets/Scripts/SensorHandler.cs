using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorHandler : MonoBehaviour
{
    public string Orientation;
    public Text DirecTxt;
    public Text Calibratetxt;
    public Text AccelText;
    
    public float ScaleVal;


    public Text MaxAccelX;
    float MaxAccX = 0;

    public Text MaxAccelY;
    float MaxAccY = 0;
    bool calibrated = false;
    //phone co ords dont match with unit co ords if phone rotated



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CheckOrientation();
        //if (calibrated == true)
        // {
        MovementHandler();
        // }

        /*
        if (Input.acceleration.x * ScaleVal > MaxAccX)
        {
            MaxAccX = Input.acceleration.x * ScaleVal;
            MaxAccelX.text = "Max X: " + MaxAccX;
        }
        if (Input.acceleration.y * ScaleVal > MaxAccY)
        {
            MaxAccY = Input.acceleration.y * ScaleVal;
            MaxAccelY.text = "Max Y: " + MaxAccY;
        }
        */

        if (Input.GetMouseButtonDown(0) == true)
        {
            MaxAccX = 0;
            MaxAccelX.text = "Max X: " + MaxAccX;
            MaxAccY = 0;
            MaxAccelY.text = "Max Y: " + MaxAccY;
            
        }

    }

    void CheckOrientation()
    {
        //if (Input.acceleration.x < 1 && Input.acceleration.y < 1 && Input.acceleration.z < 1 && Input.acceleration.x > -1 && Input.acceleration.y > -1 && Input.acceleration.z > -1)
        //{
        //   DirecTxt.text = "Zero";
        // }

        //LandscapeLeft - The device is in landscape mode, with the device held upright and the home button on the right side.
        //LandscapeRight - The device is in landscape mode, with the device held upright and the home button on the left side.
        Debug.Log("Orientation " + Input.deviceOrientation);
        Debug.Log("Calibrated " + calibrated);
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Time.timeScale = 1f;
            calibrated = true;
            Calibratetxt.text = "Calibrated = " + calibrated;

        }
        else
        {
            Time.timeScale = 0f;

            calibrated = false;
            Calibratetxt.text = "Please rotate the device landscape.";
        }
    }


    void MovementHandler()
    {
        Vector3 Move = Input.acceleration * ScaleVal; //with some scale

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Move = Move + new Vector3(0, ScaleVal, 0);
            //Move = Quaternion.Euler(90, 90, 90) * MoveR;//how does direction change?
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Move = Move + new Vector3(0, ScaleVal, 0);
            //Move = Quaternion.Euler(90, 90, 90) * MoveR;//how does direction change?
        }
        else if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Move = Move + new Vector3(0, ScaleVal, 0);
            //Move = Quaternion.Euler(90, 90, 90) * MoveR;//how does direction change?
        }


        AccelText.text = "" + Move;



        if (Move.x > MaxAccX)
        {
            MaxAccX = Move.x;
            MaxAccelX.text = "Max X: " + MaxAccX;
        }
        if (Move.y > MaxAccY)
        {
            MaxAccY = Move.y;
            MaxAccelY.text = "Max Y: " + MaxAccY;
        }





        float Threshold = 1;




        if (Move.y > Threshold) //(0,1,0)
        {
            DirecTxt.text = "UP";
            Debug.Log("UP " + Move.y);
        }
        if (Move.y < -Threshold) //(0,-1,0)
        {
            DirecTxt.text = "DOWN";
            Debug.Log("DOWN " + Move.y);
        }
        if (Move.x < -Threshold) //(-1,0,0)
        {
            DirecTxt.text = "LEFT";
            Debug.Log("LEFT " + Move.x);
        }
        if (Move.x > Threshold) //(1,0,0)
        {
            DirecTxt.text = "RIGHT";
            Debug.Log("RIGHT " + Move.x);
        }

        /*
        if (MoveR.z >= Vector3.forward.z) //(0,0,1)
        {
            DirecTxt.text = "FORWARD";
        }
        if (MoveR.z <= Vector3.back.z) //(0,0,-1)
        {
            DirecTxt.text = "BACK";
        }
        */
    }

}
