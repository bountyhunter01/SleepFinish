using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject alertLinePrefabs;
    [SerializeField]
    private GameObject meteoritePrefabs;
    [SerializeField]
    private float maxSpawnerTime = 4.0f;
    [SerializeField]
    private float minSpawnerTime=1.0f;

    private void Start()
    {
        StartCoroutine("SpawnMeteorite");
    }
    public IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            float positonX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 posi = new Vector3(positonX, 0, 0);
            GameObject alertLineClone = Instantiate(alertLinePrefabs,posi, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);

            Destroy(alertLineClone);

            Vector3 meteoPosition = new Vector3(positonX, stageData.LimitMax.y +1.0f,0);
            Instantiate(meteoritePrefabs,meteoPosition,Quaternion.identity);

            float spawnTime = Random.Range(minSpawnerTime,maxSpawnerTime);

            yield return new WaitForSeconds(spawnTime);
        }
    }

}
