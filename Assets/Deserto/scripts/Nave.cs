using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    bool right = true;
    public float limiteEsq, limiteDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.position += new Vector3(0.005f, 0, 0);
            if (transform.position.x > limiteDir)
            {
                right = false;
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        else
        {
            transform.position -= new Vector3(0.005f,0, 0);
            if(transform.position.x < limiteEsq)
            {
                right = true;
                transform.rotation = Quaternion.Euler (0,180,0);
            }
        }
    }
}
