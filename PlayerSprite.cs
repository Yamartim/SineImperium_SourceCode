using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    bool switchCor = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }


    public void MudarCor()
    {
        if (switchCor)
        {
            sprite.color = Color.red;
            switchCor = false;
        }
        else
        {
            sprite.color = Color.blue;
            switchCor = true;
        }

    }

}
