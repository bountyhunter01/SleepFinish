using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject luncherPrefab;

    private Coroutine firingCoroutine;
    [SerializeField]
    private float attackRate = 0.5f;//공격속도


    public void StartFiring()
    {
        if (firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine("TryAttack");
        }
    }
    public void StopFiring()
    {
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator TryAttack()
    {
       
            Instantiate(luncherPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(attackRate);
            
        
    }
   
   
}
