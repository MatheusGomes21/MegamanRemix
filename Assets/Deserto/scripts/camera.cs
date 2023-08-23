using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(6.443217f, 1.305375f, -10);
    }
}
