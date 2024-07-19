using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 创建移动向量
        Vector2 movement = new Vector2(moveX, moveY);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", moveX); 
        animator.SetFloat("Vertical", moveY);
    }
}
