using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertest : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 좌우 방향 입력 받기 (키보드 방향키나 A/D)
        float horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(horizontal, 0).normalized;

        // 애니메이션 상태 설정
        if (horizontal != 0)
        {
            animator.SetBool("isRunning", true);
            // 캐릭터 방향 전환 (좌우 반전)
            transform.localScale = new Vector3(horizontal > 0 ? 1 : -1, 1, 1);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        // 실제 이동 처리 (프레임 독립적)
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    // UI 버튼용 메서드 (왼쪽 버튼)
    public void LButtonDown()
    {
        moveDirection = Vector2.left;
        animator.SetBool("isRunning", true);
        transform.localScale = new Vector3(-1, 1, 1);
    }

    // UI 버튼용 메서드 (오른쪽 버튼)
    public void RButtonDown()
    {
        moveDirection = Vector2.right;
        animator.SetBool("isRunning", true);
        transform.localScale = new Vector3(1, 1, 1);
    }

    // UI 버튼에서 손 뗐을 때 호출
    public void ButtonUp()
    {
        moveDirection = Vector2.zero;
        animator.SetBool("isRunning", false);
    }
}
