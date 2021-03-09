using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Managers;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _playerSettings;
        private bool _isRunning;

        private void OnEnable()
        {
            EventManager.GameStarted += StartRunning;
        }

        private void OnDisable()
        {
            EventManager.GameStarted -= StartRunning;
        }

        private void Update()
        {
            if (_isRunning)
            {
                transform.position += Vector3.forward * (_playerSettings.Speed * Time.deltaTime);
            }
        }

        private void StartRunning()
        {
            _isRunning = true;
            EventManager.PlayerRunning?.Invoke();
            
        }
    }
}