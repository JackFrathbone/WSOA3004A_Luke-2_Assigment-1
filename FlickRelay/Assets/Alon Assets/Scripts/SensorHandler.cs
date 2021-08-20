using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SensorHandler : MonoBehaviour
{
    public string Orientation;
    public Text DirecTxt;
    public Text Calibratetxt;
    public Text AccelText;
    
    public Text MaxAccelX;
    float MaxAccX = 0;

    public Text MaxAccelY;
    float MaxAccY = 0;
    bool calibrated = false;

    string PreviousDirec = "";
    string PlayerDirec = "";

    bool isWaiting = true;
    public float Threshold = 1;
    public float ScaleVal =1;
    //phone co ords dont match with unit co ords if phone rotated

    private void Start()
    {
        //InvokeRepeating("MovementHandler", 0f, 0.2f);
        StartCoroutine("MovementHandler");
    }

    private void Update()
    {
        //CheckOrientation();
        //if (calibrated == true)
        // {
        //MovementHandler();
       // if (isWaiting == true) { StartCoroutine("MovementHandler");}

        // }


        if (Input.GetMouseButtonDown(0) == true)
        {
            MaxAccX = 0;
            MaxAccelX.text = "Max X: " + MaxAccX;
            MaxAccY = 0;
            MaxAccelY.text = "Max Y: " + MaxAccY;
            
        }

    }

    private void CheckOrientation()
    {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Time.timeScale = 1f;

        }
    }

    //IEnumerator
    private IEnumerator MovementHandler()
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


        AccelText.text = "" + Move; //show acceleration real time

        //show positive max acceleration X and Y axis
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





        if (Move.y > Threshold) //(0,1,0)
        {
            DirecTxt.text = "up";
            PlayerDirec = "up";
            //yield return new WaitForSeconds(5);
            Debug.Log("UP " + Move.y);
            isWaiting = false;

        }
        else if (Move.y < -Threshold) //(0,-1,0)
        {
            DirecTxt.text = "down";
            PlayerDirec = "down";
            Debug.Log("DOWN " + Move.y);
            isWaiting = false;
            //yield return new WaitForSeconds(1);
        }
        else if (Move.x < -Threshold) //(-1,0,0)
        {
            DirecTxt.text = "left";
            PlayerDirec = "left";
            Debug.Log("LEFT " + Move.x);
            isWaiting = false;
        }
        else if (Move.x > Threshold) //(1,0,0)
        {
            DirecTxt.text = "right";
            PlayerDirec = "right";
            Debug.Log("RIGHT " + Move.x);
            isWaiting = false;
        }
        else if(Move.x > Threshold && Move.x < -Threshold && Move.y < -Threshold && Move.y > Threshold) { DirecTxt.text = "Waiting"; }


        yield return new WaitForSeconds(1f);
        isWaiting = true;
        //if (PlayerDirec != PreviousDirec)
        // {
        //     yield return new WaitForSeconds(1);
        //      Debug.Log("Waiting");
        //  }
        //  else
        //  {
        //    PreviousDirec = PlayerDirec;
        //  }

        StartCoroutine("MovementHandler");
    }

}
