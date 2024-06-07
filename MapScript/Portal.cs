using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneName; //이동할 맵의 이름
    [SerializeField]
    private Vector2 exitPosition;//포탈출구위치
    private PlayerMove2D playerMove;
    public GameObject player;
    public int SecenIndex;
    private void Start()
    {
        if (playerMove == null)
        {
           playerMove = FindObjectOfType<PlayerMove2D>();    
            
        }
    
        
    }
   
        private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
        {
            playerMove = other.GetComponent<PlayerMove2D>();
            if (playerMove != null )
            {
                
                
                playerMove.resetPosition = exitPosition;
                playerMove.currentMapName = sceneName;
                SceneManager.LoadScene(sceneName);
            }
           
        }
    }
}
