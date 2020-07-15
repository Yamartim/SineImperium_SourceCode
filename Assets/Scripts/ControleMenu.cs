using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleMenu : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;

    

    public void ClickPlay()
    {

        StartCoroutine(CarregarJogo());
    }


    IEnumerator CarregarJogo()
    {
        fadeAnim.SetTrigger("START_FADE");

        yield return new WaitForSeconds(1.1f);

        SceneManager.LoadScene("CenaMain");
    }

    public void SairDoJogo ()
    {
        Debug.Log("é pra sair do jogo");
        Application.Quit();
    }


}
