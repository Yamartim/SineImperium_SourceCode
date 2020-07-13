using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisicaPulo : MonoBehaviour
{
    [SerializeField] float fallMultiplier = 2.5f;

    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1);
        }
    }

}
