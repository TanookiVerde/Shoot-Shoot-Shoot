using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour),typeof(Rigidbody2D))]
public class JumpByInput : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    private Rigidbody2D rigidbody2D;

    [Header("Ground Check")]
    [SerializeField] private Vector2 groundLocalPosition;
    [SerializeField] private Vector2 groundBoxCastSize;

    [Header("Preferences")]
    [SerializeField] private float jumpIntensity;

    private void Start()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
    }
    private void OnDrawGizmos()
    {
        var position = (transform.position + (Vector3)groundLocalPosition * GetComponent<PlayerBehaviour>().GetGravityBias());
        Gizmos.DrawWireCube(position, groundBoxCastSize);
    }
    private void Jump()
    {
        if(Input.GetButtonDown(playerBehaviour.playerInfo.jumpButton) && IsGrounded())
        {
            rigidbody2D.AddForce(Vector2.up * jumpIntensity * playerBehaviour.GetGravityBias());
        }
    }
    private bool IsGrounded()
    {
        if (rigidbody2D.velocity.y * playerBehaviour.GetGravityBias() > 0)
            return false;
        RaycastHit2D boxCast = Physics2D.BoxCast(
                (transform.position + (Vector3)groundLocalPosition * playerBehaviour.GetGravityBias()),
                groundBoxCastSize, 0, Vector2.up * playerBehaviour.GetGravityBias(), 
                0, LayerMask.GetMask("Ground"));
        return boxCast.collider != null;
    }
}
