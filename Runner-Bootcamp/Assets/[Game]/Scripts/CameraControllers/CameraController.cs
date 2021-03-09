using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _playerPos;
        [SerializeField] private CameraSettings _cameraSettings;

        private void LateUpdate()
        {
            transform.position = _playerPos.position - _cameraSettings.CamOffset;
        }
    }
}