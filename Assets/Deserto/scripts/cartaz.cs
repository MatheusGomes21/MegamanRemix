using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cartaz : MonoBehaviour
{
    public float growthX;
    public float growthY;
    public float speedX;
    public float speedY;
    public float waitTime;
    bool change = false;

    GameObject player;
    GameObject camera;

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level 2");
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 200)
        {
            change = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        }

        if (change == true)
        {
            if (transform.position.x < camera.transform.position.x + 0.03f)
            {
                transform.position += new Vector3(speedX, 0, 0) * Time.deltaTime;
            }

            if (transform.position.x > camera.transform.position.x + 0.02f)
            {
                transform.position -= new Vector3(speedX, 0, 0) * Time.deltaTime;
            }

            if (transform.position.y < (camera.transform.position.y + 2.8f))
            {
                transform.position += new Vector3(0, speedY, 0) * Time.deltaTime;
            }

            if (transform.position.y > (camera.transform.position.y + 2.8f))
            {
                transform.position -= new Vector3(0, speedY, 0) * Time.deltaTime;
            }

            if (transform.localScale.x < 35.5)
            {
                transform.localScale += new Vector3(growthX, growthY, 0) * Time.deltaTime;
            }

            if (transform.localScale.x >= 40.5)
            {
                speedX = 3;
                speedY = 3;
            }

            StartCoroutine(ChangeScene());
        }
    }
}
