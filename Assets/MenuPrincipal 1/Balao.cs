using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balao : MonoBehaviour
{
    public float speed;
    public float waitTime;
    bool rising;

    GameObject player;

    IEnumerator ChangeScene()
    {
        player.SetActive(false);

        rising = true;

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level 1");
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        if (rising)
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cowboy")
        {
            StartCoroutine(ChangeScene());
        }
    }
}

