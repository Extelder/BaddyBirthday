using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _Choose;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidBody;
    void Start()
    {
        Invoke("DestroyForNothing",2f);
        _rigidBody = GetComponent<Rigidbody2D>();
        if(_Choose == 0)
        {
            _rigidBody.velocity = new Vector2(-_speed, 0f);
        }
        if (_Choose == 1)
        {
            _rigidBody.velocity = new Vector2(_speed, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    void DestroyForNothing()
    {
        Destroy(gameObject);
    }
 
}
