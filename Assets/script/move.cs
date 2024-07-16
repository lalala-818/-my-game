using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5f; // �ƶ��ٶ�
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", moveX); 
        animator.SetFloat("Vertical", moveY);
    }
}
