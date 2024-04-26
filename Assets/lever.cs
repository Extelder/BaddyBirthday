using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    private interacted _interacted;
    [SerializeField] private GameObject _lever;
    [SerializeField] private GameObject _door;
    
    private void Start()
    {
        _interacted = GetComponent<interacted>();
    }
    void Update()
    {
        if(_interacted.IsInteracting == true)
        {
            _lever.transform.rotation = Quaternion.Euler(0f, 0f, -43.5f);
            _door.SetActive(false);
        }
    }
}
