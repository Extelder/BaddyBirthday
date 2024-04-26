using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTrap : MonoBehaviour
{
    [SerializeField] private GameObject trap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trap.GetComponent<Rigidbody2D>().gravityScale = 10f;
            trap.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionY;
            Invoke("DestroyForNothing", 0.2f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    private void DestroyForNothing()
    {
        Destroy(gameObject);
    }
}
