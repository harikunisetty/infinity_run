using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Variable")]
    [SerializeField] float speed = 250f;
    [SerializeField] float jumpForce = 250f;
    [SerializeField] float maxVelocity = 2f;

    [Header("Component")]
    public Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(rigidbody2D.velocity.x);

        if (velocity < maxVelocity)
            forceX = speed * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, jumpForce));
        }

        rigidbody2D.AddForce(new Vector2(forceX, rigidbody2D.velocity.y));
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            GameManager.Instance.UpdateCoins();
        }
    }
}