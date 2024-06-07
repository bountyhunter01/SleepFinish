using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGage : MonoBehaviour
{
    [SerializeField]
    private float minGauge = 0;

   
    public float maxGauge = 3;

    private float currentGauge;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    public float MinGauge => minGauge;//minGauge get만 변수에 접근가능 인수값으로
    public float CurrentGauge => currentGauge;

    private void Awake()
    {
        currentGauge = minGauge;
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }
    public void TakeDamage(float damage)
    {
        currentGauge += damage;

        StopColorAnimation();
        StartColorAnimation();

        if (currentGauge >= maxGauge)
        {
            playerController.OnInsomia();
        }
    }

    private void StartColorAnimation()
    {
        spriteRenderer.color = Color.black;
        Invoke("StopColorAnimation", 0.5f); // 0.5초 후에 StopColorAnimation 메소드를 호출
    }

    private void StopColorAnimation()
    {
        spriteRenderer.color = Color.white;
    }


}
