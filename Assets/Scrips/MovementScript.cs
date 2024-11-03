using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public int xDirection;
    public int yDirection;
    private Rigidbody2D _componetRigidbody2d;
    private SpriteRenderer _spriteRender;
    // Start is called before the first frame update
    void Awake()
    {
        _componetRigidbody2d = GetComponent<Rigidbody2D>();
        _spriteRender = GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _componetRigidbody2d.velocity = new Vector2(xSpeed * xDirection, ySpeed * yDirection);
    }
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Left")
        {
            xDirection = 1;
            _spriteRender.flipX = false;
        }
        else if (Collision.gameObject.tag == "Right")
        {
            xDirection = -1;
            _spriteRender.flipX = true;
        }
        if (Collision.gameObject.tag == "Floor")
        {
            yDirection = +1;
            _spriteRender.flipY = false;
        }
        else if (Collision.gameObject.tag == "Ceiling")
        {
            yDirection = -1;
            _spriteRender.flipY = true;
        }
    }
}