using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cacto : MonoBehaviour
{
    //stats
    float range = 10;
    int waitTime = 500;
    int wait = 500;
    

    //game Objects
    GameObject player;
    GameObject bullet;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        bullet = GameObject.Find("TiroCacto");
    }

    float movement;
    float speed = 0.6f;

    // Update is called once per frame
    void Update()
    {
        //patrol
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        movement += Mathf.Abs(speed/250);

        if (movement > 3)
        {
            movement = 0;
            speed *= -1;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

        //shoot
        if(transform.position.x - player.transform.position.x < range && wait >= waitTime)
        {
            float spawnpointX = 1;
            spawnpointX = transform.position.x - spawnpointX;

            Instantiate(bullet, new Vector3(spawnpointX, transform.position.y, 0), transform.rotation);

            wait = 0;
        }

        if(wait < waitTime)
        {
            wait += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //Kill player
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
