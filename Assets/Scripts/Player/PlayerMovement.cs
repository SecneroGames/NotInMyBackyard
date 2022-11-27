using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody rb;
    Animator anim;
    float Inputx, Inputz;
    public static bool isIdle = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Inputx = Input.GetAxis("Horizontal");
        Inputz = Input.GetAxis("Vertical");

        MoveAnimation();
    }

    void FixedUpdate()
    {
        Vector3 vel = new Vector3(Inputx,0f,Inputz) * Time.deltaTime * speed;
        rb.velocity = vel;
    }

    void MoveAnimation()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Run", true);
            isIdle = false;
        }
        else
        {
            anim.SetBool("Run", false);
            isIdle = true;
        }
    }
}