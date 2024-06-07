using UnityEngine;

public class PositionDestory : MonoBehaviour
{
    [SerializeField]
    private StageData StageData;

    private float destoryWeight = 2;

    private void LateUpdate()
    {
        if (transform.position.y < StageData.LimitMin.y - destoryWeight ||
        transform.position.y > StageData.LimitMax.y + destoryWeight ||
        transform.position.x < StageData.LimitMin.x - destoryWeight ||
        transform.position.x > StageData.LimitMax.x + destoryWeight)
        {
            Destroy(gameObject);
        }
    }
}
  