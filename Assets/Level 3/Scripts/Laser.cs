using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D laser;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        laser.velocity = new Vector2(0, speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine(DelayedDestroy(1f));
           
        }
    
    }
    private IEnumerator DelayedDestroy(float atrasoEmSegundos)
    {
        // Aguarda o atraso especificado
        yield return new WaitForSeconds(atrasoEmSegundos);

        // Após o atraso, destrua o objeto
        Destroy(this.gameObject);
    }
}
