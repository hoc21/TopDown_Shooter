using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rollBoost = 2f;
    public float RollTime;
    private float rollTime;
    bool rollOne = false;
    private  Rigidbody2D rb;
    private Animator anim;
    public Vector3 moveInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.position += moveInput * moveSpeed * Time.deltaTime;
        anim.SetFloat("Speed",moveInput.sqrMagnitude);
        if(moveInput.x !=0)
        {
            if(Input.GetKeyDown(KeyCode.Space) && rollTime <=0)
            {
                anim.SetBool("Roll",true);
                moveSpeed += rollBoost;
                rollTime = RollTime;
                rollOne = true;
            }
            if(rollTime <= 0 && rollOne == true)
            {
                anim.SetBool("Roll",false);
                moveSpeed -= rollBoost;
                rollOne = false;
            }
            else
            {
                rollTime -= Time.deltaTime;
            }
            if(moveInput.x > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(-1,1,1);
            }
        }

        
    }
}
