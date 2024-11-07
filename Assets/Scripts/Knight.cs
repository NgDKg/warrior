using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Knight : MonoBehaviour
{
    TouchingDirections touchingDirections;

    public float walkspeed = 3f;

    Rigidbody2D rb;

    public enum WalkableDirection { Right, left};
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;
    public WalkableDirection walkDirection
    {
        get
        {
            return _walkDirection;
        }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);          
                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else
                {
                    walkDirectionVector = Vector2.left;
                }
            }
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate()
    {
        if (touchingDirections.IsGrounded && touchingDirections.IsOnWall)
        {
            FilpDirection();
        }
        rb.velocity = new Vector2(walkspeed * walkDirectionVector.x, rb.velocity.y);
    }

    private void FilpDirection()
    {
        if(walkDirection == WalkableDirection.Right)
        {
            walkDirection = WalkableDirection.left;
        }
        else if (walkDirection == WalkableDirection.left)
        {
            walkDirection = WalkableDirection.Right;
        } 
        else
        {
            Debug.Log("Tien thoai luong nan");
        }

    }
}
