using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunBullet : MonoBehaviour
{
    public int damage = 500;

    public GameObject hiteffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Bat bat = collision.GetComponent<Bat>();
        GreaterDemon GDem = collision.GetComponent<GreaterDemon>();

        if (bat != null)
        {
            bat.TakeDamage(damage);

        }
        if (GDem != null)
        {
            GDem.TakeDamage(damage);

        }

    }
}
