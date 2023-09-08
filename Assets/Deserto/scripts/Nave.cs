using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    GameObject player;

    //stats
    public float aimSpeedX;
    public float aimSpeedY;
    public float cooldown;
    string stage = "waiting";

    float playerX;
    float playerY;

    //functions
    IEnumerator Wait()
    {
        transform.position = new Vector3(playerX - 1, playerY + 4.7f, 0);
        yield return new WaitForSeconds(cooldown);
        stage = "aiming";
    }

    void Travel(Vector3 position, Vector3 scale)
    {
        //position

        if (transform.position.x < position.x)
        {
            transform.position += new Vector3(aimSpeedX, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x > position.x)
        {
            transform.position -= new Vector3(aimSpeedX, 0, 0) * Time.deltaTime;
        }

        if (transform.position.y < position.y)
        {
            transform.position += new Vector3(0, aimSpeedY, 0) * Time.deltaTime;
        }

        if (transform.position.y > position.y)
        {
            transform.position -= new Vector3(0, aimSpeedY, 0) * Time.deltaTime;
        }

        //scale
        if (transform.localScale.x < scale.x)
        {
            transform.localScale += new Vector3(aimSpeedX, 0, 0) * Time.deltaTime;
        }

        if (transform.localScale.x > scale.x)
        {
            transform.localScale -= new Vector3(aimSpeedX, 0, 0) * Time.deltaTime;
        }

        if (transform.localScale.y < scale.y)
        {
            transform.localScale += new Vector3(0, aimSpeedY, 0) * Time.deltaTime;
        }

        if (transform.localScale.y > scale.y)
        {
            transform.localScale -= new Vector3(0, aimSpeedY, 0) * Time.deltaTime;
        }

        if (transform.position == position && transform.localScale == scale)
        {
            if (stage == "aiming")
            {
                stage = "charging";
            }

            else
            {
                stage = "waiting";
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        
        if (stage == "waiting")
        {
            StartCoroutine(Wait());
        }

        if (stage == "aiming")
        {
            Travel(new Vector3(playerX, playerY + 3, 0), new Vector3(5, 5, 0));
        }
    }
}
