using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elVince : MonoBehaviour
{
    GameObject player;

    //stats
    public float life;
    public float range;
    public string modo;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
