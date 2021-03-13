using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Player
{
    [CreateAssetMenu(menuName = "Player/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;

        [SerializeField] private float _swerveSpeed;
        public float SwerveSpeed => _swerveSpeed;
    }
}