using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text p1Score;
    [SerializeField] private TMP_Text p2Score;

    public void InitializeScoreBoard(List<PlayerInfo> infos)
    {
        p1Score.color = infos[0].mainColor;
        p2Score.color = infos[1].mainColor;
    }
    public void UpdateScoreBoard(int[] score)
    {
        p1Score.text = score[0].ToString();
        p2Score.text = score[1].ToString();
    }
}
