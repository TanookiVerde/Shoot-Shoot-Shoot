using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LookAnimation();
    }
    private void LookAnimation()
    {
        if(rigidbody2D.velocity.x != 0)
            spriteRenderer.flipX = rigidbody2D.velocity.x > 0;
    }
}
