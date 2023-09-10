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

        if ((selfX - playerX) < -11.525f)
        {
                offset += 36.2f;
        }

        if ((selfX - playerX) > 24.54f)
        {
                offset -= 36.2f;
        }

        gameObject.transform.position = new Vector3(selfX, selfY, layer);

        //parar de mover animacao
        if (gameObject.name == "DunaMovendoFront" | gameObject.name == "DunaMovendoBg")
        {
            if (SceneManager.GetActiveScene().name == "Level 2" && player.transform.position.x >= 245)
            {
                gameObject.GetComponent<Animator>().SetBool("Stop", true);
            }
        }
    }
}
