using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractionZone : MonoBehaviour
{
    private bool isPlayerInRange = false;  // 플레이어가 범위 안에 있는지 체크
    public GameObject dialogueUI;  // 대화 UI (Inspector에서 할당)

    private void Start()
    {
        dialogueUI.SetActive(false); // 시작 시 UI 비활성화
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueUI.SetActive(false);  // 범위를 벗어나면 UI 닫기
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);  // UI 활성화
        }
    }
}
