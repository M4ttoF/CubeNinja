using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[]spawnPoints;
    private float oldTime,delay, timer;
    private int n;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        oldTime=0;
        delay=Random.Range(0.5f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer-oldTime>delay){
            //resetting oldTime and delay
            oldTime=timer;
            delay=Random.Range(0.5f,2f);
            
            //picking random spawn
            n = Random.Range(0,spawnPoints.Length);
            var pick=spawnPoints[n];
            var script = pick.GetComponent<SpawnPoint>();
            Quaternion myQ = new Quaternion();
            myQ.Set(Random.Range(-60f,60f),Random.Range(-60f,60f),Random.Range(-60f,60f), 1);
            var c = Instantiate(cube, pick.transform.position, myQ);
            c.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(script.xMin,script.xMax), 700, 0));
        }
        Debug.Log(oldTime +", "+delay);
    }
}
