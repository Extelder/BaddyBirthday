using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    private float _xInput;
    private float _jumpForce = 4.7f;
    private float _speed = 285f;
    private float _DashForce = 1500f;
    private string WhatScene;
    [SerializeField] private int Jumps;
    [SerializeField] private int MaxJumps;
    [SerializeField] private GameObject _SuperJumptext;
    [SerializeField] private float timeBtwJumps;
    [SerializeField] private float timeBtwDashes;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float MaxtimeBtwJumps;
    [SerializeField] private float MaxTimeBtwDashes;
    [SerializeField] private GameObject _visualInteractButton;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _camera;
    private bool IsFliped;
    private int CanDash;
    private Rigidbody2D _rigidbody;

   [SerializeField] private bool IsGrounded;
    void Awake()
    {
        if(PlayerPrefs.GetInt("Dash") == 1)
        {
            _SuperJumptext.SetActive(true);
        }
        PlayerPrefs.SetString("CheckPoint", SceneManager.GetActiveScene().name);
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && timeBtwDashes <= 0)
        {
            _animator.SetBool("IsJumping", true);
            timeBtwDashes = MaxTimeBtwDashes;
            if(_spriteRenderer.flipX == true)
            {
                _rigidbody.AddRelativeForce(Vector2.right * _DashForce, ForceMode2D.Force);
            }
            else
            {
                _rigidbody.AddRelativeForce(Vector2.left * _DashForce, ForceMode2D.Force);
            }
        }
        else
        {
            _animator.SetBool("IsJumping", false);
            timeBtwDashes -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Jumps != 0)
        {
            _jumpForce = 4.7f;
            Jumps -= 1;
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Space) && Jumps == 1)
        {
            _jumpForce = 3.3f;
            Jumps -= 1;
            Jump();
        }
        if (!IsGrounded)
        {
            _animator.SetBool("IsJumping", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
        }
      
        if (PlayerPrefs.GetInt("Dash") == 1 && Input.GetKeyDown(KeyCode.E) && timeBtwJumps <=0)
        {
            timeBtwJumps = MaxtimeBtwJumps;
            _rigidbody.AddRelativeForce(Vector2.up * 500);
        }
        else if(PlayerPrefs.GetInt("Dash") == 1)
        {
            timeBtwJumps -= Time.deltaTime;
        }  
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
      
        _xInput = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        _rigidbody.velocity = new Vector2(_xInput, _rigidbody.velocity.y);
        if(_xInput != 0f && IsGrounded )
        {
            _animator.SetBool("IsRunning", true);
        }
        if(_xInput < 0f)
        {
            _animator.SetBool("IsRunning", true);
            _spriteRenderer.flipX = false;
        }
        if(_xInput > 0f)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_xInput == 0f)
        {
            _animator.SetBool("IsRunning", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
         if (collision.gameObject.GetComponent<Collider2D>() != null)
        {
            IsGrounded = true;
            Jumps = MaxJumps;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("present"))
        {
            _SuperJumptext.SetActive(true);
            Destroy(collision.gameObject);
            CanDash = 1;
            PlayerPrefs.SetInt("Dash", CanDash);
        }
    }
    private void Jump()
    {
        Jumps -= 1; 
        if (!IsFliped)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _rigidbody.AddForce(Vector2.up * -_jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void Flip()
    {
        if (IsFliped)
        {
            IsFliped = false;
            _camera.transform.rotation = Quaternion.Euler(_camera.transform.rotation.x, 0f, 0f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
            _rigidbody.gravityScale = 5f;
        }
        else
        {
            IsFliped = true;
            _camera.transform.rotation = Quaternion.Euler(_camera.transform.rotation.x, 180f, 180f);
           transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
           _rigidbody.gravityScale = -5f;
        }
    }
    public void ChangemaxTimeBtwSuperjumps(float ChangeValue)
    {
        MaxtimeBtwJumps = ChangeValue;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<interacted>() != null)
        {
            _visualInteractButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                collision.GetComponent<interacted>().IsInteracting = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<interacted>() != null)
        {
            _visualInteractButton.SetActive(false);
        }
    }
}
