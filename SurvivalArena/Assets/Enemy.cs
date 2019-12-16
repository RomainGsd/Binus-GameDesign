using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        moveSpeed = Random.Range(1f, 3f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                ScoreManager.scoreValue += 10;
                Destroy(gameObject);
                break;
            case "Player":
                break;
        }
    }

    void MoveEnemy()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        } else {
            rb.velocity = Vector3.zero;
        }
    }
}
