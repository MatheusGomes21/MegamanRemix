using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class calango : MonoBehaviour
{
    //stats
    public float range;
    public int waitTime;
    public string modo = "d boa";
    float alpha = 1;
    int invisiProgress = 0;



    //game Objects
    GameObject player;
    GameObject bullet;

    //components
    Animator animator;
    SpriteRenderer renderer;


    //functions
    bool shooting = false;

    IEnumerator Invisilate()
    {
        animator.SetBool("Invisilating", true);
        yield return new WaitForSeconds(0.5f);

        if (alpha > 0 && invisiProgress == 0)
        {
            alpha -= 0.006f;
            renderer.color = new Color(1, 1, 1, alpha);
        }

        if (alpha < 0 && invisiProgress == 0)
        {
            transform.position = new Vector3(player.transform.position.x + range, player.transform.position.y + 0.225f, 0);
            yield return new WaitForSeconds(4);
            invisiProgress = 1;
            alpha = 0.01f;
        }

        if (alpha < 1 && invisiProgress == 1)
        {
            alpha += 0.006f;
            renderer.color = new Color(1, 1, 1, alpha);
        }

        if (alpha > 1 && invisiProgress == 1)
        {
            invisiProgress = 0;
            animator.SetBool("Invisilating", false);
            modo = "atirando";
        }
    }

    IEnumerator Shoot()
    {
        float spawnpointX = 0;

        if (transform.position.x > player.transform.position.x)
        {
            spawnpointX = -1;
            transform.localScale = new Vector3(1, 1, 1);
            bullet.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (transform.position.x < player.transform.position.x)
        {
            spawnpointX = 1;
            transform.localScale = new Vector3(-1, 1, 1);
            bullet.transform.localScale = new Vector3(1, 1, 1);
        }

        spawnpointX = transform.position.x + spawnpointX;

        animator.SetBool("Shooting", true);
        Instantiate(bullet, new Vector3(spawnpointX, transform.position.y, 0), transform.rotation);
        shooting = true;
        yield return new WaitForSeconds(1f);
        animator.SetBool("Shooting", false);
        yield return new WaitForSeconds(waitTime);
        shooting = false;
        modo = "d boa";
    }

    IEnumerator Death()
    {   
        shooting = true;

        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(1).GetComponent<Animator>().SetBool("Explosao", true);

        if (gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(4);
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<Animator>().SetBool("Explosao", false);
        gameObject.tag = "Deaded";
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        bullet = gameObject.transform.GetChild(0).gameObject;
        animator = gameObject.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Dead" | gameObject.tag != "Deaded")
        {
            switch (modo)
            {
                case "d boa":

                    renderer.color = new Color(1, 1, 1, 1);

                    if (transform.position.x > player.transform.position.x && (transform.position.x - player.transform.position.x) < range && shooting == false)
                    {
                        modo = "invisilando";
                    }

                    if (transform.position.x < player.transform.position.x && (player.transform.position.x - transform.position.x) < range && shooting == false)
                    {
                        modo = "invisilando";
                    }

                    break;

                case "invisilando":

                    StartCoroutine(Invisilate());

                    break;

                case "atirando":
                    if (shooting == false)
                    {
                        StartCoroutine(Shoot());
                    }

                    break;
            }
        }

        //death
        if (gameObject.tag == "Dead")
        {
            StartCoroutine(Death());
        }

        if (gameObject.tag == "Deaded")
        {
            //stats reset
            alpha = 1;
            modo = "d boa";
            animator.SetBool("Invisilating", false);
            animator.SetBool("Shooting", false);
        }
    }
}