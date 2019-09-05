using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveByInput : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private PlayerBehaviour playerBehaviour;

    [Header("Input")]
    [SerializeField] private string horizontalAxisName;

    [Header("Preferences")]
    [SerializeField] private float speed;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerBehaviour = GetComponent<PlayerBehaviour>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        var axis = Input.GetAxisRaw(playerBehaviour.playerInfo.moveAxis);
        var y = rigidbody2D.velocity.y;
        rigidbody2D.velocity = new Vector2(axis * speed, y);
    }
}
