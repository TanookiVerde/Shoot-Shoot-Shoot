using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup background;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Image player1;
    [SerializeField] private Image player2;
    [SerializeField] private TMP_Text victoryText;

    public void Open()
    {
        Time.timeScale = 1f;
        background.interactable = true;
        background.blocksRaycasts = true;
        background.DOFade(1, 0.25f);
        replayButton.GetComponent<RectTransform>().DOAnchorPosY(-500, 0.6f);
        exitButton.GetComponent<RectTransform>().DOAnchorPosY(-635, 0.4f);
        player1.GetComponent<RectTransform>().DOAnchorPosX(216, 0.5f);
        player2.GetComponent<RectTransform>().DOAnchorPosX(-216, 0.5f);
        victoryText.GetComponent<RectTransform>().DOAnchorPosY(-139, 0.5f);
    }
    public void InstaClose()
    {
        background.interactable = false;
        background.blocksRaycasts = false;
        background.DOFade(0, 0);
        replayButton.GetComponent<RectTransform>().DOAnchorPosY(500, 0);
        exitButton.GetComponent<RectTransform>().DOAnchorPosY(635, 0);
        player1.GetComponent<RectTransform>().DOAnchorPosX(-216, 0);
        player2.GetComponent<RectTransform>().DOAnchorPosX(216, 0);
        victoryText.GetComponent<RectTransform>().DOAnchorPosY(139, 0);
    }
    public void Replay()
    {
        SceneManager.LoadScene("CombatMode");
    }
    public void Exit()
    {
        SceneManager.LoadScene("CombatMode");
    }
}
