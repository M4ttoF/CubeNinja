using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Vector3 startPos, endPos, mousePos, diff;
    private RaycastHit hit;
    public LayerMask layermask;
    public Camera cam;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {   
        mousePos = Input.mousePosition;
        mousePos.z=10;
        rb.position=cam.ScreenToWorldPoint(mousePos);
        if(Input.GetMouseButtonDown(0)){
            startPos = rb.position;
        }
        else if(Input.GetMouseButtonUp(0)){
            endPos = transform.position;
            diff=endPos-startPos;
            var ray=Physics.Linecast(startPos, endPos, out hit);
            Debug.Log(hit.point);
            Debug.DrawRay(startPos, diff * Vector3.Distance(startPos, endPos), Color.green, 20.0f);
        }
    }
}
