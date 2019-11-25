using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float xMax, xMin;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x<0){
            xMin=0;
            xMax=300;
        }
        else if(transform.position.x>0){
            xMin=-300;
            xMax=0;
        } else{
            xMin=-300;
            xMax=300;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
