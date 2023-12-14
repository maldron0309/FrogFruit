using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // 생성 간격의 초기값
    private const float CREATE_INTERVAL = 0.1f;
    // 생성된 시간을 저장할 변수
    private float creatTime = 0;
    // 총 경과 시간을 저장할 변수
    private float totalTime = 0;

    // 다음 생성 간격
    private float nextCreateInterval = CREATE_INTERVAL;

    // 현재 단계
    private int phase = 1;

    // 포인트 과일
    [SerializeField] private GameObject pointFruit = null;

    // 생성할 과일들
    public GameObject[] fruits;
    
    private void Start()
    {
        // 30초 후에 포인트 과일을 선택하는 함수를 호출합니다.
        Invoke("SelectPointFruit", 30f); 
    }

    private void Update()
    {
        // 경과 시간을 누적합니다.
        totalTime += Time.deltaTime;
        creatTime += Time.deltaTime;

        // 생성 시간이 다음 생성 간격보다 클 경우
        if (creatTime > nextCreateInterval)
        {
            // 생성 시간을 초기화하고, 다음 생성 간격을 조정합니다.
            creatTime = 0;
            nextCreateInterval = CREATE_INTERVAL - (0.005f * totalTime);

            // 다음 생성 간격이 너무 작아지지 않도록 합니다.
            if (nextCreateInterval < 0.005f) nextCreateInterval = 0.005f;

            // 현재 단계만큼 과일을 생성합니다.
            for (int i = 0; i < phase; i++) CreatFruit(8f + i * 0.2f);
        }

        // 총 경과 시간이 10초가 넘으면 단계를 증가시키고, 총 경과 시간을 초기화합니다.
        if (totalTime >= 10f)
        {
            totalTime = 0;
            phase++;
        }
    }
    
    // 포인트 과일을 랜덤으로 선택하는 함수입니다.
    private void SelectPointFruit()
    {
        int index = Random.Range(0, fruits.Length);
        pointFruit = fruits[index]; 
    }
    
    // 랜덤한 위치에 과일을 생성하는 함수입니다.
    private void CreatFruit(float y)
    {
        float x = Random.Range(-8f, 9f);
        int index = Random.Range(0, fruits.Length);  // 랜덤으로 과일 선택
        CreatObject(fruits[index], new Vector3(x, y, 0), Quaternion.identity);  // 선택한 과일 인스턴스화
    }

    // 오브젝트를 생성하고, 생성된 오브젝트를 리턴하는 함수입니다.
    private GameObject CreatObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }
}
