using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cobra : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float movement;
    float speed = 0.006f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
        movement += Mathf.Abs(speed);

        if(movement > 3)
        {
            movement = 0;
            speed *= -1;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
