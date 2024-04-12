using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wario.shooting;
using wario.playermovement;


namespace wario
{
    [RequireComponent(typeof(PlayerMovement), typeof(ShootingController))]
    public class Basecharacter : MonoBehaviour
    {
        [SerializeField]
        private weapon _baseWeaponprefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 2f;

        private IMovementDiretionSource _movementDiretionSource;

        private PlayerMovement _PlayerMovement;
        private ShootingController _ShootingController;

        protected void Awake()
        {
            _PlayerMovement = GetComponent<PlayerMovement>();

            _movementDiretionSource = GetComponent<IMovementDiretionSource>();
            _ShootingController = GetComponent<ShootingController>();

        }

        protected void Start()
        {
            _ShootingController.SetWeapon(_baseWeaponprefab, _hand);
        }


        protected void Update()
        {
            var direction = _movementDiretionSource.MovementDirection;
            var lookDirection = direction;
            if (_ShootingController.HasTarget)
                lookDirection = (_ShootingController.TargetPosition - transform.position).normalized;


            _PlayerMovement.MovementDirection = direction;
            _PlayerMovement.LookDirection = lookDirection;

            if (_health <= 0f)
                Destroy(gameObject);
        }

            protected void OnTriggerEnter(Collider other)
            {
                
                if (LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<bullet>();

                _health -= bullet.Damage;

                Destroy(other.gameObject);
            }
            }
        }
    }  

