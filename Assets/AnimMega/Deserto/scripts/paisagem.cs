using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paisagem : MonoBehaviour
{
    public float offset;
    public float speed;
    public float layer;
    public float selfY;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");  
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float selfX = (playerX * -speed) - 3 + offset;
        //float selfY = (playerY * speed * 5) + 1.3f;

        if ((selfX - playerX) < -11.525f)
        {
            offset += 36.2f;
        }

        if ((selfX - playerX) > 24.54f)
        {
            offset -= 36.2f;
        }

        gameObject.transform.position = new Vector3(selfX, selfY, layer);
    }
}
