using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tiroCacto : MonoBehaviour
{
    //GameObjects
    GameObject player;

    //Stats
    float speed = 2.5f;
    float direction;
    bool directioned = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < player.transform.position.x && directioned == false)
        {
            direction = 1;
            directioned = true;
        }

        if (transform.position.x > player.transform.position.x && directioned == false)
        {
            direction = -1;
            directioned = true;
        }

        transform.position += new Vector3(speed * direction, 0, 0) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //Kill player
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //destroy bullet
        else
        {
            Destroy(gameObject);
        }
    }
}
