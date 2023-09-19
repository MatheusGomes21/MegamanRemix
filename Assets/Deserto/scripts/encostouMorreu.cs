using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//SO FUNCIONA COM TRIGGER

public class encostouMorreu : MonoBehaviour
{

    GameObject player;
    Vector3 spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");

        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            spawnpoint = new Vector3(-2.92f, -1.255f, -1);
        }

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            spawnpoint = new Vector3(-7.18f, -1.251658f, -1);
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            spawnpoint = new Vector3(-7.49f, -1.255f, -1);
        }

        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (player.transform.position.x > 114 | player.transform.position.y > 15)
            {
                spawnpoint = new Vector3(112, 31.8f, -1);
            }

            else
            {
                spawnpoint = new Vector3(-2.59f, -3.22f, -1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (player.transform.position.x > 114)
            {
                spawnpoint = new Vector3(112, 31.8f, -1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cowboy")
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.name == "TiroCacto(Clone)")
                {
                    Destroy(enemy);
                }

                enemy.SetActive(true);
            }

            player.transform.position = spawnpoint;
        }
    }
}
