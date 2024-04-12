using System;
using UnityEngine;
using wario.playermovement;

namespace wario.camera
{
    public class CameraController : MonoBehaviour 
    {
        [SerializeField]
        private Vector3 _rotationOffset = Vector3.zero;
        [SerializeField]
        private Vector3 _followCameraOffset = Vector3.zero;

        [SerializeField]
        private Basecharacter _player;


        protected void Awake()
        {
            if (_player == null)
                throw new NullReferenceException($"Follow camera can't follow null player - {nameof(_player)}");
        }

        protected void LateUpdate()
        {
            Vector3 targetRotation = _rotationOffset - _followCameraOffset;

            transform.position = _player.transform.position + _followCameraOffset;
            transform.rotation = Quaternion.LookRotation(targetRotation, Vector3.up);
        }
    }
}
