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
    private GameObject PainelOpçoes;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
    }

    public void AbrirOpçoes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpçoes.SetActive(true);
    }

    public void FecharOpçoes()
    {
        PainelOpçoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
