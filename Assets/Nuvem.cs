using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour
{
    bool right = true;
    public float limiteDir,limiteEsq;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.position = new Vector3(0.00005f, 0, 0);
        if (transform.position.x > limiteDir) 
            {
                right = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            // Se está indo para a esquerda, subtrai da posição no eixo X
            transform.position -= new Vector3(0.005f, 0, 0);
            if (transform.position.x < limiteEsq)
            {
                // Se atingir o limite esquerdo, inverte a direção e vira o objeto 0 grau (voltando à posição inicial)
                right = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }
}
