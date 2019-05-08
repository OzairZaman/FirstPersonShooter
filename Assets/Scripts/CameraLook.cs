using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool isCursorHidden = true;
    public float minPitch = -80f, maxPitch = 80f;
    public Vector2 speed = new Vector2(100f, 120f); //speed in degrees (per second)

    private Vector2 euler; //current euler rotation (representation of how things are oriented in 3d space)
    
    // Start is called before the first frame update
    void Start()
    {
        //is the curson suppose to be hidden
        if (isCursorHidden)
        {
            //lock the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; //.......invisible!
        }
        //get current camera euler
        euler = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the camera with mouse movement
        euler.y += Input.GetAxis("Mouse X") * speed.x * Time.deltaTime; // time it take to go from one frame to antoher - normalises this (evens out)
        euler.x -= Input.GetAxis("Mouse Y") * speed.y * Time.deltaTime;
        //clamp the camera on pitch
        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);
        //apply the euler to the player and Camera seperately
        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0); //parent is the player as camera is in the player which the script is attached to
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);



    }
}
