using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    private Rigidbody2D myRigidbody;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 change = Vector3.zero;
        change.x = moveDirection.x;
        change.y = moveDirection.y;
        myRigidbody.MovePosition(
            transform.position + change * moveSpeed * Time.deltaTime
        ) ;
    }

    public void SetMoveDirection(Vector2 dir) {
        moveDirection = dir;
    }

    private void Destroy() {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground")) {
            Destroy();
        }
        else if (other.gameObject.CompareTag("Player")) {
            Debug.Log("hit");
            Destroy();
        }
    }
}
