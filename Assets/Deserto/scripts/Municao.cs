using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    public List<GameObject> recargas;
    public int cargas = 5;
    GameObject mira;

    //funcao recarregar
    IEnumerator Recarregar()
    {
        mira.GetComponent<Animator>().SetBool("Recarregando", true);
        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(0.33f);
            
            if (cargas < i)
            {
                cargas = i;
            }
        }
        mira.GetComponent<Animator>().SetBool("Recarregando", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        mira = GameObject.Find("Mira");
    }

    // Update is called once per frame
    void Update()
    {
        //nao rodar
        transform.rotation = Quaternion.Euler(0, 0, 0);

        //atualizar display de balas
        foreach(GameObject recharge in recargas)
        {
            recharge.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

            if (recargas.IndexOf(recharge) > cargas)
            {
                continue;
            }

            recharge.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }

        //descarregar/atirar
        if (Input.GetButtonDown("Fire1"))
        {
            cargas -= 1;
        }

        //recarregar
        if (Input.GetButtonDown("Recarga"))
        {
            StartCoroutine(Recarregar());
            

        }
    }
}
