using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpforce;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private GameObject mobileControlPanel;

    private Vector3 _input;

    private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _playerSprite;

    private PlayerAnimation _animation;

    private bool _isGrounded;
    private bool _isMoving;
    private bool _isJump;
    private bool _isFly;
    private bool _isMobile;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
        mobileControlPanel.SetActive(_isMobile);
        _rigidbody = GetComponent<Rigidbody2D>();
        _animation = GetComponentInChildren<PlayerAnimation>();
    }

    private void Update()
    {
        Move();
        CheckGround();

        if (MobileInput.JumpPressed)
        {
            if (Mathf.Abs(_rigidbody.velocity.y) < 0.05f)
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(_rigidbody.velocity.y) < 0.05f)
            {
                Jump();
            }
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
        if (_isMobile)
        {
            float moveInput = MobileInput.Horizontal;

            transform.Translate(moveInput * _speed * Time.deltaTime, 0, 0);

            if (MobileInput.Horizontal == 1f)
                _playerSprite.flipX = false;
            if (MobileInput.Horizontal == -1f)
                _playerSprite.flipX = true;

            if( MobileInput.Horizontal != 0f)
                _isMoving = true;
            else
                _isMoving = false;
        }
        else
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), 0);
            transform.position += _input * _speed * Time.deltaTime;
            _isMoving = _input.x != 0 ? true : false;
        }
        FlipPerson();
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
    private void FlipPerson()
    {
        if (_input.x != 0)
        {
            _playerSprite.flipX = _input.x > 0 ? false : true;
        }
        _animation.isRun = _isMoving;
    }
}
