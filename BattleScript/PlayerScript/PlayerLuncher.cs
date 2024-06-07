using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLuncher : MonoBehaviour
{
    [SerializeField]
    private float damage = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossGauge>().TakeDamge(damage);

           // Destroy(gameObject);
        }
    }
}
