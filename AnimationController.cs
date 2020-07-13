using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb2d;
    SpriteRenderer sprite;
    GroundCheck gCheck;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponentInParent<Rigidbody2D>();
        gCheck = transform.parent.GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("ANDANDO", Mathf.Abs(rb2d.velocity.x));
        anim.SetFloat("NO AR", Mathf.Abs(rb2d.velocity.y));
        anim.SetBool("GROUNDED", gCheck.isGrounded);
    }

    private void FixedUpdate()
    {
        CheckDirecao();
    }

    private void CheckDirecao()
    {
        if (rb2d.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        else if (rb2d.velocity.x < 0)
        {
            sprite.flipX = true;
        }
    }
}
