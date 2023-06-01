using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 5f;
    public Collision collision = null;
    public static int score = 0;
    public static int lifes = 1;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lifes = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isOver && !GameManager.isPaused) { 
        float horizontalKeyboard = Input.GetAxis("Horizontal");
        float verticalKeyboard = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalKeyboard, 0f, verticalKeyboard) * speed * Time.deltaTime;
        transform.Translate(movement);


        float horizontalMouse = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, horizontalMouse * sensitivity);
        }
    }


}
