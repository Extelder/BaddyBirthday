using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private GameObject _bullet;
    
    [SerializeField] private float TimeBtwShots;
    [SerializeField] private float MaxTimeBtwShots;
    void Update()
    {
        if(TimeBtwShots <= 0)
        {
            TimeBtwShots = MaxTimeBtwShots;
            Shoot();
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
    private void Shoot()
    {
        Instantiate(_bullet, _bulletSpawner.position, Quaternion.identity);
    }
}
