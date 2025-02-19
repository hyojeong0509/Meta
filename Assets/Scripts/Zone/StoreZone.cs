using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreZone : MonoBehaviour
{
    private bool isPlayerInRange = false;  // 플레이어가 구역에 들어왔는지 체크

    private void Start()
    {
        
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
        }
    }

    private void Update()
    {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Store에서 E 키를 누름");
        }
    }
}