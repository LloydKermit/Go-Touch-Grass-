using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;

    [Header("Primary Fire")]
    public GameObject bulletprefab;
    public float fireRate = 0.15f;
    private float nextFire = 0f;
    public float bulletforce = 100f;

    [Header("Railgun")]
    public GameObject railgunprefab;
    public float AltfireRate = 7f;
    private float AltnextFire = 7f;
    public float railgunForce = 500f;

    [Header("Cooldowns")]
    public CooldownBar cooldownBar;

    public float maxCD;
    public float CurrentCD;

    public AudioSource PriFire;
    public AudioSource AltFire;

    public void Start()
    {
        CurrentCD = maxCD;
        maxCD = AltfireRate;
        cooldownBar.Cooldown(maxCD);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentCD += Time.deltaTime;
        cooldownBar.setCooldown(CurrentCD);

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            PriFire.Play();
            Shoot();
        }

        if (Input.GetKey(KeyCode.Mouse1) && Time.time > AltnextFire)
        {
            AltnextFire = Time.time + AltfireRate;
            AltFire.Play();
            AltShoot();
            CurrentCD = 0.0f;
        }
    }

    // Timmy Primary Fire
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Destroy(bullet, 2f);

        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
        
    }

    // Timmy's Lil Railgun

    public void AltShoot()
    {
        GameObject railgunbullet = Instantiate(railgunprefab, firepoint.position, firepoint.rotation);
        railgunbullet.transform.Rotate(0f, 0f, 90f);
        Rigidbody2D rb = railgunbullet.GetComponent<Rigidbody2D>();
        Destroy(railgunbullet, 1f);

        rb.AddForce(firepoint.up * railgunForce, ForceMode2D.Impulse);
    }

}
