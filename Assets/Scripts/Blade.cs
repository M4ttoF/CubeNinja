using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Vector3 startPos, endPos, mousePos, diff;
    private RaycastHit hit, hit2;
    private AudioSource myAudio;
    public AudioClip cut;
    public int score;
    public GameObject cube,part,soundSystem;
    public Camera cam;
    public Rigidbody rb;
    public Material[] colours;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
        rb = GetComponent<Rigidbody>();
        score = 0;
        myAudio=soundSystem.GetComponent<AudioSource>();
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
            var ray=Physics.Linecast(startPos, endPos, out hit);
            var ray2=Physics.Linecast(endPos,startPos, out hit2);
            if(hit.rigidbody != null && hit2.rigidbody != null &&(hit.rigidbody.gameObject==hit2.rigidbody.gameObject)){
                var old = hit.rigidbody.gameObject;
                var c1 = Instantiate(cube, hit.rigidbody.position, hit.rigidbody.rotation);
                var c2 = Instantiate(cube, hit.rigidbody.position, hit.rigidbody.rotation);

                Instantiate(part, hit.rigidbody.position, hit.rigidbody.rotation);

                //keeping velocities
                c1.GetComponent<Rigidbody>().velocity =old.GetComponent<Rigidbody>().velocity;
                c1.GetComponent<Rigidbody>().velocity =old.GetComponent<Rigidbody>().velocity;

                //changing color
                c1.GetComponent<Renderer>().material = colours[old.GetComponent<Cube>().value];
                c2.GetComponent<Renderer>().material = colours[old.GetComponent<Cube>().value];

                c1.name="c1";
                c2.name="c2";

                //changing point value
                c1.GetComponent<Cube>().value=c2.GetComponent<Cube>().value=old.GetComponent<Cube>().value+1;
                if(hit.point.x-hit2.point.x > hit.point.y-hit2.point.y){
                    //Scaling partitions after slice
                    //Spawn in same location to mimic small exposion effect
                    c1.transform.localScale=new Vector3(1,Mathf.Abs((hit.point-hit2.point).y),1);
                    c2.transform.localScale=new Vector3(1,old.transform.localScale.y - Mathf.Abs((hit.point-hit2.point).y),1);
                    Debug.Log(c2.transform.localScale.y+", "+ Mathf.Abs((hit.point-hit2.point).y));
                }
                else{
                    c1.transform.localScale=new Vector3(Mathf.Abs((hit.point-hit2.point).x),1,1);
                    c2.transform.localScale=new Vector3(old.transform.localScale.x - Mathf.Abs((hit.point-hit2.point).x),1,1);
                }
                score+=old.GetComponent<Cube>().value;
                myAudio.PlayOneShot(cut, 0.7f);
                Destroy(old);
                //make vertical cut
                
                
                //c1.transform.localScale =new Vector3();
            }
        }
    }
}
