using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cobra : MonoBehaviour
{

    // Start is called before the first frame update

    float movement;
    public float speed;
    public float patrolSize;
    public float range;
    public float speedBoost;
    int chasing = 0;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        //patrolling
        if (transform.position.x - player.transform.position.x < range)
        {
            if (chasing == 0)
            {
                chasing = 1;
            }
        }

        if (chasing == 0)
        {
            movement += Mathf.Abs(speed / 250);

            if (movement > patrolSize)
            {
                movement = 0;
                speed *= -1;
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            }
        }

        //chasing
        if (chasing == 1 | chasing == 2)
        {
            if (chasing == 1)
            {
                speed *= speedBoost;
                chasing = 2;
                gameObject.GetComponent<Animator>().speed = speedBoost;
            }

            if (transform.position.x > player.transform.position.x)
            {
                if (speed > 0)
                {
                    speed *= -1;
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
                }
            }

            if (transform.position.x < player.transform.position.x)
            {
                if (speed < 0)
                {
                    speed *= -1;
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
                }
            }
        }

        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;


        if (gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collider.gameObject.name == "AreiaMovedica")
        {
            Destroy(gameObject);
        }
    }
}
