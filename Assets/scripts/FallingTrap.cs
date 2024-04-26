using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingTrap : MonoBehaviour
{
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() != null && GetComponent<Rigidbody2D>().gravityScale != 0f)
        {
            Invoke("destroyForNothing", 0.5f);
        }
        if (collision.gameObject.CompareTag("Player") && GetComponent<Rigidbody2D>().gravityScale != 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void destroyForNothing()
    {
      Destroy(gameObject);
    }
}
