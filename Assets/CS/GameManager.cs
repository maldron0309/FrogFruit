using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public GameObject gameOverPanel;
    [SerializeField] private GameObject restartBtn;
    
    [SerializeField] private  TextMeshProUGUI playTime;
    [SerializeField] private  TextMeshProUGUI gameOverTimeText;
    [SerializeField] private TextMeshProUGUI bestTime;
    

    public float t = 0; // play time

    private bool isGameOver = false;

    private void Awake()
    {
        restartBtn.SetActive(false);
        i = this;
    }

    private void Update()
    {
        if (isGameOver) return;

        t += Time.deltaTime;  // +=로 변경
        playTime.text = SetTime((int)t); 
    }

    string SetTime(int t)
    {
        string min = (t / 60).ToString(); // min

        if (int.Parse(min) < 10) min = "0" + min;

        string sec = (t % 60).ToString(); // sec
        
        if (int.Parse(sec) < 10) sec = "0" + sec;  // sec로 변경

        return min + ":" + sec;
    }

    private void SetBestTime()
    {
        if (PlayerPrefs.HasKey("BEST"))
        {
            int b = PlayerPrefs.GetInt("BEST");

            if ((int)t > b)
            {
                PlayerPrefs.SetInt("BEST",b = (int)t);
            }

            bestTime.text = "BEST : " + SetTime(b);
        }
        else
        {
            PlayerPrefs.SetInt("BEST",(int)t);
            bestTime.text = "BEST : " + SetTime((int)t);
        }

        bestTime.enabled = true;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverTimeText.text = "TIME : " + SetTime((int)t);
        gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
        restartBtn.SetActive(true);
        SetBestTime();
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}