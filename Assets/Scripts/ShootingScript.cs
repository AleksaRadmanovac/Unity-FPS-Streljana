using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    Animator animator;
    public Transform mainCam;
    public Transform igrac;
    public float gunRange = 10000f;
    private bool isFiring = false;
    private bool isReloading = false;
    private float fireTimer = 0f;
    private float fireRate = 10f;
    private float flashTimer = -100f;
    private float reloadTimer = 0f;
    public static int ammo = 30;
    public GameObject bulletHole;
    //public int gunDamage = 10;


    public void Fire()
    {
        RaycastHit hit;
        ammo = ammo - 1; 
        animator.SetTrigger("Pucaj");
        GameObject.Find("AK-47").transform.GetChild(2).gameObject.SetActive(true);
        if (Physics.Raycast(mainCam.position, mainCam.forward, out hit, gunRange))
        {
            Debug.Log("Gun hit " + hit.collider.gameObject.name);
            /*GameObject bulletH = Instantiate(bulletHole);
            bulletH.transform.position = hit.collider.transform.position;
            bulletH.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);*/
            if (hit.collider.gameObject.name == "Glava") 
            {
                TargetScript t = hit.collider.gameObject.transform.parent.gameObject.GetComponent<TargetScript>();
                t.Health = t.Health - 100f;
            }
            if (hit.collider.gameObject.name == "Telo")
            {
                TargetScript t = hit.collider.gameObject.transform.parent.gameObject.GetComponent<TargetScript>();
                t.Health = t.Health - 50f;
            }
            if (hit.collider.gameObject.name == "Ruke")
            {
                TargetScript t = hit.collider.gameObject.transform.parent.gameObject.GetComponent<TargetScript>();
                t.Health = t.Health - 34f;
            }

        }
        Recoil();
    }
    // Start is called before the first frame update
    void Start()
    {
        ammo = 30;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //pauza
            if (Input.GetKeyDown(KeyCode.R))
            {
                startReloading();
            }
            if (Input.GetMouseButtonDown(0))
            {
                StartFiring();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopFiring();
            }

            if (ammo > 0 && !isReloading)
            {
                if (isFiring)
                {

                    fireTimer += Time.deltaTime;
                    flashTimer += Time.deltaTime;

                    // Check if enough time has passed to fire another bullet based on the fire rate
                    if (fireTimer >= 1f / fireRate)
                    {
                        Fire();
                        fireTimer = fireTimer - 1f / fireRate;
                        flashTimer = 0;
                    }

                    if (flashTimer > 0.05f)
                    {
                        GameObject.Find("AK-47").transform.GetChild(2).gameObject.SetActive(false);
                        flashTimer = -100f;
                    }
                }
                
            }
            else 
            {
                StopFiring();
                startReloading();
            }
            if (isReloading)
            {
                reloadTimer += Time.deltaTime;
                if (reloadTimer >= 2)
                {
                    Reload();
                }
            }
        //krajpauze

        void startReloading()
        {
            animator.SetBool("Reloading", true);
            Debug.Log("pocReload");
            isReloading = true;
        }

        void Reload()
        {
            ammo = 30;
            reloadTimer = 0f;
            isReloading = false;
            animator.SetBool("Reloading", false);

        }


        void StartFiring()
        {
            Debug.Log("Poc");
            Debug.Log(GameObject.Find("AK-47").name);
            Debug.Log(GameObject.Find("AK-47").transform.GetChild(2).name);
            Debug.Log(GameObject.Find("AK-47").transform.GetChild(2).gameObject.name);

            isFiring = true;
            //fireTimer = 0f;
        }

        void StopFiring()
        {
            isFiring = false;
            GameObject.Find("AK-47").transform.GetChild(2).gameObject.SetActive(false);

            //fireTimer = 0f;
        }

    }

    void Recoil()
    {
        mainCam.localRotation =
            Quaternion.Euler(mainCam.localEulerAngles.x - 1f, mainCam.localEulerAngles.y, mainCam.localEulerAngles.z);
        igrac.localRotation =
            Quaternion.Euler(igrac.localEulerAngles.x, igrac.localEulerAngles.y + Random.Range(-0.5f,0.5f), igrac.localEulerAngles.z);
    }
}
