using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] int damage = 35;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    private void AttackHitEvent() {
        if (target == null ) return;
        target.TakeDamage(damage);
    }
}
