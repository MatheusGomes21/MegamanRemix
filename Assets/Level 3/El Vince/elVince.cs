using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elVince : MonoBehaviour
{
    GameObject player;
    GameObject tentacleR;
    GameObject tentacleL;

    //components
    Animator animator;

    //stats
    public float life;
    public float range;
    public float speed;
    public string modo = "d boa";

    //Gambiarras
    AnimationClip currentAnim;
    string nextModo = "d boa";
    string[] ataques = { "mordendo", "batendo" };

    //avisar se andou p animacao andando
    int moved = 0;

    //FUNCTIONS

    //Set moved to true
    private void Moved(int value)
    {
        moved = value;
        return;
    }

    //Walk
    IEnumerator Walk(int direction = 1)
    {
        //set direction and mirror
        speed = Mathf.Abs(speed) * direction;
        transform.localScale = new Vector3(Mathf.Abs(direction) * 1, 1, 1);

        animator.SetBool("Walking", true);

        //move
        if ((currentAnim.name == "Step1Finish" && moved == 0) | (currentAnim.name == "Step2Start" && moved == 0))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (currentAnim.name != "Step1Finish" && currentAnim.name != "Step2Start")
        {
            moved = 0;
        }

        if (currentAnim.name == "Step2Finish")
        {
            animator.SetBool("Walking", false);
            nextModo = ataques[Random.Range(0, 2)];
        }

        yield return new WaitForSeconds(1);
    }

    //Bite
    IEnumerator Bite()
    {
        animator.SetBool("Biting", true);

        if (currentAnim.name == "BiteFinish")
        {
            animator.SetBool("Biting", false);
            nextModo = "d boa";
        }

        yield return new WaitForSeconds(1);
    }

    //Tentacle
    IEnumerator Tentacle(string side)
    {
        //set mirror
        if (side == "r")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            tentacleR.transform.position = new Vector3(tentacleR.transform.position.x, tentacleR.transform.position.y, 0.5f);
            tentacleL.transform.position = new Vector3(tentacleL.transform.position.x, tentacleL.transform.position.y, 0.5f);
        }

        if (side == "l")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            tentacleR.transform.position = new Vector3(tentacleR.transform.position.x, tentacleR.transform.position.y, -0.5f);
            tentacleL.transform.position = new Vector3(tentacleL.transform.position.x, tentacleL.transform.position.y, -0.5f);
        }
        
        //animate
        animator.SetBool("Tentacling", true);

        if (currentAnim.name == "TentacleFinish")
        {
            animator.SetBool("Tentacling", false);
            nextModo = "d boa";
        }

        yield return new WaitForSeconds(1);
    }

    void ResetTentacle()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        tentacleR.transform.position = new Vector3(tentacleR.transform.position.x, tentacleR.transform.position.y, 0.5f);
        tentacleL.transform.position = new Vector3(tentacleL.transform.position.x, tentacleL.transform.position.y, 0.5f);
    }

    //Death
    IEnumerator Death()
    {

        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Explosao", true);

        if (gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(4);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Explosao", false);
        gameObject.tag = "Deaded";
    }

    //change state (modo)
    void ChangeModo()
    {
        modo = nextModo;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        tentacleR = GameObject.Find("TentacleRight");
        tentacleL = GameObject.Find("TentacleLeft");

        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check current animation
        currentAnim = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        
        //define state
        if (gameObject.tag != "Deaded")
        {
            switch (modo)
            {
                case "d boa":

                    if (transform.position.x > player.transform.position.x && (transform.position.x - player.transform.position.x) < range && player.transform.position.y >= 30)
                    {
                        modo = "andando";
                    }

                    if (transform.position.x < player.transform.position.x && (player.transform.position.x - transform.position.x) < range && player.transform.position.y >= 30)
                    {
                        modo = "andando";
                    }

                    break;

                case "andando":

                    if (transform.position.x > player.transform.position.x)
                    {
                        StartCoroutine(Walk(-1));
                    }

                    if (transform.position.x < player.transform.position.x)
                    {
                        StartCoroutine(Walk(1));
                    }

                    break;

                case "mordendo":

                    StartCoroutine(Bite());

                    break;

                case "batendo":

                    if (transform.position.x > player.transform.position.x)
                    {
                        StartCoroutine(Tentacle("l"));
                    }

                    if (transform.position.x < player.transform.position.x)
                    {
                        StartCoroutine(Tentacle("r"));
                    }

                    break;
            }
        }

        if (gameObject.tag == "Dead" && life > 0)
        {
            life -= 1;
            gameObject.tag = "Enemy";
        }

        else if (gameObject.tag == "Dead")
        {
            StartCoroutine(Death());
        }
    }
}
