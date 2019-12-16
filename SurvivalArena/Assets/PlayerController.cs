using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15;
    public float lifePoints = 100;
    public Animator animator;
    public Camera cam;
    public Rigidbody2D rb;
    Vector2 movement, mousePos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        float shootInput = Input.GetAxis("Fire1");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Mathf.Ceil(Mathf.Abs(shootInput)) != 0)
            animator.SetBool("IsShooting", true);
        else if (shootInput == 0)
            animator.SetBool("IsShooting", false);
        if (Mathf.Ceil(Mathf.Abs(movement.x)) != 0 || Mathf.Ceil(Mathf.Abs(movement.y)) != 0)
            animator.SetBool("IsMoving", true);
        if (movement.x == 0 && movement.y == 0)
            animator.SetBool("IsMoving", false);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}