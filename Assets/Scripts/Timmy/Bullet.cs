using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;

    public GameObject hiteffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Bat bat = collision.GetComponent<Bat>();
        GreaterDemon GDem = collision.GetComponent<GreaterDemon>();

        if (bat != null)
        {
            bat.TakeDamage(damage);
            var BatImpact = Instantiate(hiteffect, transform.position, Quaternion.identity);

            Shooting.Destroy(gameObject);
            Destroy(BatImpact, 0.4f);
        }
        if (GDem != null)
        {
            GDem.TakeDamage(damage);
            var GDemImpact = Instantiate(hiteffect, transform.position, Quaternion.identity);

            Shooting.Destroy(gameObject);
            Destroy(GDemImpact, 0.4f);
        }

    }
}
