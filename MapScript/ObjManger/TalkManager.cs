using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;// 사전이라는뜻
    Dictionary<int, Sprite> portraitData;
    Dictionary<int, string> MonsterName;

    public Sprite[] portraitArr;
    //public LocalizeStringEvent[] localizeStringEvents;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        MonsterName = new Dictionary<int, string>();
        GenerateData();
    }
  /**  private void Start()
    {
        // 예제: 초기화 시 특정 텍스트 설정
        SetLocalizedText(0, 0); // 첫 번째 오브젝트의 첫 번째 대화 텍스트 설정
        SetLocalizedText(1, 0); // 두 번째 오브젝트의 첫 번째 대화 텍스트 설정
    }**/ 
    void GenerateData()
    {
        talkData.Add(10, new string[] { "↑우리집 →깊은숲  " });
        talkData.Add(20, new string[] { "낙사<주의>", "이곳은 가지 않는게 좋겠어" });
        talkData.Add(30, new string[] { "지금은 앉고싶지않다." });

        talkData.Add(100, new string[] { "피아노는 좀 더 배워야겠어" });
        talkData.Add(200, new string[] { "그만자야겠다", "어서 집밖을 나가보자" });
        talkData.Add(300, new string[] { "책은 다음에 읽자" });
        talkData.Add(301, new string[] { "책장을 더 구매하는게 좋겠어" });
        talkData.Add(500, new string[] { "이봐 너 지금 숲에 들어올려고 ?:0", "그럼 지금 날좀 도와주겠니?:1", "아주~간단한일이야:0","자 이거 받아 이건 수면 지팡이야:1",
        "지금 우리 숲은 불면증에 저주에 걸렸어:0","그 저주를 풀려면 이 수면마법을 쓸수있는 지팡이로 저주를 건 왕을 재워야해:1","하지만 이 지팡이는 저주에 걸리지 않은 사람만이 쓸수 있어:0",
        "걱정마 내가 옆에서 숲속 주민들을 잠재우는 방법을 알려줄게:1 ","자 어서 따라와:0"});
        MonsterName.Add(500,"왕자(가이드)" );

        MonsterName.Add(600,"숲속경비대장");
        talkData.Add(600, new string[] { "이봐 여기서 뭐하는거야 당장 꺼지지 못해?:0 ", "아니 왕자님이 왜 거기계십니까:1 ", "우리 왕자님을 데리고 어딜 다니는것이냐:0", "나 숲속의 경비대장으로 써 너에게 무력을 행사하겠다:1 " });
        talkData.Add(620, new string[] { "쿨쿨....:0" });

        MonsterName.Add(700, "숲속기사단장");
        talkData.Add(700, new string[] { "인간주제에 여기까지 온건 칭찬해주지:0", "하지만 내가 있는이상 더는 못지나간다:1", "당장 저녀석을 잡아와!:0" });
        talkData.Add(720, new string[] { "드르렁...! 드르렁!:0" });

        MonsterName.Add(800, "숲속의왕");
        talkData.Add(800, new string[] { "내가 여기까지 어떻게 왔는데 고작 인간 한명이 내 계획을 망치다니:0 ", "이 왕국은 자지 않고 계속 일해야만 게으른 놈들조차 자고싶으면 내말을 들을텐데:1", "다 네놈이 자초한 일이다 목숨으로 값아라:0" });
        talkData.Add(820, new string[] { "내가 잠시 정신을 놓았나 보구나...:0","나의 실수로 왕국 전체가 저주에 빠져 너까지 고생하게 만들었어:1 ", "내 뒤에 있는 저문을 열면 너가 있던 곳으로 돌아 갈수 있을거다:0","우리를 도와줘서 고맙단다:1" });

        MonsterName.Add(900, "꿈속 또다른나");
        talkData.Add(900, new string[] { "드디어 여기에 도달했구나 여기가 어딘지 궁금할거야:0","여긴 너의 꿈속세상의 끝이란다 그리고 난 너의 또다른 분신이지:1", "분신인데 전혀 안닮았다고? 꿈이자나 나도 이렇게 생기고 싶지않았다고!:0","아무튼 이제는 꿈에서 깨어날 차례야 이것저것 지적하고 싶은 부분이 많겠지만 너가 처음 꾼꿈이자나 너가 이해하렴:1","언젠가 더 좋은 모습으로 다시 볼수 있을거야 그동안 잘지내 현실 속에 나:0"});
       
        portraitData.Add(500 + 0, portraitArr[0]);
        portraitData.Add(500 + 1, portraitArr[1]);

        portraitData.Add(600 + 0, portraitArr[0]);
        portraitData.Add(600 + 1, portraitArr[1]);

        portraitData.Add(620 + 0, portraitArr[0]);
        portraitData.Add(620 + 1, portraitArr[1]);

        portraitData.Add(700 + 0, portraitArr[0]);
        portraitData.Add(700 + 1, portraitArr[1]);

        portraitData.Add(720 + 0, portraitArr[0]);
        portraitData.Add(720 + 1, portraitArr[1]);

        portraitData.Add(800 + 0, portraitArr[0]);
        portraitData.Add(800 + 1, portraitArr[1]);

        portraitData.Add(820 + 0, portraitArr[0]);
        portraitData.Add(820 + 1, portraitArr[1]);

        portraitData.Add(900 + 0, portraitArr[0]);
        portraitData.Add(900 + 1, portraitArr[1]);

    }
    /** public void SetLocalizedText(int id, int talkIndex)
     {
         string text = GetTalk(id, talkIndex);
         if (text != null && id < localizeStringEvents.Length)
         {
             localizeStringEvents[id].StringReference.TableEntryReference = text;
         }
    }**/

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
    public string GetMonsterName(int id)
    {
        // NPC의 ID를 사용하여 이름을 가져옵니다.
        if (MonsterName.ContainsKey(id))
        {
            return MonsterName[id];
        }
        else
        {
            return ""; // ID에 해당하는 이름이 없는 경우 빈 문자열을 반환합니다.
        }
    }
    public Sprite GetPortrait(int id, int portraitIndex)
    {

        return portraitData[id + portraitIndex];
    }
}
