using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) Destroy(gameObject);
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Death();
            Destroy(gameObject);
        }
    }
    
}
