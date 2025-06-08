using UnityEngine;

public class BirdMoving : MonoBehaviour
{
    [SerializeField] private float _velosity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _body2D;

    private void Start()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            _body2D.velocity = Vector3.up * _velosity;
        }
        transform.rotation = Quaternion.Euler(0, 0, _body2D.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
