using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterColliderDestroy : MonoBehaviour
{
    GameManager gameManager;
   public BoxCollider2D boxCollider;
   
   
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {//길을 막고있으니 지나갈려면 콜라이더를 지워야함
        if (!gameManager.actionCollider) // GameManager에서 actionCollider가 false일 때만 실행
        {
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
        }
    }
}
