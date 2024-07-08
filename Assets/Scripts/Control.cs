using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public Animator anima;
    float xmov;
    public Rigidbody2D rdb;
    bool jump, doublejump;
    float jumptime, jumptimeside;
    public ParticleSystem fire;
    public Animator animator;


    int bullets;
    int maxBullets = 3;
    public float cutscene = -0.1f;
    public float cutsceneProgression = 0;
    GameObject bullet;

    void Start()
    {
        animator = GetComponent<Animator>();
        bullet = GameObject.Find("TiroCowboy");
        
    }
    void Update()
    {
        //o valor de cutscene indica quando positivo, o nivel e o numero da cutscene (primeira do nivel 0 eh 0.1). Se for negativo, indica a proxima cutscene q deve tocar (por exemplo, -0.1 indica q a proxima a tocar é a cutscne 0.1)

        //movement
        if (cutscene <= 0)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("Correndo", true);
            }

            else
            {
                animator.SetBool("Correndo", false);
            }
            if (Input.GetAxis("Fire1") != 0)
            {
                animator.SetBool("Atirando", true);
            }

            else
            {
                animator.SetBool("Atirando", false);
            }
            xmov = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                if (jumptime < 0.1f)
                {
                    doublejump = true;
                }
            }
            if (Input.GetButton("Jump"))
            {
                jump = true;
            }
            else
            {
                jump = false;
                doublejump = false;
                jumptime = 0;
                jumptimeside = 0;
            }
        }

        //CUTSCENES
        switch (cutscene)
        {
            //cutscene level 0
            case 0.1f:
                switch (cutsceneProgression)
                {
                    //progresso 0
                    case 0:
                        if (transform.position.x < -3.3f)
                        {
                            animator.SetBool("Correndo", true);
                            transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                        }

                        else
                        {
                            animator.SetBool("Correndo", false);
                            cutsceneProgression = 3; //aqui troca pra 1 ao inves do final
                        }
                        break;

                    //progresso 1
                    case 1:
                        break;

                    //progresso final
                    case 3:
                        cutscene = -1.1f;
                        break;
                }
                break;
        }
}

    void FixedUpdate()
    {
        Reverser();

        //rdb.velocity = new vector2(xmov * 1.3f, rdb.velocity.y);

        rdb.AddForce(new Vector2(xmov * 20 / (rdb.velocity.magnitude + 1), 0));

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit)
        {

            JumpRoutine(hit);
        }

        RaycastHit2D hitright;
        hitright = Physics2D.Raycast(transform.position +
            Vector3.up * 0.5f, transform.right, 1);

        if (hitright)
        {
            if (hitright.distance < 0.3f)
            {
                JumpRoutineSide(hitright);
            }
            Debug.DrawLine(hitright.point, transform.position
                + Vector3.up * 0.5f);
        }


    }
    /// <summary>
    /// rotina de pulo parte fisica
    /// </summary>
    /// <param name="hit">coloque aqui o raycast hit para altura do chao</param>
    private void JumpRoutine(RaycastHit2D hit)
    {
        if (hit.distance < 0.1f)
        {
            jumptime = 1;
        }


        if (jump)
        {
            jumptime = Mathf.Lerp(jumptime, 0, Time.fixedDeltaTime * 10);
            rdb.AddForce(Vector2.up * jumptime, ForceMode2D.Impulse);
        }

    }

    private void JumpRoutineSide(RaycastHit2D hitside)
    {
        if (hitside.distance < 0.3f)
        {

            jumptimeside = 1;

        }

        if (doublejump)
        {
            PhisicalReverser();
            jumptimeside = Mathf.Lerp(jumptimeside, 0, Time.fixedDeltaTime * 10);
            rdb.AddForce((hitside.normal * 50 + Vector2.up * 80) * jumptimeside);
        }
    }




    /// <summary>
    /// funcao pra inverter o personagem
    /// </summary>
    void Reverser()
    {
        if (xmov > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (xmov < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
    void PhisicalReverser()
    {
        if (rdb.velocity.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rdb.velocity.x < 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
        {
            LevelManager.instance.LowDamage();
        }
    }
}
