using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    //public static GameObject target;
    public GameObject mainTarget;
    public float Health { get; set; }
    int side = 1;
    public float speed = 5f;
    public static bool startCalled = false;
    float repeatLimit = 0.5f; // Initial delay between invocations
    float repeatRate = 2.5f; // Initial repeat rate
    float decreaseRate = 0.05f; // Rate at which the repeat rate decreases
    // Start is called before the first frame update
    void Start()
    {
        Health = 100f;
        side = UnityEngine.Random.Range(1, 5);
        if (!startCalled)
        {
            side = 0;
            //InvokeRepeating("NewTarget", 2.0f, 2.0f);
            StartCoroutine(RepeatedFunctionCoroutine());
            startCalled = true;
        }
        else
        {
            float ranvalue = UnityEngine.Random.Range(-3.5f, 3.5f);
            switch (side)
            {
                case 1:
                    mainTarget.transform.position = new Vector3(ranvalue, 0.45f, -25f);
                    break;
                case 2:
                    mainTarget.transform.position = new Vector3(-25f, 0.45f, ranvalue);
                    mainTarget.transform.localEulerAngles =
                        new Vector3(0f, 90f, 0f);
                    break;
                case 3:
                    mainTarget.transform.position = new Vector3(ranvalue, 0.45f, 25f);
                    break;
                case 4:
                    mainTarget.transform.position = new Vector3(25f, 0.45f, ranvalue);
                    mainTarget.transform.localEulerAngles =
                        new Vector3(0f, 90f, 0f);
                    break;
                default:
                    break;
            }
        }
        //Targets.Add(currentTarget);
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isOver && !GameManager.isPaused)
        {

            if (Health <= 0f)
            {
                Destroy(mainTarget);
                IgracMovement.score++;
                speed = speed + 0.1f;
            }
            else
            {
                switch (side)
                {
                    case 1:
                        if (mainTarget.transform.position.z < -5)
                            mainTarget.transform.position =
                                mainTarget.transform.position + new Vector3(0f, 0f, 1f) * speed * Time.deltaTime;
                        else
                        {
                            Destroy(mainTarget);
                            Debug.Log("Ode" + side);
                            IgracMovement.lifes--;
                        }
                        break;
                    case 2:
                        if (mainTarget.transform.position.x < -5)
                            mainTarget.transform.position =
                                mainTarget.transform.position + new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
                        else
                        {
                            Destroy(mainTarget);
                            Debug.Log("Ode" + side);
                            IgracMovement.lifes--;
                        }
                        break;
                    case 3:
                        if (mainTarget.transform.position.z > 5)
                            mainTarget.transform.position =
                                mainTarget.transform.position + new Vector3(0f, 0f, -1f) * speed * Time.deltaTime;
                        else
                        {
                            Destroy(mainTarget);
                            Debug.Log("Ode" + side);
                            IgracMovement.lifes--;
                        }
                        break;
                    case 4:
                        if (mainTarget.transform.position.x > 5)
                            mainTarget.transform.position =
                                mainTarget.transform.position + new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
                        else
                        {
                            Destroy(mainTarget);
                            Debug.Log("Ode" + side);
                            IgracMovement.lifes--;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
    IEnumerator RepeatedFunctionCoroutine()
    {
        while (true)
        {
            if (!GameManager.isOver && !GameManager.isPaused)
            {
                repeatRate -= decreaseRate;
                Instantiate(mainTarget);
                if (repeatRate <= repeatLimit)
                {
                    repeatRate = repeatLimit;
                }

                yield return new WaitForSeconds(repeatRate);
            }
            
        }
    }



    

}
