using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private int bulltesAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 3f);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire() {
        float angleStep = (endAngle - startAngle) / bulltesAmount;
        float angle = startAngle;

        for (int i = 0; i < bulltesAmount + 1; i++) {
            float bulX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulX, bulY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPoll.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
        
    }
}
