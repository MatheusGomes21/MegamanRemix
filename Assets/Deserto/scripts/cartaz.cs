using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaz : MonoBehaviour
{
    public float growthX;
    public float growthY;
    public float speedX;
    public float speedY;

    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        MonoBehaviour.print(camera.transform.position.x + 86.7f);
        MonoBehaviour.print(camera.transform.position.y - 22.63f);
        if (transform.position.x < camera.transform.position.x + 86.7f)
        {
            transform.position += new Vector3(speedX, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x > camera.transform.position.x + 86.7f)
        {
            transform.position -= new Vector3(speedX, 0, 0) * Time.deltaTime;
        }

        if (transform.position.y < (camera.transform.position.y - 22.63f))
        {
            transform.position += new Vector3(0, speedY, 0) * Time.deltaTime;
        }

        if (transform.position.y > (camera.transform.position.y - 22.63f))
        {
            transform.position -= new Vector3(0, speedY, 0) * Time.deltaTime;
        }

        if (transform.localScale.x < 40.5)
        {
            transform.localScale += new Vector3(growthX, growthY, 0) * Time.deltaTime;
        }
    }
}
