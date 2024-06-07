using System.Collections;
using UnityEngine;


public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02 }
public class TreeBossMove2D : MonoBehaviour
{

    private ObjectPooling objectPooling;

    public float attackRate = 2f;
    public float timeSinceLastAttack = 0f; // 마지막 공격 이후의 시간
    private BossGauge bossObj;//죽을때 설정을위한것
    public GameObject talkPanel;

    private BoxCollider2D boxCollider;

    public BgmController bgmController;
    // 이동 속도와 방향 설정
    public float bossSpeed = 5f; // 예시로 5의 속도를 사용합니다.

    [SerializeField]
    private StageData stageData;

    private EnemySpawner enemySpawner;

    Vector3 direction = Vector3.right;


    private Move2D move2D;

    private BossGauge bossGauge;
    private float bossTouchDamage = 3;//보스에 닿으면 죽음
    private MeteoriteSpawner meteoriteSpawner;
    public PlayerMove2D move;

    private void Awake()
    {
        move2D = GetComponent<Move2D>();

        bossGauge = GetComponent<BossGauge>();
        objectPooling = GetComponent<ObjectPooling>();
        bossObj = FindObjectOfType<BossGauge>();  // 씬이 로드될 때 BossGauge를 찾습니다.

        enemySpawner = FindObjectOfType<EnemySpawner>();

        bgmController = GetComponent<BgmController>();
        boxCollider = FindObjectOfType<BoxCollider2D>();
        meteoriteSpawner = FindObjectOfType<MeteoriteSpawner>();
        move = GetComponent<PlayerMove2D>();

    }
    
    private void FixedUpdate()
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
