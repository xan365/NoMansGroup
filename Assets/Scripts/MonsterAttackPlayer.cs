using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackPlayer : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    // Start is called before the first frame update

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.gameObject.CompareTag("Player")) {
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();
            if (player != null) {
                Vector2 diff = player.transform.position - transform.position;
                diff = diff.normalized * thrust;
                player.AddForce(diff, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(player));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D player) {
        if (player != null) {
            yield return new WaitForSeconds(knockTime);
            player.velocity = Vector2.zero;
        }
    }
}
