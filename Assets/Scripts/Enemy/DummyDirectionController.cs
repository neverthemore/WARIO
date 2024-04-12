using System.Collections;
using UnityEngine;
using wario.playermovement;

namespace wario.playermovement
{
    public class DummyDirectionController : MonoBehaviour,IMovementDiretionSource
    {
        public Vector3 MovementDirection { get; private set; }

        protected void Awake()
        {
            MovementDirection = Vector3.zero;
        }

    }
}
