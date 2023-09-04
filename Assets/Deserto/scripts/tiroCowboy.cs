using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tiroCowboy : MonoBehaviour
{
    //GameObjects
    GameObject player;
    GameObject camera;
    Camera cam;

    //Stats
    float speed = 2;
    float direction;
    float selfX = 0;
    float selfY = 0;

    float a;
    float b;

    void TrackPath()
    {
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

        float mouseX = mouseWorldPosition.x;
        float mouseY = mouseWorldPosition.y;
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float ratio = (playerX / mouseX);
        float systemMouseY = mouseY * ratio;

        b = (playerY - systemMouseY) / (-ratio + 1);
        a = (playerY - b) / playerX;

        MonoBehaviour.print(playerY-b);
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        camera = GameObject.Find("MainCamera");
        cam = camera.GetComponent<Camera>();
        selfY = transform.position.y;
        TrackPath();

        if (transform.position.x < player.transform.position.x)
        {
            direction = -1;
        }

        if (transform.position.x > player.transform.position.x)
        {
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newY = (transform.position.x * a + b) * 1000;
        selfX = speed * direction;
        selfY = newY - selfY;

        transform.position += new Vector3(selfX, selfY, 0) * Time.deltaTime;

        selfY = newY;
        //MonoBehaviour.print("AQUIIIII ---> " + a + "////" + newY);
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
