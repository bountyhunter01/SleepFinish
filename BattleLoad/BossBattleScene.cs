using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossBattleScene : MonoBehaviour
{


    private BoxCollider2D boxCollider;


    private GameManager gameManager;


    private PlayerController playerController;


    TalkManager talkManager;


    private Image fadeIn;

    public string loadSceneName;

    
    // public bool isSpace =true;
    public static BossBattleScene instance;

    public BgmController bgmController;
    public int npcId = 500;  // 예시로 NPC에 대한 고유 ID



    private void Awake()
    {
        boxCollider = FindObjectOfType<BoxCollider2D>();//이걸로 돌아왔을때 없어지는 콜라이더로
        gameManager = FindObjectOfType<GameManager>();

        playerController = FindObjectOfType<PlayerController>();
        fadeIn = FindObjectOfType<Image>();
        talkManager = FindObjectOfType<TalkManager>();

        bgmController = GetComponent<BgmController>();//기존음악을재생할수도


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 대화 시작
            StartCoroutine(StartDialogue(npcId)); // 

        }
    }



    private IEnumerator StartDialogue(int npcId)
    {

        gameManager.talkPanel.SetActive(true); // 대화 패널 활성화
        int talkIndex = 0;
        string dialogue;

        // 대화를 순차적으로 표시
        while ((dialogue = talkManager.GetTalk(npcId, talkIndex)) != null)
        {
            gameManager.talkText.text = dialogue;// UI에 대화 내용을 표시
            gameManager.Action(gameObject);// 대화 내용 업데이트와 함께 NPC 액션 수행

            // 'Jump' 버튼이 눌릴 때까지 대기
            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));

            // yield return new WaitForSeconds(0.1f);
            talkIndex++;  // 다음 대화로 이동
        }
        gameManager.talkPanel.SetActive(false); // 대화가 끝나면 패널 비활성화
                                                //isSpace = false;//스페이스바 눌러도 텍스트 안나오게
                                                // 대화 종료 후 전투 시작
        GoBattleStage();

    }

    //지금은 스테이지로 안감
    public void GoBattleStage()
    {

        SceneManager.LoadScene(loadSceneName);
        

    }

}
