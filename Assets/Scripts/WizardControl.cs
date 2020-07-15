using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardControl : MonoBehaviour
{

    [SerializeField] GameObject wizLaserPrefab;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SoltaRaio(Vector2 dirRaio, float danoRaio, TipoMove moveRaio)
    {
        anim.SetTrigger("ATIRA");
        GameObject obj = Instantiate(wizLaserPrefab);
        RaioControl laser = obj.GetComponent<RaioControl>();
        laser.direcao = dirRaio;
        laser.dano = danoRaio;
        laser.desvio = moveRaio;
    }

}
