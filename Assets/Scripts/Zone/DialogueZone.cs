using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractionZone : MonoBehaviour
{
    private bool isPlayerInRange = false;  // �÷��̾ ���� �ȿ� �ִ��� üũ
    public GameObject dialogueUI;  // ��ȭ UI (Inspector���� �Ҵ�)

    private void Start()
    {
        dialogueUI.SetActive(false); // ���� �� UI ��Ȱ��ȭ
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
            dialogueUI.SetActive(false);  // ������ ����� UI �ݱ�
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);  // UI Ȱ��ȭ
        }
    }
}
