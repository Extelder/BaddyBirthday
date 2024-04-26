using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotation : MonoBehaviour
{
    private float _speed = 3f;
    void Update()
    {
        transform.Rotate(0, 0, _speed);
    }
}
