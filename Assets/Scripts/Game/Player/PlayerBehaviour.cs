using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public MapInfo mapInfo;

    public delegate void Death(PlayerBehaviour player);
    public event Death Die;

    public bool isSwapped;

    public GameObject soul;

    public void Initialize(PlayerInfo playerInfo, MapInfo mapInfo)
    {
        this.playerInfo = playerInfo;
        this.mapInfo = mapInfo;
        GetComponent<Rigidbody2D>().gravityScale = GetGravityBias();
        GetComponent<SpriteRenderer>().flipY = GetGravityBias() < 0;
        GetComponent<SpriteRenderer>().color = playerInfo.mainColor;
        transform.position = GetInitialPosition();
    }
    public void Swap()
    {
        isSwapped = !isSwapped;
        StartCoroutine(Respawn());
    }
    public float GetGravityBias()
    {
        return isSwapped ? playerInfo.gravityBias : -playerInfo.gravityBias;
    }
    public Vector3 GetInitialPosition()
    {
        int index = isSwapped ? (int)playerInfo.type : 1 - (int)playerInfo.type;
        return mapInfo.initialPositions[index];
    }
    public void OnBulletTouch()
    {
        print("HIT");
        Die(this);
    }
    private IEnumerator Respawn()
    {
        var s = Instantiate(soul, transform.position, Quaternion.identity);
        var sr1 = GetComponent<SpriteRenderer>();
        var sr2 = s.GetComponent<SpriteRenderer>();

        gameObject.layer = LayerMask.NameToLayer("Safe");
        sr2.color = playerInfo.mainColor;
        s.transform.DOScale(0, 0);
        s.transform.DOScale(2, 0.4f);
        yield return new WaitForSeconds(0.2f);
        sr1.DOFade(0, 0);
        s.transform.DOMove(GetInitialPosition(),0.5f);
        yield return new WaitForSeconds(0.5f);
        s.transform.DOScale(0, 0.4f);
        yield return new WaitForSeconds(0.2f);
        sr1.DOFade(1, 0);
        Initialize(playerInfo, mapInfo);

        yield return new WaitForSeconds(0.001f);
        var c1 = sr1.color;
        var c2 = new Color(c1.r, c1.g, c1.b, 0.25f);
        for (int i = 0; i < 4; i++)
        {
            sr1.DOColor(c2, 0.2f);
            yield return new WaitForSeconds(0.2f);
            sr1.DOColor(c1, 0.2f);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 8; i++)
        {
            sr1.DOColor(c2, 0.1f);
            yield return new WaitForSeconds(0.1f);
            sr1.DOColor(c1, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<SpriteRenderer>().color = c1;
        gameObject.layer = LayerMask.NameToLayer("Normal");
    }
}
public enum PlayerType
{
    FIRST, SECOND
}
