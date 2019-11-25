using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;
    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider= gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(value>5){
            Destroy(collider);
        }
        if(transform.position.y<-20){
            Destroy(gameObject);
        }
    }
}
