using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameManagerData
{
    public float playerX;
    public float playerY;
    public string playerMapId;
    public string playTime;
}


public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI talkText;//텍스트창 
    //public TextMeshProUGUI nowMapLocation;//씬 넘어오면 뜨는 맵의 이름이 나옴

    public GameObject talkPanel;
    public TextMeshProUGUI playerName;
    public GameObject scanObjact;

    public static bool GameIsPaused = false;
    public GameObject menuSet;

    // public CameraPlayerMode PlayerCamera;
    //public BossBattleScene BossBattleScene;
    public TextMeshProUGUI MonsterName;

    public bool isAction;//액션을 실행하기위한
    public bool actionCollider;//몬스터 콜라이더를 삭제하기위한

    public TalkManager talkManager;
    public Image portraitImg;
    public int talkIndex;
    public PlayerMove2D playerMove2D;

    private BossBattleScene battleScene;



   
    private void Awake()
    {
        battleScene = GetComponent<BossBattleScene>();
        //startButton = GameObjact.Find("startButton);
        //startButton.GetComponent<Button>.OnClck.Addlisner
    }

    private void Start()
    {
        actionCollider = true;

    }



    private IEnumerator HideDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

    }

    public void Action(GameObject scanObj)
    {

        scanObjact = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();


        Talk(objData.id, objData.isMonster);

        talkPanel.SetActive(isAction);
        StartCoroutine(HideDialogueAfterDelay(2.5f)); // 대화 표시 시간
    }
    public void Talk(int id, bool isMonster)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;

            talkIndex = 0;//초기화
            if (isMonster)
            {

                //이부분 나중에 토크 매니저에 넣어서 호출할거임
                actionCollider = false;
            }
            else
                playerName.text = "";
            return;
        }
        if (isMonster)//몬스터인지아닌지의 기준 은 숫자넣고 체크박스하기
        {
            talkText.text = talkData.Split(':')[0];             //parse =전환시켜주는 함수
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            MonsterName.text = talkManager.GetMonsterName(id);

            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            playerName.text = "나";
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;

        talkIndex++;//다음문장나오게하기위해



    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        menuSet.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        menuSet.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }



    public void GameExit()
    {
#if (UNITY_EDITOR)

        UnityEditor.EditorApplication.isPlaying = false;

#else
        
                Application.Quit();

#endif

    }

}
