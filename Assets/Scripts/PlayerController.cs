using System;
using System.Collections;
using System.Collections.Generic;
using Bitgem.VFX.StylisedWater;
using UnityEngine;
using UnityEngine.Serialization;

public enum CurrentState
{
    Normal,
    Aiming
}
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Transform _defaultAsa;
    public LineRenderer lineRenderer;
    public Health playerHealth;
    private void Start()
    {
        playerHealth = GetComponent<Health>();
        _camera = Camera.main;
        _defaultAsa = asa.transform;
    }

    private void Awake()
    {
        Instance = this;
    }

    private CurrentState _currentState;
    public GameObject asa;
    public GameObject asaUcu;
    private Camera _camera;
    private Transform _nonEmptyDraggedObject;
    private float draggedDistance = 12f;
    private Rigidbody _draggedRb;
    private void Update()
    {
        //hit.collider.transform.position = Vector3.Lerp(hit.collider.transform.position, ray.GetPoint(10f), Time.deltaTime * 10f);

        if (_currentState == CurrentState.Aiming)
        {
            //shoot drag and drop

            var ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            if (Physics.Raycast(ray, out var hit, 1000f))
            {

                if (hit.collider.CompareTag("Dragable"))
                {
                    //drag the object but make the ray.GetPoint() dynamic that it will be change with mousewheel scroll
                    if (Input.GetMouseButton(0))
                    {
                        //draw a line to the object
                        lineRenderer.SetPosition(0, asaUcu.transform.position);
                        lineRenderer.SetPosition(1, hit.point);
                        _nonEmptyDraggedObject = hit.collider.transform;
                        if (hit.collider.TryGetComponent(out Rigidbody rb))
                        {
                            _draggedRb = rb;
                            rb.isKinematic = true;
                        }
                        if(hit.collider.TryGetComponent(out WateverVolumeFloater wateverVolumeFloater))
                        {
                            wateverVolumeFloater.enabled = false;
                        }
                        
                        if(hit.collider.name.Contains("rock"))
                            hit.collider.transform.position = Vector3.Lerp(_nonEmptyDraggedObject.position, ray.GetPoint(draggedDistance) - Vector3.up, Time.deltaTime * 10f);
                        else if(hit.collider.name.Contains("kutuk"))                            
                            hit.collider.transform.position = Vector3.Lerp(_nonEmptyDraggedObject.position, ray.GetPoint(draggedDistance), Time.deltaTime * 10f);
                        hit.collider.transform.rotation = Quaternion.Lerp(_nonEmptyDraggedObject.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * 10f);
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        if (_draggedRb != null)
                        {
                            _draggedRb.isKinematic = false;
                            _draggedRb = null;
                        }
                        lineRenderer.SetPosition(0, Vector3.zero);
                        lineRenderer.SetPosition(1, Vector3.zero);
                        _nonEmptyDraggedObject = null;
                        hit.collider.GetComponent<WateverVolumeFloater>().enabled = true;
                    }
                    else
                    {
                        //drop the object
                        if (_draggedRb != null)
                        {
                            _draggedRb.isKinematic = false;
                            _draggedRb = null;
                        }
                        lineRenderer.SetPosition(0, Vector3.zero);
                        lineRenderer.SetPosition(1, Vector3.zero);
                        _nonEmptyDraggedObject = null;
                    }
                }
                else
                {
                    if (_draggedRb != null)
                    {
                        _draggedRb.isKinematic = false;
                        _draggedRb = null;
                    }
                    lineRenderer.SetPosition(0, Vector3.zero);
                    lineRenderer.SetPosition(1, Vector3.zero);
                    _nonEmptyDraggedObject = null;
                }
            }
            else
            {
                if (_draggedRb != null)
                {
                    _draggedRb.isKinematic = false;
                    _draggedRb = null;
                }
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
                _nonEmptyDraggedObject = null;

            }
            
        }
        else
        {
            _nonEmptyDraggedObject = null;
            /*asa.transform.position = _defaultAsa.position;
            asa.transform.localRotation = Quaternion.Euler(146.4f,0,27);
        */
        }
    }
    public void SetState(CurrentState state)
    {
        _currentState = state;
    }
    public CurrentState GetState()
    {
        return _currentState;
    }
}
