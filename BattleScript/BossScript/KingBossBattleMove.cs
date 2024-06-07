using System.Collections;
using UnityEngine;

public enum KingBossState { MoveToAppearPoint = 0, Phase01, Phase02 }
public class KingBossBattleMove : MonoBehaviour
{
   

    private ObjectPooling objectPooling;

    public float rushCoolTime = 1f;

    public float attackRate = 2f;
    public float timeSinceLastAttack = 0f; // 마지막 공격 이후의 시간
    private BossGauge bossObj;//죽을때 설정을위한것
    private GameManager gameManager;

    private BoxCollider2D boxCollider;

    public BgmController bgmController;
    // 이동 속도와 방향 설정
    

    public bool isRushing = false; // MoveRush 코루틴이 실행 중인지 나타
    [SerializeField]
    private StageData stageData;

    private EnemySpawner enemySpawner;

    Vector3 direction = Vector3.right;
    Vector3 dirY = Vector3.down;

    private float rushDelay = 2f; // 불린값이 변경되는 딜레이 시간
    private float timeSinceLastRush = 0f; // 마지막으로 불린값이 변경된 이후의 시간


    private Move2D move2D;

    private BossGauge bossGauge;
    private float bossTouchDamage = 3;//보스에 닿으면 죽음
    private MeteoriteSpawner meteoriteSpawner;

    private void Awake()
    {
        move2D = GetComponent<Move2D>();

        bossGauge = GetComponent<BossGauge>();
        objectPooling = GetComponent<ObjectPooling>();
        bossObj = FindObjectOfType<BossGauge>();  // 씬이 로드될 때 BossGauge를 찾습니다.
        gameManager = FindObjectOfType<GameManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        bgmController = GetComponent<BgmController>();
        boxCollider = FindObjectOfType<BoxCollider2D>();
        meteoriteSpawner = FindObjectOfType<MeteoriteSpawner>();


    }
    //독에 걸리면 공격을 못하게 몇초동안 그리고 색깔변하게

    private void FixedUpdate()
    {
        if (!isRushing)
        {
            // 스테이지의 경계에 도달하면 방향 전환
            if (transform.position.x >= stageData.LimitMax.x)
            {
                direction = Vector3.left; // 왼쪽 방향으로 이동
               

            }
            else if (transform.position.x <= stageData.LimitMin.x)
            {
                direction = Vector3.right; // 오른쪽 방향으로 이동
                
            }
            move2D.MoveTo(direction);
        }
        if (isRushing)
        {
            if (transform.position.y <=stageData.LimitMin.y)
            {
                dirY = Vector3.up;
                
            }
            else if (transform.position.y >= stageData.LimitMax.y)
            {
                dirY = Vector3.down;
                
            }
            move2D.MoveTo(dirY);

        }
       
    }
    private void Update()
    {
        // 시간 갱신
        timeSinceLastRush += Time.deltaTime;

        // 딜레이 시간이 지났으면 불린값 변경
        if (timeSinceLastRush >= rushDelay)
        {
            isRushing = !isRushing; // 불린값을 반전
            timeSinceLastRush = 0f; // 시간 초기화
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerGage>().TakeDamage(bossTouchDamage);

        }
    }
   
    
    private IEnumerator DisableAnimatorAfterDelay(float delay)
    {
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // fadeIn.enabled = false;
        enemySpawner.StartCoroutine(enemySpawner.SpawnEnemy());
    }

}
