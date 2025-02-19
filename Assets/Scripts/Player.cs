using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Rigidbody2D 컴포넌트를 참조합니다.
    private Rigidbody2D rigidbody_;
    // 애니메이터 참조
    private Animator animator;
    // 스프라이트 렌더러
    private SpriteRenderer spriteRenderer; 
    // 이동 속도 설정
    public float moveSpeed = 5f;

    // 이동 방향을 계산할 때 사용할 변수
    private Vector2 direction;

    void Start()
    {
        // Rigidbody2D 컴포넌트 초기화
        rigidbody_ = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(); //애니메이터는 자식에게 있음
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //스프라이트 랜더러 자식에게 있음
    }

    void Update()
    {
        // 입력값을 받아서 이동 방향을 계산
        float horizontal = Input.GetAxisRaw("Horizontal"); // 왼쪽(-1) 또는 오른쪽(1)
        float vertical = Input.GetAxisRaw("Vertical");     // 아래(-1) 또는 위(1)

        // 수평과 수직 입력을 기반으로 이동 방향 계산
        direction = new Vector2(horizontal, vertical).normalized;  // 벡터를 정규화하여 이동 속도 일정하게 유지

        // 이동 여부 체크
        bool isMoving = direction.magnitude > 0;
        animator.SetBool("IsMoving", isMoving);


        if (isMoving)
        {
            // 애니메이터 파라미터 설정
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);

            // 좌우 이동 시 반전 (오른쪽: ,true, 왼쪽: false)
            if (direction.x != 0)
            {
                spriteRenderer.flipX = direction.x > 0;
            }
        }

    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용해 실제로 이동
        rigidbody_.velocity = direction * moveSpeed;
    }
}
