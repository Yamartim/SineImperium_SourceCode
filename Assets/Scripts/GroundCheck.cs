using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask layerChao;
    public bool isGrounded { get; private set; }

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = (collider != null && (((1 << collider.gameObject.layer) & layerChao) != 0));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

}
