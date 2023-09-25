using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    bool changed = false;
    bool changing = false;
    public float speed;
    float xPosit = 6.443217f;
    public bool self = true;

    GameObject player;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        cam = gameObject.GetComponent<Camera>();

        if (self == false)
        {
            self = true;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (self)
        {
            if (SceneManager.GetActiveScene().name == "Level 3")
            {
                if (player.transform.position.y >= 12.15)
                {
                    changing = true;
                }

                if (changing)
                {
                    if (transform.position.x > player.transform.position.x - 6.443217f && changed == false)
                    {
                        xPosit -= speed;
                    }

                    if (cam.orthographicSize < 8)
                    {
                        cam.orthographicSize += 0.2f;
                    }

                    if (transform.position.x <= player.transform.position.x && gameObject && cam.orthographicSize >= 8)
                    {
                        changed = true;
                    }
                }
            }

            transform.position = player.transform.position + new Vector3(xPosit, 1.305375f, -10);
        }
    }
}
