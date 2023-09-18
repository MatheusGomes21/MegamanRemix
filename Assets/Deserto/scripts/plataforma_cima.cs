using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plataforma_cima : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float movement;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        movement += Mathf.Abs(speed);

        if(movement > 1.5f)
        {
            movement = 1;
            speed *= -1;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
    }
}
