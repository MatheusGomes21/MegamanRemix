using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    GameObject player;

    //stats
    public float speed = 2;
    public float movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-1, 4, 0);

        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        movement += Mathf.Abs(speed / 250);

        if (movement > 3)
        {
            movement = 0;
            speed *= -1;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

        //if (right)
        //{
        //    transform.position += new Vector3(0.005f, 0, 0);
        //    if (transform.position.x > limiteDir)
        //    {
        //        right = false;
        //        transform.rotation = Quaternion.Euler(0,0,0);
        //    }
        //}
        //else
        //{
        //    transform.position -= new Vector3(0.005f,0, 0);
        //    if(transform.position.x < limiteEsq)
        //    {
        //        right = true;
        //        transform.rotation = Quaternion.Euler (0,180,0);
        //    }
        //}
    }
}
