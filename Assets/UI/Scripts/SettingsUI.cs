using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    private Animator animator; //ui animaton ��Ʈ���� ��������
    public GameManager manager;

   

    private void Awake()
    {
        animator = GetComponent<Animator>(); //��������
    }

    private void OnEnable()
    {
        
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay()); //����â ui �ݴ� �Լ�
    }

    private IEnumerator CloseAfterDelay()  //������ �ִϸ��̼��� ������� ui ������Ʈ ��Ȱ��ȭ
    {
        animator.SetTrigger("close");
        yield return null;
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }

    
}