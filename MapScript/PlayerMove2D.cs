using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove2D : MonoBehaviour
{
    [SerializeField]
    private float shiftSpeed = 4;

    public new Rigidbody2D rigidbody2D;

    private Move2D move;

    private BoxCollider2D boxCollider2D;

    public LayerMask mask;//어떤 레이어와 충돌했는지 구분하기위해서

    public static PlayerMove2D Instance;//싱글톤 패턴 
    public string currentMapName; // 현재 플레이어의 맵 이름을 저장

    private Vector3 dirVec;

    private SpriteRenderer spriteRenderer;

    private GameObject scanObjectes;

    public GameManager gameManager;

    public Vector2 resetPosition;//플레이어 위치 초기화
    
    private Animator animator;



    private void Awake()
    {
        move = GetComponent<Move2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때 호출되는 이벤트에 메소드를 등록
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 오브젝트가 비활성화될 때 이벤트에서 메소드를 제거
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = resetPosition;//씬로드후 위치 초기화
        currentMapName = scene.name;
        gameManager = FindObjectOfType<GameManager>();
        //this.gameObject.SetActive(scene.name == "SleepFristMap");

    }

    private void Update()
    {

        float speed = Input.GetKey(KeyCode.LeftShift) ? shiftSpeed + 5 : 3;

        // 방향키 입력에 따른 이동
        float x = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        float y = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        rigidbody2D.velocity = new Vector2(x, y) * speed;

        // 움직임 방향 저장
        if (x != 0 || y != 0)
        {
            dirVec = new Vector3(x, y, 0);
        }

        // 애니메이터에 움직임 방향 전달
        animator.SetFloat("DirX", dirVec.x);
        animator.SetFloat("DirY", dirVec.y);

        // 스캔된 물체들
        if (Input.GetButtonDown("Jump") && scanObjectes != null)
        {
            gameManager.Action(scanObjectes);
        }
        if (Input.GetButtonDown("Jump") && scanObjectes == null)
        {
            gameManager.talkPanel.SetActive(false);
        }

    }
    void FixedUpdate()
    {


        //물체 레이어에 닿으면 텍스트를 나오게하기위해
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if (hit.collider != null)
        {
            scanObjectes = hit.collider.gameObject;
        }
        else
        {
            scanObjectes = null;
        }
    }

}
     