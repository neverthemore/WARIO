using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wario.shooting {
public class weapon : MonoBehaviour
{ 
    [field: SerializeField]
    public bullet bulletprefab { get; private set; }

    [field: SerializeField]

    public float ShootRadius { get; private set; } = 5f;

    [field: SerializeField]

    public float ShootFrequencySec { get; private set; } = 1f;

    [SerializeField]

    private float _damage = 1f;

    [SerializeField]

    private float _bulletMaxFlyDistance = 10f;

    [SerializeField]

    private float _bulletFlySpeed = 10f;

    [SerializeField]
    
        private Transform _bulletSpawnPosition;


    public void Shoot(Vector3 targetPoint)
    {
        var bullet = Instantiate(bulletprefab, _bulletSpawnPosition.position, Quaternion.identity);

        var target = targetPoint - _bulletSpawnPosition.position;
        target.y = 0;
        target.Normalize();

            bullet.Initialize(target, _bulletMaxFlyDistance, _bulletFlySpeed, _damage);
    }
}
}
