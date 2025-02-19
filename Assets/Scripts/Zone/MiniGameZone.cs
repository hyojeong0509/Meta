using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 넘어가게 하기 위해 

public class MiniGameZone : MonoBehaviour
{
    private bool isPlayerInRange = false;  // 플레이어가 구역에 들어왔는지 체크
    //public GameObject miniGameUI;  // 미니게임 UI (Inspector에서 연결)
    //public GameObject player;  // 플레이어 오브젝트

    private void Start()
    {
        //miniGameUI.SetActive(false);  // 미니게임 UI 초기 상태는 비활성화
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Mini 들어옴");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Mini 나감");
            // miniGameUI.SetActive(false);  // 미니게임 영역을 벗어나면 UI 비활성화
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartMiniGame();  // E 키를 누르면 미니게임 시작
        }
    }

    private void StartMiniGame()
    {
        Debug.Log("미니게임 시작");
        // 미니게임 UI 활성화 (미니게임의 시작)
        // miniGameUI.SetActive(true);

        // 여기서 미니게임 시작 로직을 호출하거나 씬을 전환할 수 있음
        // 예시: 미니게임 씬으로 전환
        SceneManager.LoadScene("MiniGameScene");
    }
}

