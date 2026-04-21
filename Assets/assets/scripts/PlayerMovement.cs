using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float horizontalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = 0f;

        if (Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            horizontalMovement = 1f;
        }
        else if (Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            horizontalMovement = -1f;
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);
    }
}
