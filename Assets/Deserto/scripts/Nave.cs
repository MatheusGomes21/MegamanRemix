using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{

    Animator naveAnimator;
    Animator laserAnimator;
    GameObject player;
    GameObject laser;

    //stats
    public float travelSpeedX;
    public float travelSpeedY;
    public float aimSpeed;
    public float cooldown;
    public float laserDuration;
    public string stage = "waiting"; //waiting --> aiming --> blinking --> shooting --> returning --> waiting

    float playerX;
    float playerY;
    float aimTravelRatioX;
    float aimTravelRatioY;
    bool enhancedTravelSpeed = false;

    //functions
    IEnumerator Wait()
    {
        if (enhancedTravelSpeed == true)
        {
            travelSpeedX /= aimTravelRatioX;
            travelSpeedY /= aimTravelRatioY;
            enhancedTravelSpeed = false;
        }
        
        transform.position = new Vector3(playerX - 1, playerY + 4.7f, 0);
        yield return new WaitForSeconds(cooldown);
        stage = "aiming";
    }

    IEnumerator Travel(Vector3 position, Vector3 scale)
    {
        //scale
        bool scaleX = false;
        bool scaleY = false;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scale.z);

        if (transform.localScale.x < scale.x)
        {
            transform.localScale += new Vector3(travelSpeedX, 0, 0) * Time.deltaTime;
        }

        if (transform.localScale.x > scale.x)
        {
            transform.localScale -= new Vector3(travelSpeedX, 0, 0) * Time.deltaTime;
        }

        if (transform.localScale.y < scale.y)
        {
            transform.localScale += new Vector3(0, travelSpeedY, 0) * Time.deltaTime;
        }

        if (transform.localScale.y > scale.y)
        {
            transform.localScale -= new Vector3(0, travelSpeedY, 0) * Time.deltaTime;
        }

        if (transform.localScale.x >= (scale.x - 0.01f) && transform.localScale.x <= (scale.x + 0.01f))
        {
            scaleX = true;
        }

        if (transform.localScale.y >= (scale.y - 0.01f) && transform.localScale.y <= (scale.y + 0.01f))
        {
            scaleY = true;
        }

        //position
        bool positX = false;
        bool positY = false;

        if (transform.position.x < position.x)
        {
            //aproximando
            if (scaleX == false && scaleY == false)
            {
                transform.position += new Vector3(travelSpeedX, 0, 0) * Time.deltaTime;
            }

            //mirando
            else if (scaleX == true && scaleY == true)
            {
                transform.position += new Vector3(aimSpeed, 0, 0) * Time.deltaTime;
            }
        }

        if (transform.position.x > position.x)
        {
            //aproximando
            if (scaleX == false && scaleY == false)
            {
                transform.position -= new Vector3(travelSpeedX, 0, 0) * Time.deltaTime;
            }

            //mirando
            else if (scaleX == true && scaleY == true)
            {
                transform.position -= new Vector3(aimSpeed, 0, 0) * Time.deltaTime;
            }
        }

        if (transform.position.x >= (position.x - 0.02f) && transform.position.x <= (position.x + 0.02f))
        {
            positX = true;
        }

        if (transform.position.y < position.y)
        {
            transform.position += new Vector3(0, travelSpeedY, 0) * Time.deltaTime;
        }

        if (transform.position.y > position.y)
        {
            transform.position -= new Vector3(0, travelSpeedY, 0) * Time.deltaTime;
        }

        if (transform.position.y >= (position.y - 0.02f) && transform.position.y <= (position.y + 0.02f))
        {
            positY = true;
        }

        if (positX == true && positY == true && scaleX == true && scaleY == true)
        {
            if (stage == "aiming")
            {
                naveAnimator.SetBool("Piscando", true);
                yield return new WaitForSeconds(7);
                stage = "shooting";
            }

            if (stage == "returning")
            {
                stage = "waiting";
            }
        }
    }

    IEnumerator Shoot()
    {
        laserAnimator.SetBool("Atirando", true);
        yield return new WaitForSeconds(2.094f);

        laser.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(laserDuration);

        laserAnimator.SetBool("Atirando", false);
        laserAnimator.SetBool("Parando", true);
        naveAnimator.SetBool("Piscando", false);
        laser.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForEndOfFrame();
        laserAnimator.SetBool("Parando", false);
        yield return new WaitForSeconds(4);
        stage = "returning";

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        laser = GameObject.Find("Laser");
        naveAnimator = gameObject.GetComponent<Animator>();
        laserAnimator = laser.GetComponent<Animator>();
        aimTravelRatioX = (aimSpeed / travelSpeedX) + 3;
        aimTravelRatioY = (aimSpeed / travelSpeedY) + 3;
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        
        if (stage == "waiting")
        {
            StartCoroutine(Wait());
        }

        if (stage == "aiming")
        {
            StartCoroutine(Travel(new Vector3(playerX, playerY + 3, 0), new Vector3(5, 5, 0)));
        }

        if (stage == "shooting")
        {
            StartCoroutine(Shoot());
        }

        if (stage == "returning")
        {
            if (enhancedTravelSpeed == false)
            {
                travelSpeedX *= aimTravelRatioX;
                travelSpeedY *= aimTravelRatioY;
                enhancedTravelSpeed = true;
            }
            
            StartCoroutine(Travel(new Vector3(playerX - 1, playerY + 4.7f, 0), new Vector3(3, 3, 0)));
        }
    }
}
