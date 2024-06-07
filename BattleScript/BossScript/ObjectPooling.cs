using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    public int luncherCount = 10;

    public float attackCooldown = 1f; // 공격 쿨다운 시간 (1초로 설정)

    public float timeSinceLastAttack = 0f; // 마지막 공격 이후의 시간

    [SerializeField]
    private StageData stageData;


    private Queue<TreeBossMove2D> poolingQueue = new Queue<TreeBossMove2D>();

    private void Awake()
    {
       
        Instance = this;
        
    }
    private void FixedUpdate()
    {
        // 공격 쿨다운 시간 갱신
        timeSinceLastAttack += Time.fixedDeltaTime;

        // 공격 쿨다운이 지났으면 공격 실행
        if (timeSinceLastAttack >= attackCooldown)
        {
            GetObject();
            timeSinceLastAttack = 0f; // 쿨다운 초기화
        }
      
    }
    private TreeBossMove2D CreatNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab, transform.position, Quaternion.identity).GetComponent<TreeBossMove2D>();

        //newObj.gameObject.SetActive(false);
        return newObj;
    }

    public void Initialize(int count)
    {
        for (int i =0; i< count; i++)
        {
            poolingQueue.Enqueue(CreatNewObject());
        }

    }
    // 비어 있는 풀을 처리하기 위해 수정된 GetObject 메소드
    public static TreeBossMove2D GetObject()
    {
        if (Instance.poolingQueue.Count>0)
        {
            var obj = Instance.poolingQueue.Dequeue();
           
            return obj;
        }else
        {
            var newObj = Instance.CreatNewObject();
           
            return newObj;
        }
    }
   
}
