using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class ShootByInput : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Vector2 shootingPosition;

    private void Start()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
    }
    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetButtonDown(playerBehaviour.playerInfo.shootButton))
        {
            var position = transform.position + (Vector3) shootingPosition * playerBehaviour.GetGravityBias();
            var go = Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletBehaviour>().Initialize(playerBehaviour);
        }
    }
}
