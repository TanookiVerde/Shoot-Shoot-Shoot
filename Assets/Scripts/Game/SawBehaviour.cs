using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speed;
    private float bias;
    private float bonus = 1;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        bias = 1;
        bonus = 1;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Rotate();
        Move();
    }
    private void Rotate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * bias * bonus * Time.deltaTime);
    }
    private void Move()
    {
        rigidbody2D.velocity = Vector2.zero;
        transform.position += Vector3.right * speed * bias * bonus * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            var player = collision.gameObject.GetComponent<PlayerBehaviour>();
            player.OnBulletTouch();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bias *= -1;
            StartCoroutine(Accelerate());
        }
    }
    private IEnumerator Accelerate()
    {
        if (bonus == 1)
        {
            bonus = 2;
            yield return new WaitForSeconds(1f);
            bonus = 1;
        }
    }
}
