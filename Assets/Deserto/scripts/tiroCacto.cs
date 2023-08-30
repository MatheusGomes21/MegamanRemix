using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tiroCacto : MonoBehaviour
{
    //GameObjects
    GameObject player;

    //Stats
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < player.transform.position.x)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        else
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
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
