using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fernando : MonoBehaviour
{
    public float speed;
    float movement = 0;
    bool running = false;

    IEnumerator Run()
    {
        gameObject.GetComponent<Animator>().SetBool("Olhando", true);
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Animator>().SetBool("Olhando", false);
        gameObject.GetComponent<Animator>().SetBool("Andando", true);
        transform.localScale = new Vector3(-1, 1, 1);
        running = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            StartCoroutine(Run());
            
            if (running)
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                movement += speed / 250;

                if (movement >= 8f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
