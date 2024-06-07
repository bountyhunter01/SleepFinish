using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BGMType {Stage = 0, Boss }
public class BgmController : MonoBehaviour
{//패턴이 바뀔때 변경될 오디오 
    [SerializeField]
    private AudioClip[] bgmClips;

    private AudioSource bgmSource;

    private BossBattleScene bgmBattleScene;

    private void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmBattleScene = GetComponent<BossBattleScene>();
    }
    public void ChangeBGM(BGMType index)
    {
        // 재생할 클립을 변경하고 재생
        bgmSource.clip = bgmClips[(int)index];
        bgmSource.Play();
    }

    public void StopBGM()
    {
        // 배경음악 정지
        bgmSource.Stop();
    }

}
    
