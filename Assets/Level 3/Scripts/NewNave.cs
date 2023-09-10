using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNave : MonoBehaviour
{
    public float moveSpeed = 2f;      // Velocidade de movimento horizontal.
    public float moveDistance = 3f;   // Distância para a esquerda.
    public float moveHeight = 3f;     // Altura do movimento vertical.

    private Vector3 initialPosition;   // Posição inicial do objeto.
    private bool moveLeft = true;      // Sinalizador para controlar o movimento para a esquerda.

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Movimento horizontal para a esquerda.
        if (moveLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            // Se atingiu a distância desejada para a esquerda, alterne a direção.
            if (transform.position.x <= initialPosition.x - moveDistance)
            {
                moveLeft = false;
            }
        }
        else
        {
            // Movimento vertical para cima.
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Se atingiu a altura desejada, reinicie o movimento.
            if (transform.position.y >= initialPosition.y + moveHeight)
            {
                ResetPosition();
            }
        }
    }

    private void ResetPosition()
    {
        transform.position = initialPosition;
        moveLeft = true;
    }
}