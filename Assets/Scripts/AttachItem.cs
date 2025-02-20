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
    public Transform attachPoint;  // ������ ��ġ
    public GameObject currentItem; // ���� ������
    public GameObject effect;

    //public GameObject effect1;
    //public GameObject effect2;
    //public GameObject effect3;

    private void Update()
    {
        // EŰ�� ������ �� ����/����
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentItem == null)
            {
                EquipItem();  // ������ ����
            }
            else
            {
                UnequipItem();  // ������ ����
            }
        }
    }
    public void EquipItem()
    {
        // �̹� �������� �����Ǿ� ������ ���� �������� ����
        if (currentItem != null) return;

        // �� �������� ����
        currentItem = Instantiate(effect, attachPoint.position, attachPoint.rotation);
        currentItem.transform.SetParent(attachPoint);
    }

    public void UnequipItem()
    {
        // ������ �������� �ִٸ� ����
        if (currentItem != null)
        {
            Destroy(currentItem); // ������ ����
            currentItem = null;
        }
    }
}

