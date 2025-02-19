using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector2 min; // 카메라의 최소 X, Y 좌표
    public Vector2 max; // 카메라의 최대 X, Y 좌표

    void LateUpdate()
    {
        // 캐릭터와 위치 같게
        Vector3 newPosition = transform.position = new Vector3(player.position.x, player.position.y, -1);

        // X, Y 좌표가 최소값과 최대값을 벗어나지 않도록 제한
        newPosition.x = Mathf.Clamp(newPosition.x, min.x, max.x);
        newPosition.y = Mathf.Clamp(newPosition.y, min.y, max.y);

        // 카메라의 위치 업데이트
        transform.position = newPosition;
    }
}
