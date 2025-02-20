using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EffectType
//{
//    BlueCircle,
//    PinkPos,
//    BlueWater
//}
public class AttachItem : MonoBehaviour
{
    public Transform attachPoint;  // 장착할 위치
    public GameObject currentItem; // 현재 아이템
    public GameObject effect;

    //public GameObject effect1;
    //public GameObject effect2;
    //public GameObject effect3;

    private void Update()
    {
        // E키를 눌렀을 때 장착/해제
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentItem == null)
            {
                EquipItem();  // 아이템 장착
            }
            else
            {
                UnequipItem();  // 아이템 해제
            }
        }
    }
    public void EquipItem()
    {
        // 이미 아이템이 장착되어 있으면 새로 장착하지 않음
        if (currentItem != null) return;

        // 새 아이템을 장착
        currentItem = Instantiate(effect, attachPoint.position, attachPoint.rotation);
        currentItem.transform.SetParent(attachPoint);
    }

    public void UnequipItem()
    {
        // 장착된 아이템이 있다면 제거
        if (currentItem != null)
        {
            Destroy(currentItem); // 아이템 제거
            currentItem = null;
        }
    }
}

