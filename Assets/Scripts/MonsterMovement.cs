using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : Enermy
{
    public Transform target;
    private float triggerDistance;
    private float attackDistance;
    private Animator animator;
    private Vector3 move;
    private Vector2 animatorMove;
    private Rigidbody2D monster;
    private Rigidbody2D playerBody;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        monster = GetComponent<Rigidbody2D>();
        playerBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        triggerDistance = 4;
        attackDistance = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x - target.position.x);
        move = Vector3.zero;
        animatorMove = Vector2.zero;
        float xdiff = transform.position.x - target.position.x;
        float ydiff = transform.position.y - target.position.y;
        // the monstet's move is different form his animation.
        move.x = xdiff > 0 ? -1 : 1;
        move.y = ydiff > 0 ? -1 : 1;
        // first get direction. then compare x and y, choose large direction to move.
        // eg: xdiff = -5. ydiff = 3, then our animator will go left rather then top;
        // so animatorMove x = -1, animator Y = 0;
        animatorMove.x = xdiff > 0 ? -1 : 1;
        animatorMove.y = ydiff > 0 ? -1 : 1;
        IdleAndMoveAnim(xdiff, ydiff);
    }

    void IdleAndMoveAnim(float xdiff, float ydiff) {
        if (Math.Abs(xdiff) > Math.Abs(ydiff))
        {
            animatorMove.y = 0;
        }
        else
        {
            animatorMove.x = 0;
        }
        if (Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2) < Math.Pow(triggerDistance, 2)
            && Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2) > Math.Pow(attackDistance, 2))
        {
            animator.SetBool("wake", true);
            animator.SetBool("chase", true);
            monster.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
            animator.SetFloat("moveX", animatorMove.x);
            animator.SetFloat("moveY", animatorMove.y);
        }
        else if (Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2) <= Math.Pow(attackDistance, 2)) {
            animator.SetBool("wake", true);
            animator.SetBool("chase", false);
            


        }
        else
        {
            animator.SetBool("chase", false);
            animator.SetBool("wake", false);
        }
    }
}
