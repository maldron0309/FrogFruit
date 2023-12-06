using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fruit;

    private void Awake()
    {
        StartCoroutine(CreateFruitRoutine());
    }

    IEnumerator CreateFruitRoutine()
    {
        while (true)
        {
            CreateFruit();
            yield return new WaitForSeconds(1);
        }
    }

    private void CreateFruit()
    {
        Vector3 pos = new Vector3(0, 4, 0);
        Instantiate(fruit, pos, Quaternion.identity);
    }
}
