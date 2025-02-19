using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Rigidbody2D ������Ʈ�� �����մϴ�.
    private Rigidbody2D rigidbody_;
    // �ִϸ����� ����
    private Animator animator;
    // ��������Ʈ ������
    private SpriteRenderer spriteRenderer; 
    // �̵� �ӵ� ����
    public float moveSpeed = 5f;

    // �̵� ������ ����� �� ����� ����
    private Vector2 direction;

    void Start()
    {
        // Rigidbody2D ������Ʈ �ʱ�ȭ
        rigidbody_ = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(); //�ִϸ����ʹ� �ڽĿ��� ����
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //��������Ʈ ������ �ڽĿ��� ����
    }

    void Update()
    {
        // �Է°��� �޾Ƽ� �̵� ������ ���
        float horizontal = Input.GetAxisRaw("Horizontal"); // ����(-1) �Ǵ� ������(1)
        float vertical = Input.GetAxisRaw("Vertical");     // �Ʒ�(-1) �Ǵ� ��(1)

        // ����� ���� �Է��� ������� �̵� ���� ���
        direction = new Vector2(horizontal, vertical).normalized;  // ���͸� ����ȭ�Ͽ� �̵� �ӵ� �����ϰ� ����

        // �̵� ���� üũ
        bool isMoving = direction.magnitude > 0;
        animator.SetBool("IsMoving", isMoving);


        if (isMoving)
        {
            // �ִϸ����� �Ķ���� ����
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);

            // �¿� �̵� �� ���� (������: ,true, ����: false)
            if (direction.x != 0)
            {
                spriteRenderer.flipX = direction.x > 0;
            }
        }

    }

    void FixedUpdate()
    {
        // Rigidbody2D�� ����� ������ �̵�
        rigidbody_.velocity = direction * moveSpeed;
    }
}
