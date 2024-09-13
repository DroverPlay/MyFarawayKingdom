using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpforce;
    [SerializeField] private Vector3 _groundCheckOffset;

    private Vector3 _input;

    private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _playerSprite;

    private PlayerAnimation _animation;

    private bool _isGrounded;
    private bool _isMoving;
    private bool _isJump;
    private bool _isFly;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animation = GetComponentInChildren<PlayerAnimation>();
    }

    private void Update()
    {
        Move();
        CheckGround();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(_rigidbody.velocity.y) < 0.05f)
            {
                Jump();
            }
            //if (_isGrounded )
            //{
            //    Jump();
            //}
        }
        if (Mathf.Abs(_rigidbody.velocity.y) == 0f)
        {
            _isJump = false;
            _animation.isJump = _isJump;
            _isFly = false;
            _animation.isFly = _isFly;
        }
        if (_isJump == false && Mathf.Abs(_rigidbody.velocity.y) != 0f)
        {
            _isFly = true;
            _animation.isFly = _isFly;
        }
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;
        
        if(_input.x != 0)
        {
            _playerSprite.flipX = _input.x > 0 ? false : true;
        }
        _animation.isRun = _isMoving;
    }

    private void Jump()
    {
        _isJump = true;
        _animation.isJump = _isJump;
        _rigidbody.AddForce(transform.up * _jumpforce, ForceMode2D.Impulse);
    }

    private void CheckGround() 
    {
        float rayLength = 0.3f;
        Vector3 rayStartPosition = transform.position + _groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector3.down, rayLength);
        if( hit.collider != null )
        {
            _isGrounded = hit.collider.CompareTag("Ground") ? true : false;
        }
        else
        {
            _isGrounded= false;
        }
    }

    //private bool IsFlying()
    //{
    //    if(_rigidbody.velocity.y < 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
