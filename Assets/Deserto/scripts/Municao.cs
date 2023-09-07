using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    public List<GameObject> recargas;
    public int cargas = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //nao rodar
        transform.rotation = Quaternion.Euler(0, 0, 0);

        //carregar? sla
        foreach(GameObject recharge in recargas)
        {
            recharge.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

            if (recargas.IndexOf(recharge) > cargas)
            {
                continue;
            }

            recharge.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            MonoBehaviour.print(cargas);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            cargas -= 1;
        }
    }
}
