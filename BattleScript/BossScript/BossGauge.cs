using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossGauge : MonoBehaviour
{
    public float minGauge = 0;
    
    public float bossMaxGauge = 100;

    public GameObject BossObject;
    public float currentGauge;
    private SpriteRenderer SpriteRenderer;
    private TreeBossMove2D bossMove2D;


    public bool IsSleeping;

    [SerializeField]
    private string nextSceneName;//다음씬넘어가기;

    private void Awake()
    {
        currentGauge = minGauge;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        bossMove2D = GetComponent<TreeBossMove2D>();
        
    }
    public void TakeDamge(float damage)
    {
        currentGauge += damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        if (currentGauge >= bossMaxGauge)
        {
            OnSleeping();
        }
    }
    public void OnSleeping()
    {
        IsSleeping = true;
        StartCoroutine(TransitionToScene(nextSceneName));
        //이부분은 애니메이션으로 원래 제자리로 돌아가게끔 만들자
        //돌아가는 애니메이션 만들었으니 그걸로 할당
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        yield return new WaitForSeconds(1f); // 딜레이 추가
        SpriteRenderer.color = Color.gray;
        
        BossObject.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
    private IEnumerator HitColorAnimation()
    {
        SpriteRenderer.color = Color.red ;
        yield return new WaitForSeconds(0.5f);
        SpriteRenderer.color = Color.white ;
    }
}
