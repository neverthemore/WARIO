using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace wario.playermovement
{
    public interface IMovementDiretionSource
    {
        Vector3 MovementDirection { get; }
    }
} 
