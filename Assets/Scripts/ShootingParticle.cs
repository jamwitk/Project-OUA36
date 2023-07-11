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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            destination = hit.point;
            
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        InstantiateProjectile(firepoint);
    }
    void InstantiateProjectile(Transform firepointx)
    {
        var Obj = Instantiate(projectile, firepointx.position, Quaternion.identity) as GameObject;
        Obj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectilespeed;
    }
}
