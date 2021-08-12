using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorHandler : MonoBehaviour
{
    public string Orientation;
    public Text DirecTxt;

    public float ScaleVal;
    //phone co ords dont match with unit co ords if phone rotated



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckOrientation();
    }


    void CheckOrientation()
    {
        //if (Input.acceleration.x < 1 && Input.acceleration.y < 1 && Input.acceleration.z < 1 && Input.acceleration.x > -1 && Input.acceleration.y > -1 && Input.acceleration.z > -1)
        //{
         //   DirecTxt.text = "Zero";
        // }

        //LandscapeLeft - The device is in landscape mode, with the device held upright and the home button on the right side.
        //LandscapeRight - The device is in landscape mode, with the device held upright and the home button on the left side.

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Orientation = "LandscapeLeft";
            //MovementHandlerL();
        }
        if (Input.deviceOrientation == DeviceOrientation.LandscapeRight || Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Orientation = "LandscapeRight";
            MovementHandlerR();
        }
    }


    void MovementHandlerR()
    {
        Vector3 MoveR = Input.acceleration*ScaleVal; //with some scale
        //MoveR = Quaternion.Euler(90, 90, 90) * MoveR;//how does direction change?
        //Debug.Log(MoveR);
        if (MoveR.y >= Vector3.up.y) //(0,1,0)
        {
            DirecTxt.text = "UP";
            Debug.Log("UP "+MoveR.y);
        }
        if (MoveR.y <= Vector3.down.y) //(0,-1,0)
        {
            DirecTxt.text = "DOWN";
            Debug.Log("DOWN " + MoveR.y);
        }
        if (MoveR.x <= Vector3.left.x) //(-1,0,0)
        {
            DirecTxt.text = "LEFT";
            Debug.Log("LEFT " + MoveR.x);
        }
        if (MoveR.x >= Vector3.right.x) //(1,0,0)
        {
            DirecTxt.text = "RIGHT";
            Debug.Log("RIGHT " + MoveR.x);
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

    void MovementHandlerL()
    {
        Debug.Log(Input.acceleration.normalized);
        //Debug.DrawRay(Vector3.zero, Input.acceleration, Color.green);

        //how does direction change?
        Vector3 MoveL = Input.acceleration * ScaleVal; //with some rotation and scale
        //MoveL = Quaternion.Euler(90, 90, 90) * MoveL;
        //how does direction change?
        if (MoveL.y >= Vector3.up.y) //(0,1,0)
        {
            DirecTxt.text = "UP";
        }
        if (MoveL.y <= Vector3.down.y) //(0,-1,0)
        {
            DirecTxt.text = "DOWN";
        }
        if (MoveL.x <= Vector3.left.x) //(-1,0,0)
        {
            DirecTxt.text = "LEFT";
        }
        if (MoveL.x >= Vector3.right.x) //(1,0,0)
        {
            DirecTxt.text = "RIGHT";
        }
        if (MoveL.z >= Vector3.forward.z) //(0,0,1)
        {
            DirecTxt.text = "FORWARD";
        }
        if (MoveL.z <= Vector3.back.z) //(0,0,-1)
        {
            DirecTxt.text = "BACK";
        }
    }
}
