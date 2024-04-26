using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private float _JumpForce;
    [Header("0 - up, 1 - right, 2 - left, 3 - down ")]
    [SerializeField] private int forceDir;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (forceDir)
            {
                case 0:
                    collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * _JumpForce, ForceMode2D.Impulse);
                    break;
                case 1:
                   collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * _JumpForce);
                    break;
                case 2:
                  collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * _JumpForce);
                    break;
                case 3:
                     collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.down * _JumpForce, ForceMode2D.Impulse);
                    break;
            }
   
        }
     
    }
}
