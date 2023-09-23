using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mira : MonoBehaviour
{
    public Animator animator;
    public Animator fxAnimator;
    public Municao municao;
    GameObject tiroFx;
    GameObject enemy;
    Camera camera;
    Vector3 mousePosit;
    float rotation;
    string[] inimigos = { "Cobra", "Cacto" };
    string animacao = "Errou";


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
        tiroFx = GameObject.Find("TiroEfeito");
    }

    // Update is called once per frame
    void Update()
    {
        //hide cursor
        Cursor.visible = false;

        //follow mouse
        mousePosit = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosit.x, mousePosit.y, -3);
        tiroFx.transform.position = transform.position;

        //spin
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        
        if (municao.recarregando == false)
        {
            rotation += 0.2f;
        }

        else
        {
            rotation += 0.8f;
        }

        //atirar
        animator.SetBool("Errou", false);
        animator.SetBool("Acertou", false);

        if (Input.GetButtonDown("Fire1") && municao.cargas >= -1 && municao.recarregando == false)
        {
            animator.SetBool(animacao, true);
            fxAnimator.SetBool("Pow", true);

            enemy.tag = "Dead";
        }

        else
        {
            animator.SetBool(animacao, false);
            fxAnimator.SetBool("Pow", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            animacao = "Acertou";
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animacao = "Errou";
        enemy = null;
    }
}
