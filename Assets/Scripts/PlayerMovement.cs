using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool moving;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // every frame make the change to zero
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //change.z = Input.GetAxisRaw("Vertical");
        IdleAndMoveAnim();
    }

    void IdleAndMoveAnim() {
        if (change != Vector3.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            MoveCharacter();
        }
        else
        {
            animator.SetBool("moving", false);
        }
        //Debug.Log(change);
    }
    void MoveCharacter() 
    {
            myRigidbody.MovePosition(
                transform.position + change * speed * Time.deltaTime
            );  
    
    }
}
