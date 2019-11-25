using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject blade;
    private int score;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = blade.GetComponent<Blade>().score;
        text.text="Score: "+score;
    }
}
