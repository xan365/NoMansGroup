using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// state

public enum EnemyState {
    idle,
    walk,
    attack,
    stagger
}


public class Enermy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public int baseAttack;
    public string enemyName;
    public float moveSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
