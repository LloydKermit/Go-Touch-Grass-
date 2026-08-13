using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bat : WinLose
{
    public int damage = 4;
    public int health = 50;

    public GameObject deathEffect;
    public GameObject target;
    ScoreSoulCount scoreSoulCount;

    [SerializeField] private float speed = 14.5f;

    public Rigidbody2D rb;

    private void Start()
    {
        rb.mass = 1000;
        target = GameObject.FindGameObjectWithTag("Player");
        scoreSoulCount = GameObject.Find("Counter").GetComponent<ScoreSoulCount>();
    }
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.up = target.transform.position - transform.position;
        }

    }

    private void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        var deathAni = Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(deathAni, 0.1f);

        Destroy(gameObject);

        scoreSoulCount.decreaseSoul();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TimmyHealth health = collision.GetComponent<TimmyHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
