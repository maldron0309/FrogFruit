using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")) Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Player")) Destroy(this.gameObject);
    }
}
