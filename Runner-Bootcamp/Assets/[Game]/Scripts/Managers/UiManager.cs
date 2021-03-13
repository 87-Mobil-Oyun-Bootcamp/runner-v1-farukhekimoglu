using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Managers;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _finishUI;
    private void OnEnable()
    {
        EventManager.ShowScore += UpdateScore;
        EventManager.LevelFinish += OpenFinishUI;
    }

    private void OnDisable()
    {
        EventManager.ShowScore -= UpdateScore;
        EventManager.LevelFinish -= OpenFinishUI;
    }

    private void OpenFinishUI()
    {
        _finishUI.SetActive(true);
    }

    private void UpdateScore(int score)
    {
        _scoreText.SetText($"Score: {score}");
    }
}