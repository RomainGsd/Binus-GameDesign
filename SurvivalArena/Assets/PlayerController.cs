using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15;
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);

        transform.position = transform.position + movement;

        if (Mathf.Ceil(Mathf.Abs(verticalInput)) != 0 || Mathf.Ceil(Mathf.Abs(horizontalInput)) != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        if (verticalInput == 0 && horizontalInput == 0)
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
