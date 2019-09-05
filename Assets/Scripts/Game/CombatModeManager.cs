using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatModeManager : MonoBehaviour
{
    [SerializeField] private List<PlayerInfo> playerInfo;
    [SerializeField] private MapInfo mapInfo;
    [SerializeField] private GameObject player;

    public int[] playersScore = new int[2];
    public int maxScore;

    public int currentTurn;

    private void Start()
    {
        StartCoroutine(LevelLoop());
    }
    private IEnumerator LevelLoop()
    {
        Initialize();
        FindObjectOfType<VictoryScreen>().InstaClose();
        while (!MatchEnded())
        {
            yield return null;
        }
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1f);
        FindObjectOfType<VictoryScreen>().Open();
    }
    private void Initialize()
    {
        playersScore = new int[2];
        FindObjectOfType<ScoreBoard>().InitializeScoreBoard(playerInfo);
        FindObjectOfType<ScoreBoard>().UpdateScoreBoard(playersScore);
        currentTurn = 0;
        foreach(PlayerInfo info in playerInfo)
        {
            var go = Instantiate(player);
            go.GetComponent<PlayerBehaviour>().Initialize(info, mapInfo);
            go.GetComponent<PlayerBehaviour>().Die += NewDeath;
        }
    }
    private void NewDeath(PlayerBehaviour player)
    {
        print("O JOGADOR " + player.playerInfo.type + "MORREU");
        playersScore[1-(int)player.playerInfo.type]++;
        currentTurn++;
        FindObjectOfType<ScoreBoard>().UpdateScoreBoard(playersScore);
        SwapPlayers();
    }
    private void SwapPlayers()
    {
        foreach(var p in FindObjectsOfType<PlayerBehaviour>())
        {
            p.Swap();
        }
    }
    private bool MatchEnded()
    {
        return playersScore[0] >= maxScore || playersScore[1] >= maxScore;
    }
}
