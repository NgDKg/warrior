using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Knight : MonoBehaviour
{
    TouchingDirections touchingDirections;
    public DetectionZone zone;
    public float walkspeed = 3f;
    public float walkStopRate = 0.5f;
    Animator animator;

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

    public bool _hastarget = false;
    public bool Hastarget 
    {
        get 
        {
            return _hastarget;
        }
        private set
        {
            _hastarget = value;
            animator.SetBool(AnimationName.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationName.canMove);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Hastarget = zone.detectedColider.Count > 0;
    }

    private void FixedUpdate()
    {
        if (touchingDirections.IsGrounded && touchingDirections.IsOnWall)
        {
            FilpDirection();
        }
        if (CanMove)
        {
            rb.velocity = new Vector2(walkspeed * walkDirectionVector.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
        }
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
