using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class GoEnding : MonoBehaviour
{
    
    public GameObject blackImage;

    private new MonsterColliderDestroy collider;// 콜라이더 사라지면 나오게끔 만들기위해
    private void Start()
    {
       
        //blackImage = GameObject.<Image>(); 자꾸 할당했는데 할당안되었다고 말함
        collider = FindObjectOfType<MonsterColliderDestroy>();

    }
    void FixedUpdate()
    {
        if (collider.boxCollider.enabled == false)
        {

            blackImage.SetActive(true);
            StartCoroutine(GoIntro());
        }
    }
    IEnumerator GoIntro()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Sleep");
    }

}
