using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{
    GameObject player;
    GameObject smoke;

    float alpha = 1;
    public float smokeDecayRate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cowboy");
        smoke = GameObject.Find("Smoke");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 245)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            smoke.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, alpha);
            alpha -= smokeDecayRate;
        }
    }
}
