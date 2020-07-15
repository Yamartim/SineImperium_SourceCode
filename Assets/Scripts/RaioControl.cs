using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioControl : MonoBehaviour
{
    [SerializeField] float speed;
    public Vector2 direcao;
    public float dano;
    public TipoMove desvio;

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = direcao * speed;
        transform.forward = direcao;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovQueue>().InterrompeMov(desvio, dano);
            Destroy(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        //se bater em alguma coisa troca direcao?

    }

}
