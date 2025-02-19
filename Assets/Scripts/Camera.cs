using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector2 min; // ī�޶��� �ּ� X, Y ��ǥ
    public Vector2 max; // ī�޶��� �ִ� X, Y ��ǥ

    void LateUpdate()
    {
        // ĳ���Ϳ� ��ġ ����
        Vector3 newPosition = transform.position = new Vector3(player.position.x, player.position.y, -1);

        // X, Y ��ǥ�� �ּҰ��� �ִ밪�� ����� �ʵ��� ����
        newPosition.x = Mathf.Clamp(newPosition.x, min.x, max.x);
        newPosition.y = Mathf.Clamp(newPosition.y, min.y, max.y);

        // ī�޶��� ��ġ ������Ʈ
        transform.position = newPosition;
    }
}
