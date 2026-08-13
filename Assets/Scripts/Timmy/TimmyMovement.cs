using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 15f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    Vector3 pos;

    public Camera cam;

    [Header("Dash")]
    public float dashSpeed = 50f;
    public float dashCooldown = 5f;
    public float nextDash = 0f;
    public Collider2D triggerCollider;
    public Collider2D collisionCollider;

    private void Start()
    {

    }
    void Update()
    {

        // Get WASD inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Get cursor position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Budget Dash Code
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextDash)
        {
            nextDash = Time.time + dashCooldown;
            StartCoroutine(Dash());
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move Timmy
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -58f, 58f), (Mathf.Clamp(transform.position.y, -25f, 25f)), 0f);

        // Rotate Timmy to face cursor
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    IEnumerator Dash()
    {
        triggerCollider.enabled = false;
        collisionCollider.enabled = false;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(0.2f);
        triggerCollider.enabled = true;
        collisionCollider.enabled = true;
        moveSpeed = 15f; 
    }
}
