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
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private LevelManager _levelManager;
        private float _roadBoundary;
        private bool _isRunning;

        private void Start()
        {
            _roadBoundary = _levelManager.LevelBoundary;
        }

        private void OnEnable()
        {
            EventManager.GameStarted += OnStart;
            EventManager.LevelFinish += OnFinish;
        }

        private void OnDisable()
        {
            EventManager.GameStarted -= OnStart;
            EventManager.LevelFinish -= OnFinish;
        }

        private void Update()
        {
            if (_isRunning)
            {
                float horizontalMovement = Time.deltaTime * _playerSettings.SwerveSpeed * _inputManager.MoveFactorX;
                transform.Translate(horizontalMovement, 0, (_playerSettings.Speed * Time.deltaTime));
                Vector3 clampedPosition = transform.position;
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_roadBoundary, _roadBoundary);
                transform.position = clampedPosition;
            }
        }

        private void RunningState(bool state)
        {
            _isRunning = state;
            EventManager.PlayerRunning?.Invoke(_isRunning);
        }

        private void OnStart() => RunningState(true);
        private void OnFinish() => RunningState(false);
    }
}