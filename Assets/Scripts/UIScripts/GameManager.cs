using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gamePanel;
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip; //효과음 저장할 배열변수선언
    public enum Sfx { Combination , Decomposition , Button};
    int sfxCursor; // 다음에 재생할 audiosource 가리킬 변수선언

    void Start()
    {
        bgmPlayer.Play();

        bgmPlayer.volume = 0.8f;  //처음 시작소리 80%로 고정
        foreach (AudioSource sfx in sfxPlayer)
        {
            sfx.volume = 0.5f;
        }
    }
    public void GameButton()
    {
        SfxPlay(Sfx.Button);
    }
    public void ExitBtnClick() // 앱종료 함수
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
       Application.Quit();
#endif
    }
    public void Reset()
    {
        SfxPlay(Sfx.Button);
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    
    public void SfxPlay(Sfx type)
    {
        switch(type)
        {
            case Sfx.Combination:
                sfxPlayer[sfxCursor].clip = sfxClip[0];
                break;

            case Sfx.Decomposition:
                sfxPlayer[sfxCursor].clip = sfxClip[1];
                break;

            case Sfx.Button:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                break;
        }

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }
    public void BgmSliderChange(float volume)
    {
        bgmPlayer.volume = volume;
    }
    public void SfxSliderChange(float volume)
    {
        foreach (AudioSource sfx in sfxPlayer)
        {
            sfx.volume = volume;
        }
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) //플랫폼 정보
        {
            if (Input.GetKeyDown(KeyCode.Escape))    // back키 누르면 종료
            {
                Application.Quit();
            }
        }
    }
}