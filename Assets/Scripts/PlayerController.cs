using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 8.0f;

    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }
            else
            {
                return 0;
            }
        }   

    }
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;

    [SerializeField]
    private bool _isMoving = false;
    [SerializeField]
    private bool _isGrounded = false;
    [SerializeField]
    private bool _isRunning = false;

    public bool IsMoving 
    { 
        get 
        {
            return _isMoving;
        }
        private set 
        {
            _isMoving = value;
            animator.SetBool(AnimationName.isMoving, value);
        }
        
    }

    public bool IsRunning 
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationName.isRunning, value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight 
    { 
        get 
        {
            return _isFacingRight;
        }
        private set 
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1 ,1);
            }

            _isFacingRight = value;
        } 
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput )
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x <0 && IsFacingRight )
        {
            IsFacingRight= false;
        }

    }    

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled) 
        {
            IsRunning = false;
        }

    }
}
