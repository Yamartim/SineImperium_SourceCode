using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TipoMove
{
    Cima,
    Baixo,
    Esquerda,
    Direita,

    JumpEsquerda,
    JumpDireita,
    Para
}

public class MovQueue : MonoBehaviour
{

    int tamEnum = 7;

    [SerializeField] KeyCode teclaInvert = KeyCode.Space;

    [SerializeField] float speed = 1f;
    [SerializeField] float jSpeed = 1f;
    [SerializeField] float forcaPulo = 1f;

    public PainelController hudSetas;
    PlayerSprite pSprite;
    Rigidbody2D rb2D;
    GroundCheck gCheck;

    [SerializeField] int qtdMov = 5;

    [SerializeField] float moveCooldown = 3f;
    [SerializeField] float invertCooldown = 3f;
    float proxMove = 0f;
    float proxInvert = 0f;

    Queue<TipoMove> filaMovimentos;
    TipoMove moveAtual;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        gCheck = gameObject.GetComponentInChildren<GroundCheck>();
        pSprite = gameObject.GetComponentInChildren<PlayerSprite>();

        filaMovimentos = new Queue<TipoMove>(qtdMov);
        for (int i = 0; i < qtdMov; i++)
        {
            filaMovimentos.Enqueue(FilaRand());
        }
        hudSetas.SetTamanhoPainel(qtdMov);
        hudSetas.RefreshPainel(GetFilaMovs());

        //InvokeRepeating("FilaCycle", cooldown, cooldown);
    }

    private void Update()
    {
        if (Input.GetKeyDown(teclaInvert))
        {
            InverteFila();
        }
    }

    void FixedUpdate()
    {

        if (Time.time >= proxMove)
        {
            proxMove = Time.time + moveCooldown;
            ExecutaMovimento();
            FilaCycle(FilaRand());
        }

        if (gCheck.isGrounded == false)
        {
            //proxMove += Time.deltaTime;
            //adiciona mais delay enquanto ele esta pulando e nao chega no chao
        }
        
    }

    private void ExecutaMovimento()
    {
        moveAtual = filaMovimentos.Peek();

        switch (moveAtual)
        {
            case TipoMove.Cima:
                rb2D.velocity = Vector2.up * speed;
                break;
            case TipoMove.Baixo:
                rb2D.velocity = Vector2.down * speed;
                break;
            case TipoMove.Esquerda:
                rb2D.velocity = Vector2.left * speed;
                break;
            case TipoMove.Direita:
                rb2D.velocity = Vector2.right * speed;
                break;
            case TipoMove.JumpEsquerda:
                rb2D.velocity += (Vector2.left * jSpeed) + (Vector2.up * forcaPulo);
                break;
            case TipoMove.JumpDireita:
                rb2D.velocity += (Vector2.right * jSpeed) + (Vector2.up * forcaPulo);
                break;
            case TipoMove.Para:
                rb2D.velocity = Vector2.zero;
                break;
            default:
                break;
        }
    }

    //adiciona um elemento novo aleatorio na fila
    private TipoMove FilaRand()
    {
        TipoMove movimento;

        int select;
        int buffer = 8;
        int counter = 0;
        int newbuffer;

        //LOGICA DE SELEÇÃO ALEATORIA DE MOVIMENTOS AQUI
        //movimento = (TipoMove)Random.Range(0, tamEnum);

            select = Random.Range(1, 100);
            if (select >= 1 && select <= 12)
            {
                if (buffer == 2) {
                    counter++;
                }else { 
                    buffer = 2;
                }
            }
            else if (select >= 13 && select <= 41)
            {
                if (buffer == 3)
                {
                    counter++;
                }else{
                    buffer = 3;
                }
            }
            else if (select >= 42 && select <= 52)
            {
                if (buffer == 4)
                {
                    counter++;
                }else{
                    buffer = 4;
                }
            }
            else if (select >= 53 && select <= 81)
            {
                if (buffer == 5)
                {
                    counter++;
                }else{
                    buffer = 5;
                }
            }
            else
            {
                if (buffer == 6)
                {
                    counter++;
                }else{
                    buffer = 6;
                }
            }

            while(counter == 3){
                newbuffer = Random.Range(2,6);
                if (newbuffer != buffer){
                    buffer = newbuffer;
                    counter = 0;
                }
            }



        movimento = (TipoMove)buffer;

        return movimento;
    }


    //faz a fila ir pra frente
    void FilaCycle(TipoMove mov)
    {
        TipoMove frenteFila = filaMovimentos.Dequeue();
        filaMovimentos.Enqueue(mov);
        hudSetas.RefreshPainel(GetFilaMovs());

        //return frenteFila;
    }

    TipoMove[] GetFilaMovs()
    {
        return filaMovimentos.ToArray();
    }

    public void InverteFila()
    {
        
        if (Time.time >= proxInvert)
        {
            pSprite.MudarCor();

            proxInvert = Time.time + invertCooldown;
        
            TipoMove[] movs = GetFilaMovs();


            foreach(TipoMove revert in movs)
            {
                filaMovimentos.Dequeue();
                switch (revert)
                {
                    case TipoMove.Cima:
                        filaMovimentos.Enqueue(TipoMove.Baixo);
                        break;
                    case TipoMove.Baixo:
                        filaMovimentos.Enqueue(TipoMove.Cima);
                        break;
                    case TipoMove.Esquerda:
                        filaMovimentos.Enqueue(TipoMove.Direita);
                        break;
                    case TipoMove.Direita:
                        filaMovimentos.Enqueue(TipoMove.Esquerda);
                        break;
                    case TipoMove.JumpEsquerda:
                        filaMovimentos.Enqueue(TipoMove.JumpDireita);
                        break;
                    case TipoMove.JumpDireita:
                        filaMovimentos.Enqueue(TipoMove.JumpEsquerda);
                        break;
                    case TipoMove.Para:
                        filaMovimentos.Enqueue(TipoMove.Para);
                        break;
                    default:
                        break;
                }
                hudSetas.RefreshPainel(GetFilaMovs());

            }
        }
    }

    public void InterrompeMov(TipoMove movimento, float dano)
    {
        FilaCycle(movimento);
        proxMove += moveCooldown * dano; 
    }

}