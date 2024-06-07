using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyMeteo : MonoBehaviour
{
    
    public GameObject prefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            Destroy(prefab);
        }
    }
}
