using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacement : MonoBehaviour
{
   [SerializeField] private GameObject _platform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            _platform.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            _platform.SetActive(false);
        }
    }

}
