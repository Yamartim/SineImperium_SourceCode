using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelController : MonoBehaviour
{

    [SerializeField]
    private int numPainel = 5;  //mudar isso pra receber um valor determinado em outro script
    [SerializeField]
    GameObject setaPrefab;      //contem o prefab com o objeto da seta

    ImageControl[] imgSeta;
    public AudioSource audiosource;

    //Text[] txtSetas;
    //vetor que pega as informacoes de cada seta

    // Start is called before the first frame update
    void Awake()
    {
        imgSeta = new ImageControl[numPainel];

        for (int i = 0; i < numPainel; i++)
        {
            GameObject seta = GameObject.Instantiate(setaPrefab, this.transform);
            if (i == 0)
            {
                seta.GetComponent<Image>().color = Color.red;
            }
            imgSeta[i] = seta.GetComponent<ImageControl>();
            //retornar a referencia de cada instantiate pro vetor
        }

    }
    
    public void SetTamanhoPainel(int num)
    {
        numPainel = num;
    }

    public void RefreshPainel(TipoMove[] movimentos)//vai recever um vetor com informacoes das setas novas
    {
        AudioClip clip = audiosource.clip;
        //atualiza o UI
        for (int i = 0; i < numPainel; i++)
        {
            imgSeta[i].SetImagem(movimentos[i]);
            //placeholder
            if (i == 0)
            {
                imgSeta[i].gameObject.GetComponent<Image>().color = Color.red;
            }
            audiosource.PlayOneShot(clip);
        }
        
    }

}
