using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelSettings _levelSettings;
        [HideInInspector] public Transform LevelRoad;
        [HideInInspector] public float LevelRoadInterval;
        [HideInInspector] public float LevelBoundary;
        private int _targetScore;
        private int _score;

        private void Awake()
        {
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            LevelRoad = _levelSettings.LevelList[levelIndex].Road;
            LevelRoadInterval = _levelSettings.RoadSpawnInterval(LevelRoad);
            LevelBoundary = _levelSettings.LevelBoundary(LevelRoad);
            _targetScore = _levelSettings.LevelList[levelIndex].TargetScore;
        }
        private void OnEnable()
        {
            EventManager.OnCollect += IncreaseScore;
        }

        private void OnDisable()
        {
            EventManager.OnCollect -= IncreaseScore;
        }

        private void IncreaseScore()

        {
            _score++;
            EventManager.ShowScore?.Invoke(_score);
            if (_score == _targetScore)
            {
                EventManager.LevelFinish?.Invoke();
            }
        }
    }
}