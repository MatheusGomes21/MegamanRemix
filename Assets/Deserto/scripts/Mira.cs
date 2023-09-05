using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public Animator animator;
    Camera camera;
    Vector3 mousePosit;
    float rotation;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //follow mouse
        mousePosit = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosit.x, mousePosit.y, 0);

        //spin
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        rotation += 0.2f;

        animator.SetBool("Acertou", false);

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Acertou", true);
        }
    }
}
