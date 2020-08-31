using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Physics")]
    //public float gravity = 20f;
    public Rigidbody controller;
    [Header("Movement Variables")]
    public float speed = 5f;
    public float jumpSpeed = 50f;
    public Vector3 moveDirection;

    public Animator animator;
    public int movementAnim;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        
        if (Input.GetKey(KeyCode.W))
        {
            vertical++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal--;
        }
        moveDirection = new Vector3(horizontal, 0, vertical);
        //moveDirection *= speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpSpeed;
        }
        this.gameObject.transform.Translate((moveDirection * speed * Time.deltaTime));
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));
        animator.SetFloat("ForwardSpeed", Mathf.Abs(moveDirection.z));
    }
}