using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingParticle : MonoBehaviour
{
    public Camera cam;
    private Vector3 destination;

    public GameObject projectile;
    public Transform firepoint;
    public float projectilespeed;

    private bool isActionActive = false;

    private float Attacktime;
    public float FireRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            StartAction();
        }

        if (Input.GetMouseButtonUp(1))
        {

            StopAction();
        }
        if (isActionActive==true)
        {
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(Time.time>=Attacktime)
                {
                    Attacktime = Time.time + 1 / FireRate;
                    Shooting();

                }

            }
        }
    }

    void Shooting()
    {
        var ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f,0) );
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            destination = hit.point;
            
        }
        else
        {
            destination = ray.GetPoint(50);
        }
        InstantiateProjectile(firepoint);
    }
    void InstantiateProjectile(Transform firepointx)
    {
        var Obj = Instantiate(projectile, firepointx.position, Quaternion.identity) as GameObject;
        Obj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectilespeed;
    }

    void StartAction()
    {
        isActionActive = true;
    }

    void StopAction()
    {
        isActionActive = false;
    }
}
