using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimFase : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    Animator playerAnim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAnim = collision.gameObject.GetComponentInChildren<Animator>();
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(EncerrarJogo());
        }
    }



    IEnumerator EncerrarJogo()
    {
        playerAnim.SetTrigger("WIN");

        yield return new WaitForSeconds(1.1f);

        fadeAnim.SetTrigger("START_FADE");

        yield return new WaitForSeconds(1.1f);

        SceneManager.LoadScene("CenaMenu");
    }

}
