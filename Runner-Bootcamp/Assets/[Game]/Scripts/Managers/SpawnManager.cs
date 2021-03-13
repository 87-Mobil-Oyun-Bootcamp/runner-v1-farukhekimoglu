using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Managers;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private LevelManager _levelManager;
    private Transform _road;
    private Transform _mainCamera;
    private Queue<Transform> _roadPool = new Queue<Transform>();
    private Vector3 _roadSpawnInterval = Vector3.zero;
    private Vector3 _roadSpawnPos = new Vector3(0, -0.5f, 0);
    private Transform _closestRoad;

    private void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        _road = _levelManager.LevelRoad;
        _roadSpawnInterval.z = _levelManager.LevelRoadInterval;
       
        for (int i = 0; i < 4; i++)
        {
            Transform road = Instantiate(_road, _roadSpawnPos, Quaternion.identity);
            _roadPool.Enqueue(road);
            _roadSpawnPos += _roadSpawnInterval;
        }

        FindClosestRoad();
    }

    private void Update()
    {
        if (Mathf.Abs(_mainCamera.position.z - (_closestRoad.position.z + _closestRoad.localScale.z / 2)) < 0.1f)
        {
            PlaceRoad();
        }
    }


    private void PlaceRoad()
    {
        _closestRoad.position = _roadSpawnPos;
        _roadSpawnPos += _roadSpawnInterval;
        _roadPool.Enqueue(_closestRoad);
        FindClosestRoad();
    }

    private void FindClosestRoad()
    {
        _closestRoad = _roadPool.Dequeue();
    }
}