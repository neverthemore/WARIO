using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace wario.shooting
{
    public class ShootingController : MonoBehaviour
    {
        public bool HasTarget => _target != null;
        public Vector3 TargetPosition => _target.transform.position;


        private weapon _weapon;

        private Collider[] _colliders = new Collider[2];    
        private float _nextShotTimerSec;
        private GameObject _target;

       protected void Update()
        {
            _target = GetTarget();

            _nextShotTimerSec -= Time.deltaTime;
            if (_nextShotTimerSec < 0 )
            {
                if (HasTarget)
                    _weapon.Shoot(TargetPosition);
         
                _nextShotTimerSec = _weapon.ShootFrequencySec;

            }
        }
    public void SetWeapon(weapon weaponPrefab, Transform hand)
        {
            _weapon = Instantiate(weaponPrefab, hand);
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }
        
        private GameObject GetTarget()
        {
            GameObject target = null;

            var position = _weapon.transform.position;
            var radius = _weapon.ShootRadius;
            var mask = LayerUtils.EnemyMask;           
            var size = Physics.OverlapSphereNonAlloc(position, radius, _colliders, mask);           

            if (size > 0 && size > 0);
            {
                for (int i = 0; i < size; i++)
                {
                    if (_colliders[i].gameObject != gameObject)
                    {
                        target = _colliders[i].gameObject;
                        break;
                    }
                }
            }
            return target;
        }
    }

}