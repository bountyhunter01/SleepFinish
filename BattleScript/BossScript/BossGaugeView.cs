using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGaugeView : MonoBehaviour
{
    [SerializeField]
    private BossGauge bossGauge;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        slider.value = bossGauge.currentGauge /5;
    }
}
