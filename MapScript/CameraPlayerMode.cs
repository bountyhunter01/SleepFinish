using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerMode : MonoBehaviour
{

    
    public GameObject player;
    public float moveSpeed; //카메라가 따라가는 속도
    private Vector3 cameraPosition;
  
    public void ChangeTarget(GameObject newTarget)
    {
        player = newTarget;
    }
 
   
    private void Update()
    {
        if (player != null )
        {
           

            cameraPosition.Set(player.transform.position.x, player.transform.position.y, this.transform.position.z);
            //여기서 this는 player가 아니라 카메라 이다
            this.transform.position = Vector3.Lerp(this.transform.position, cameraPosition , moveSpeed*Time.deltaTime);

        }
        
    }
}
