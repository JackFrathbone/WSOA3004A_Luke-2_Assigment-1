using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        text.text = "" + num;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            num++;
            text.text = "" + num;
        }
    }
}
