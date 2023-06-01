using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform igrac;
    public float sensitivity = 5f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //pauza
            float verticalInput = Input.GetAxis("Mouse Y");
            float rotationX = transform.localEulerAngles.x - verticalInput * sensitivity;
            //Debug.Log(newRotation);
            transform.position = igrac.position + new Vector3(0f, 0.5f, 0f);
            transform.rotation = igrac.rotation;
            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
        //krajpauze
    }
}
