using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _isGameStarted;
        private bool _isGameFinish;

        private void OnEnable()
        {
            EventManager.LevelFinish += GameFinish;
        }

        private void OnDisable()
        {
            EventManager.LevelFinish -= GameFinish;
        }

        private void Update()
        {
            if (!_isGameStarted)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    EventManager.GameStarted?.Invoke();
                    _isGameStarted = true;
                }
            }
        }

        private void GameFinish() => _isGameFinish = true;
        public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        
    }
}