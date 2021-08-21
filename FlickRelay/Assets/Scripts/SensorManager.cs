using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorManager : MonoBehaviour
{
    private float _moveX = 0f;
    private float _moveY = 0f;
    private Vector3 _accelVect;

    private bool _moved = false;

    public float threshold = 1.5f;
    public float detectionDelay = 1f;

    //public GameObject orientationAlert;

    //public float _OrinetationDelay = 1.0f;
    //bool InitialRotate = false;
    //bool ResolveOrient = false;

    //threshold timer
    //float tempTime1 = 0f;
    //float tempTime2 = 0f;
    //float tempTime3 = 0f;
    //float tempTime4 = 0f;

    public float thresholdTimer = 0.3f; //time needed for acceleration over time.
    bool _isMoving = false;
    //bool one = false;
    //bool two = false;
    //bool three = false;
    //bool four = false;

    //detection of movement
    //if made a move should stop detecting for +-1f seconds

    //Used to connect to the interface
    private MovesetManager _movesetManager;

    private void Start()
    {
        _movesetManager = GetComponent<MovesetManager>();
    }

    private void Update()
    {
        AcceleHandler();
    }

    void AcceleHandler()
    {
        _accelVect = Input.acceleration;
        _moveX = _accelVect.x;//left right
        _moveY = _accelVect.y;//up down

        OrientHandler();
        //Debug.Log(Input.deviceOrientation +" | X: "+_moveX+" | Y: "+_moveY );

        //if (Time.time - tempTime1 >= thresholdTimer)
        //{
        //    tempTime1 = Time.time;
        //    Debug.Log("IFUCKEDIT");
        //}

        //while doing a move makes sure other timers are same as current time 

        /*
        if (one == false)
        {
            tempTime2 = Time.time;
            tempTime3 = Time.time;
            tempTime4 = Time.time;
        }

        if (two == false)
        {
            tempTime1 = Time.time;
            tempTime3 = Time.time;
            tempTime4 = Time.time;
        }

        //if (three == false)
        {
            tempTime1 = Time.time;
            tempTime2 = Time.time;
            tempTime4 = Time.time;
        }

        //if (four == false)
        {
            tempTime1 = Time.time;
            tempTime2 = Time.time;
            tempTime3 = Time.time;
        }
        */


        if (_moveX > threshold && _moved == false)//left
        {
            //if (_isMoving == false)
            //{
                //two = true;
                //three = true;
                //four = true;

                //tempTime1 = Time.time;
                //_isMoving = true;
            //}

            //if (Time.time - tempTime1 >= thresholdTimer)
            //{
                //tempTime1 = Time.time;
                _movesetManager.LookLeft();
                _moved = true;
                //_isMoving = false;
                StartCoroutine("PauseHandler");
            //}
        }

        if (_moveX < -threshold && _moved == false)//right
        {
                _movesetManager.LookRight();
                _moved = true;
                StartCoroutine("PauseHandler");
        }

        if (_moveY > threshold && _moved == false)//down
        {
                _movesetManager.LookDown();
                _moved = true;
                StartCoroutine("PauseHandler");
        }

        if (_moveY < -threshold && _moved == false)//up
        {
                _movesetManager.LookUp();
                _moved = true;
                StartCoroutine("PauseHandler");
        }

    }

    IEnumerator PauseHandler()
    {
        //tempTime1 = Time.time;
        //tempTime2 = Time.time;
        //tempTime3 = Time.time;
        //tempTime4 = Time.time;

        //one = false;
        //two = false;
        //three = false;
        //four = false;


        Debug.Log("MOVED");
        yield return new WaitForSeconds(detectionDelay);
        _moved = false;
    }

    void OrientHandler()
    {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
                _moveY += 1;
        }
        else if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            _moveX -= 1;
        }
        /*
        else
        {
            //Orientation is not landscape
            InitialRotate = true;

            //anouther bool

            //Debug.Log("Rotated");
            //Debug.Log("Initial rotate: "+ InitialRotate);

            if (InitialRotate == true && ResolveOrient == false)
            {
                //Debug.Log("Got in 1");
                tempTime = Time.time;
                InitialRotate = false;
                ResolveOrient = true;
            }
            
            if (Time.time - tempTime >= _OrinetationDelay)
            {
                //Debug.Log("Got in 2");
                //orientationAlert.SetActive(true);
                //Time.timeScale = 0f;
            }

        
            
        }
        */
    }
}
