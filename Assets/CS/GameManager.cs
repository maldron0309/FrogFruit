using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public TextMeshProUGUI playTime; 

    public float t = 0; // play time

    private bool isGameOver = false;

    private void Awake()
    {
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
}