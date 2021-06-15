using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIStartMenuHandler : MonoBehaviour
{
    [SerializeField] private Text bestScore;
    [SerializeField] private InputField playerName;
    private string highScorePlayer;
    private int highScore;

    private void Awake()
    {
        SetBestScore();
    }
    public void StartButtonClick()
    {
        if (playerName.text != "")
        {
            GameManager.Instance.playerName = playerName.text;
            GameManager.Instance.LoadLevel();
        }
    }

    public void QuitButtonClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetBestScore()
    {
        highScorePlayer = GameManager.Instance.highScorePlayer;
        highScore = GameManager.Instance.highScore;
        bestScore.text = "Best Score: " + highScorePlayer + " : " + highScore.ToString();
    }
}
