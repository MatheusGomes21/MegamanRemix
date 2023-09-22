using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paisagem : MonoBehaviour
{
    public float offset;
    public float speed;
    public float layer;
    public float selfY;
    float selfX;
    float playerX;
    float playerY;
    
    GameObject player;

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

        selfX = (playerX * -speed) - 3 + offset;

        if (gameObject.name != "DunaMovendoFront" && gameObject.name != "DunaMovendoBg")
        {
            if ((selfX - playerX) < -11.525f)
            {
                offset += 36.2f;
            }

            if ((selfX - playerX) > 24.54f)
            {
                offset -= 36.2f;
            }
        }

        if (gameObject.name == "DunaMovendoFront" | gameObject.name == "DunaMovendoBg")
        {
            if ((selfX - playerX) < -16.375f)
            {
                offset += 45.9f;
            }

            if ((selfX - playerX) > 29.39f)
            {
                offset -= 45.9f;
            }
        }

        gameObject.transform.position = new Vector3(selfX, selfY, layer);

        //parar de mover animacao
        if (gameObject.name == "DunaMovendoFront" | gameObject.name == "DunaMovendoBg")
        {
            if (SceneManager.GetActiveScene().name == "Level 2" && playerX >= 245)
            {
                gameObject.GetComponent<Animator>().SetBool("Stop", true);
            }
        }

        //tirar dunas lv2 no penhasco
        if (SceneManager.GetActiveScene().name == "Level 2" && gameObject.name != "DunaMovendoBg" && gameObject.name != "DunaMovendoFront")
        {
            if (player.transform.position.x >= 170)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }

            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
