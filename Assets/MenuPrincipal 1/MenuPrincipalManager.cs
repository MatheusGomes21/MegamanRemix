using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]
    private string NomeDoLevelDeJogo;
    [SerializeField]
    private GameObject PainelMenuInicial;
    [SerializeField]
    private GameObject PainelOpaçoes;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
    }

    public void AbrirOpçoes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpaçoes.SetActive(true);
    }

    public void FecharOpçoes()
    {
        PainelOpaçoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
