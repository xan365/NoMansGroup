using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KnockBack : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public float damage;

    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // add player hit enemy and enemy knocked back here...

        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")) {

            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null) {

                Vector2 diff = hit.transform.position - transform.position;
                diff = diff.normalized * thrust;
                hit.AddForce(diff, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.gameObject.CompareTag("Player")) {
                        if (other.GetComponent<PlayerMovement>().currState != PlayerState.stagger) {
                            Debug.Log("log attack people"); 
                            hit.GetComponent<PlayerMovement>().currState = PlayerState.stagger;
                            other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                        }
                        
                    }
                }
            }

        }

    }
}
