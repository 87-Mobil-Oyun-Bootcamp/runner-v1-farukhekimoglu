using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Managers;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerAnimController : MonoBehaviour
    {
        private Animator _playerAnimator;
        private readonly int _isRunning = Animator.StringToHash("isRunning");

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            EventManager.PlayerRunning += RunningAnim;
        }

        private void OnDisable()
        {
            EventManager.PlayerRunning -= RunningAnim;
        }

        private void RunningAnim() => _playerAnimator.SetBool(_isRunning, true);
    }
}