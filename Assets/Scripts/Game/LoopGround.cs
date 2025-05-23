using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _width = 6f;

    private SpriteRenderer _renderer;

    private Vector2 _startSize;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _startSize = new Vector2(_renderer.size.x, _renderer.size.y);
    }

    private void Update()
    {
        _renderer.size = new Vector2(_renderer.size.x + _speed * Time.deltaTime, _renderer.size.y);

        if (_renderer.size.x > _width )
        {
            _renderer.size = _startSize;
        }
    }
}
