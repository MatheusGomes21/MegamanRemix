using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urubu : MonoBehaviour
{
    GameObject player;

    public float range;
    public float speedX;
    public float speedY;

    void CheckY()
    {
        if (transform.position.y < player.transform.position.y)
        {
            transform.position += new Vector3(0, speedY, 0) * Time.deltaTime;
        }

        if (transform.position.y > player.transform.position.y)
        {
            transform.position -= new Vector3(0, speedY, 0) * Time.deltaTime;
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
        if (transform.position.x > player.transform.position.x && (transform.position.x - player.transform.position.x) < range)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position -= new Vector3(speedX, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x < player.transform.position.x && (player.transform.position.x - transform.position.x) < range)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += new Vector3(speedX, 0, 0) * Time.deltaTime;
        }

        CheckY();
    }
}
