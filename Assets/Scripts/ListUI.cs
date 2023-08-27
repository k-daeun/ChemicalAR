using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListUI : MonoBehaviour
{
    private Animator animator; //ui animaton 컨트롤할 변수선언

    private void Awake()
    {
        animator = GetComponent<Animator>(); //변수저장
    }

    private void OnEnable()
    {

    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay()); //설정창 ui 닫는 함수
    }

    private IEnumerator CloseAfterDelay()  //닫히는 애니매이션이 재생된후 ui 오브젝트 비활성화
    {
        animator.SetTrigger("close");
        yield return null;
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
