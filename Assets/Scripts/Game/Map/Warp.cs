using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Saw"))
        {
            print("WARP COLLIDER");
            collision.gameObject.transform.position = new Vector3(
                -collision.gameObject.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z
                );
        }
    }
}
