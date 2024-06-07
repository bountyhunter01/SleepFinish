using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroBgmManager : MonoBehaviour
{
    //public static IntroBgmManager instance; // 싱글톤 인스턴스
    public AudioSource bgmAudioSource; // BGM 오디오 소스
    public Slider volumeSlider; // 볼륨 조절 슬라이더

    void Awake()
    {
       
    }


    void Start()
    {
        // 슬라이더의 초기값을 현재 볼륨으로 설정
        if (volumeSlider != null)
        {
            volumeSlider.value = bgmAudioSource.volume;
            // 슬라이더의 값이 변경될 때마다 OnVolumeChange 메서드 호출
            volumeSlider.onValueChanged.AddListener(OnVolumeChange);
        }

        // 씬이 로드될 때 슬라이더 설정
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 새로운 씬에서 슬라이더의 초기값을 현재 볼륨으로 설정
        if (volumeSlider != null)
        {
            volumeSlider.value = bgmAudioSource.volume;
        }
    }

    public void OnVolumeChange(float value)
    {
        // 오디오 소스의 볼륨을 슬라이더의 값으로 설정
        bgmAudioSource.volume = value;
    }

    void OnDestroy()
    {
        // 씬이 로드될 때 슬라이더 설정 이벤트 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
