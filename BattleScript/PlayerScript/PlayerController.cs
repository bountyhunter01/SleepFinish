using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;

    [SerializeField]
    private string nextSceneName;

    private bool isInsomia = false;
    private Move2D move2D;
    private Weapon weapon;
    private Animator animator;
   
    public GameObject playrtGauge;
    public GameObject player;

    private bool isAttack = true;

    private SpriteRenderer spriteRenderer;
    

    public CameraPlayerMode cameraMode;

    public float damage = 1;
    private void Awake()
    {
        move2D = GetComponent<Move2D>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
       
       cameraMode = FindObjectOfType<CameraPlayerMode>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playrtGauge.SetActive(false);
    } 
    private void Update()
    {
        //이동 공격 불가능하게설정
        if (isInsomia == true) return; 
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        move2D.MoveTo(new Vector3(x, y, 0));

        if (Input.GetMouseButtonDown(0)&&isAttack)
        {
            weapon.StartFiring();
        }if (Input.GetMouseButtonUp(0)&&isAttack)
        {
            weapon.StopFiring();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossGauge>().TakeDamge(damage);
            StopAllCoroutines();
            OnInsomia();
            //공격패턴도 같이 사라지면 좋을것
        }
        if (collision.CompareTag("Honey"))
        {
            StartCoroutine(SpeedBoost());
        }
        if (collision.CompareTag("Smoke")&&player!=null)
        {
            StartCoroutine(DebuffSmoke());
        }
    }
    IEnumerator DebuffSmoke()
    {
        spriteRenderer.color = Color.black;
        isAttack = false;
        yield return new WaitForSeconds(2f);
        isAttack =true;
        spriteRenderer.color = Color.white;
    }
    IEnumerator SpeedBoost()
    {
        spriteRenderer.color = Color.yellow;
        move2D.moveSpeed = 2f;
        yield return new WaitForSeconds(2f);
        spriteRenderer.color = Color.white;
        move2D.moveSpeed = 6f; // 원래의 속도로 복구
    }

    private void LateUpdate()
    {
        //플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록함
       
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x,stageData.LimitMax.x), Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));

        
    }
    public void OnInsomia()
    {
        move2D.MoveTo(Vector3.zero);//이동 초기화
       // animator.SetTrigger("OnInsomia");//사망애니메이션 재생
        Destroy(GetComponent<PolygonCollider2D>());//적과 충돌하지않게 충독박스 삭제
        isInsomia = true;//사망시 키 작동 불가 
        OnInsomiaEvent();
    }

    public void OnInsomiaEvent()
    {   //게임오버 씬으로이동
        player.SetActive(false);
        SceneManager.LoadScene(nextSceneName);
        
    }
}

