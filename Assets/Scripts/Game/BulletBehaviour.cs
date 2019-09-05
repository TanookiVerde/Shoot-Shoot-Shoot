using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bias;
    [SerializeField] private PlayerType creator;
    [SerializeField] private GameObject littleExplosion;

    public void Initialize(PlayerBehaviour player)
    {
        this.bias = player.GetGravityBias();
        this.creator = player.playerInfo.type;
        GetComponent<SpriteRenderer>().flipY = bias < 0;
        GetComponent<SpriteRenderer>().color = player.playerInfo.mainColor;
    }
    private void Update()
    {
        transform.position += Vector3.up * bias * speed * 0.1f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            KillMe();
        }else if (collision.gameObject.CompareTag("Saw"))
        {
            KillMe();
        }else if(collision.gameObject.GetComponent<PlayerBehaviour>() != null)
        {
            var player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (player.playerInfo.type != creator)
            {
                player.OnBulletTouch();
                KillMe();
            }
        }
    }
    private void KillMe()
    {
        Destroy(this.gameObject);
        var go = Instantiate(littleExplosion, transform.position, Quaternion.identity);
        Destroy(go, 0.3f);
    }
}
