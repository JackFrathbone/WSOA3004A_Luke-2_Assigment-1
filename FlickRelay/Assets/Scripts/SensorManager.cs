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

    public GameObject orientationAlert;

    public float _OrinetationDelay = 1.0f;
    float tempTime;
    //bool InitialRotate = false;
    //bool ResolveOrient = false;

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
        //OrientHandler();
    }

    void AcceleHandler()
    {
        _accelVect = Input.acceleration;
        _moveX = _accelVect.x;//left right
        _moveY = _accelVect.y;//up down

        OrientHandler();

        if (_moveX > threshold && _moved == false)//left
        {
            _movesetManager.LookLeft();
            _moved = true;
            StartCoroutine("PauseHandler");
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
        Debug.Log("MOVED");
        yield return new WaitForSeconds(detectionDelay);
        _moved = false;
    }

    void OrientHandler()
    {
        //device is landscape
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            orientationAlert.SetActive(false);
            Time.timeScale = 1f;

            //InitialRotate = false;
            //ResolveOrient = false;

            if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            {
                _moveY += 1;
            }
            else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            {

                _moveX += -1;
            }

            //Debug.Log(Input.deviceOrientation);
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
