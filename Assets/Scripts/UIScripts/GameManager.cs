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
    public AudioClip[] sfxClip; //ȿ���� ������ �迭��������
    public enum Sfx { Combination , Decomposition , Button};
    int sfxCursor; // ������ ����� audiosource ����ų ��������

    void Start()
    {
        bgmPlayer.Play();

        bgmPlayer.volume = 0.8f;  //ó�� ���ۼҸ� 80%�� ����
        foreach (AudioSource sfx in sfxPlayer)
        {
            sfx.volume = 0.5f;
        }
    }
    public void GameButton()
    {
        SfxPlay(Sfx.Button);
    }
    public void ExitBtnClick() // ������ �Լ�
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
        if (Application.platform == RuntimePlatform.Android) //�÷��� ����
        {
            if (Input.GetKeyDown(KeyCode.Escape))    // backŰ ������ ����
            {
                Application.Quit();
            }
        }
    }
}