using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�� �Ѿ�� �ϱ� ���� 

public class MiniGameZone : MonoBehaviour
{
    private bool isPlayerInRange = false;  // �÷��̾ ������ ���Դ��� üũ
    //public GameObject miniGameUI;  // �̴ϰ��� UI (Inspector���� ����)
    //public GameObject player;  // �÷��̾� ������Ʈ

    private void Start()
    {
        //miniGameUI.SetActive(false);  // �̴ϰ��� UI �ʱ� ���´� ��Ȱ��ȭ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Mini ����");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Mini ����");
            // miniGameUI.SetActive(false);  // �̴ϰ��� ������ ����� UI ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartMiniGame();  // E Ű�� ������ �̴ϰ��� ����
        }
    }

    private void StartMiniGame()
    {
        Debug.Log("�̴ϰ��� ����");
        // �̴ϰ��� UI Ȱ��ȭ (�̴ϰ����� ����)
        // miniGameUI.SetActive(true);

        // ���⼭ �̴ϰ��� ���� ������ ȣ���ϰų� ���� ��ȯ�� �� ����
        // ����: �̴ϰ��� ������ ��ȯ
        SceneManager.LoadScene("MiniGameScene");
    }
}

