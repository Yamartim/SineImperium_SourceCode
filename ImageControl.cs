using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    
    [SerializeField] Sprite setaCima;
    [SerializeField] Sprite setaBaixo;
    [SerializeField] Sprite setaEsq;
    [SerializeField] Sprite setaDir;

    [SerializeField] Sprite setaJEsq;
    [SerializeField] Sprite setaJDir;
    [SerializeField] Sprite stop;

    
    public void SetImagem(TipoMove tipo)
    {

        //placeholder
        gameObject.GetComponent<Image>().color = Color.white;

        switch (tipo)
        {
            case TipoMove.Cima:
                gameObject.GetComponent<Image>().sprite = setaCima;
                break;
            case TipoMove.Baixo:
                gameObject.GetComponent<Image>().sprite = setaBaixo;
                break;
            case TipoMove.Esquerda:
                gameObject.GetComponent<Image>().sprite = setaEsq;
                break;
            case TipoMove.Direita:
                gameObject.GetComponent<Image>().sprite = setaDir;
                break;
            case TipoMove.JumpEsquerda:
                gameObject.GetComponent<Image>().sprite = setaJEsq;
                //placeholder
                gameObject.GetComponent<Image>().color = Color.green;
                break;
            case TipoMove.JumpDireita:
                gameObject.GetComponent<Image>().sprite = setaJDir;
                //placeholder
                gameObject.GetComponent<Image>().color = Color.green;
                break;
            case TipoMove.Para:
                gameObject.GetComponent<Image>().sprite = stop;
                //placeholder
                gameObject.GetComponent<Image>().color = Color.black;
                break;
            default:
                break;
        }
    }
}
