using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Runner.Camera
{
    [CreateAssetMenu(menuName = "Camera/CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        
        [SerializeField] private Vector3 _camOffset;
        public Vector3 CamOffset => _camOffset;
    }
}