using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground") Destroy(this.gameObject);
        if (other.gameObject.tag == "Player") Destroy(this.gameObject);
    }
}
