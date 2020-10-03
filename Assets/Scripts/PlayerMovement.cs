﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// state machine
public enum PlayerState {
    walk,
    attack,
    interact,
    stagger,
    idle
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currState;
    public GameObject gameManager;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        speed = 10f;
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }
   
    // Update is called once per frame
    void Update()
    {
        // every frame make the change to zero
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");


        // add attack code here:

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

    public void Knock(float knockTime, float damage) {
        currentHealth.RuntimeValue -= damage;
        Debug.Log(currentHealth.RuntimeValue);
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            Debug.Log("Hit");
            
            StartCoroutine(KnockCo(knockTime));
        }
        else {
            this.gameObject.SetActive(false);
            currentHealth.RuntimeValue = currentHealth.initialValue;
            gameManager.GetComponent<GameManager>().GameOver();
            Debug.Log("die");
        }
        
    }

    // knock Co.
    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;

        }
    }
}
