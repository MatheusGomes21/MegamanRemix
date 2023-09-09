using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorBase : MonoBehaviour
{
    public float alturaInicial = 0f;   // Altura inicial do elevador
    public float alturaMaxima = 5f;    // Altura m�xima do elevador
    public float velocidadeSubida = 2f; // Velocidade de subida
    public float velocidadeDescida = 1f; // Velocidade de descida
    public float tempoDeEspera = 2f;   // Tempo de espera no topo/baixo

    private bool subindo = true;       // Flag para indicar se o elevador est� subindo ou descendo
    private float tempoEspera;         // Tempo de espera atual

    private void Update()
    {
        if (subindo)
        {
            // Elevador est� subindo
            transform.Translate(Vector3.up * velocidadeSubida * Time.deltaTime);

            // Verifica se atingiu a altura m�xima
            if (transform.position.y >= alturaMaxima)
            {
                subindo = false;
                tempoEspera = 0;
            }
        }
        else
        {
            // Elevador est� descendo
            transform.Translate(Vector3.down * velocidadeDescida * Time.deltaTime);

            // Verifica se atingiu a altura inicial
            if (transform.position.y <= alturaInicial)
            {
                subindo = true;
                tempoEspera = 0;
            }
        }

        // Verifica se � hora de esperar
        if (tempoEspera < tempoDeEspera)
        {
            tempoEspera += Time.deltaTime;
        }
        else
        {
            // Reinicia o movimento ap�s o tempo de espera
            tempoEspera = 0;
        }
    }

    // M�todo para controlar a altura manualmente
    public void MoverParaAltura(float altura)
    {
        altura = Mathf.Clamp(altura, alturaInicial, alturaMaxima);
        transform.position = new Vector3(transform.position.x, altura, transform.position.z);
    }
}