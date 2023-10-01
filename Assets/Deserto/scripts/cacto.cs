using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cacto : MonoBehaviour
{
    //stats
    public float range;
    public int waitTime;
    public float patrolSize;
    public float speed;
    public string modo = "d boa";
    float movement;
    


    //game Objects
    GameObject player;
    GameObject bullet;

    //components
    Animator animator;


    //functions
    bool shooting = false;
    IEnumerator Shoot()
    {
        modo = "bolado";
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
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Shooting", false);
        yield return new WaitForSeconds(waitTime);
        shooting = false;
    }

    IEnumerator Death()
    {
        shooting = true;

        animator.SetBool("Dead", true);

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
        animator.SetBool("Dead", false);
        yield return new WaitForSeconds(0.2f);
        gameObject.tag = "Deaded";
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        bullet = gameObject.transform.GetChild(0).gameObject;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Dead" && gameObject.tag != "Deaded")
        {
            //patrol
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            movement += Mathf.Abs(speed / 250);

            if (movement > patrolSize)
            {
                movement = 0;
                speed *= -1;
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            }

            //shoot
            if (transform.position.x > player.transform.position.x && (transform.position.x - player.transform.position.x) < range && shooting == false)
            {
                StartCoroutine(Shoot());
            }

            if (transform.position.x < player.transform.position.x && (player.transform.position.x - transform.position.x) < range && shooting == false)
            {
                StartCoroutine(Shoot());
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
            movement = 0;
        }
    }
}
