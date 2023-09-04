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
    float speed = 3;
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
        float deltaY = mouseY - playerY;
        float deltaX = mouseX - playerX;
        float ratio = deltaX / deltaY;

        selfY = Mathf.Sqrt(Mathf.Pow(speed, 2) / (Mathf.Pow(ratio, 2) + 1));
        selfX = selfY * ratio;

        MonoBehaviour.print(a.ToString() + "/" + b.ToString());
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        camera = GameObject.Find("MainCamera");
        cam = camera.GetComponent<Camera>();
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
        transform.position += new Vector3(selfX, selfY, 0) * Time.deltaTime;

        //MonoBehaviour.print("AQUIIIII ---> " + a + "////" + newY);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //Kill player
        if (collider.gameObject.tag == "Cacto")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //destroy bullet
        else
        {
         
        }
    }
}
