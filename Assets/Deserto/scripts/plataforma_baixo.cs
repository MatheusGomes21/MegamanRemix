using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plataforma_baixo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float movement;
    float speed = -0.002f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0);
        movement += Mathf.Abs(speed);

        if(movement > 1.5f)
        {
            movement = 0;
            speed *= -1;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
    }
}
