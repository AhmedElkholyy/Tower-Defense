using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 50;
    public int damage = 10;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                StopAndDamagePlayer();
            }
        }
    }

    void StopAndDamagePlayer()
    {
        if (target.CompareTag("Player"))
        {
            target.GetComponent<Player>().TakeDamage(damage);
        }
        

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(15);
            Destroy(other.gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EnemyKilled();
        }
    }
}
