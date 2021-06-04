using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;


    private void Start() {
        health = 100;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Debug.Log("You die!");
        }
    }
}
