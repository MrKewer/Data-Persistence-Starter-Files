using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string highScorePlayer;
    public int highScore;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SaveHighScore(int score)
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.SetString("player", playerName);
            highScorePlayer = playerName;
            highScore = score;
        }
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        highScorePlayer = PlayerPrefs.GetString("player");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
