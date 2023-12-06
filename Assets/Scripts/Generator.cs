
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private const float CREATE_INTERVAL = 0.18f;
    private float creatTime = 0;
    private float totalTime = 0;

    private float nextCreateInterval = CREATE_INTERVAL;

    private int phase = 1;

    public GameObject[] fruits;

    private void Update()
    {
        totalTime += Time.deltaTime;
        creatTime += Time.deltaTime;

        if (creatTime > nextCreateInterval)
        {
            creatTime = 0;
            nextCreateInterval = CREATE_INTERVAL - (0.005f * totalTime);

            if (nextCreateInterval < 0.005f) nextCreateInterval = 0.005f;

            for (int i = 0; i < phase; i++) CreatFruit(8f + i * 0.2f);
        }

        if (totalTime >= 10f)
        {
            totalTime = 0;
            phase++;
        }
    }
    
    

    private void CreatFruit(float y)
    {
        float x = Random.Range(-8f, 9f);
        int index = Random.Range(0, fruits.Length);  // 랜덤으로 과일 선택
        CreatObject(fruits[index], new Vector3(x, y, 0), Quaternion.identity);  // 선택한 과일 인스턴스화
    }

    private GameObject CreatObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }
}



