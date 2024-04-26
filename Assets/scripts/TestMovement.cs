using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TestMovement : MonoBehaviour
    {
        private float _xInput;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private bool _grounded;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _grounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            _xInput = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
            _rigidbody.velocity = new Vector2(_xInput, _rigidbody.velocity.y);
        }

        private void LateUpdate()
        {
            if (_xInput < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_xInput > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Ground>(out Ground _ground))
            {
                _grounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Ground>(out Ground _ground))
            {
                _grounded = false;
            }
        }
    }
}