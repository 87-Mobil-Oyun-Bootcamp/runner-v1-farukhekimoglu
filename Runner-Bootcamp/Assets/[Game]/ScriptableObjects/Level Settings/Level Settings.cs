using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Levels
{
    [CreateAssetMenu(menuName = "Level/LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        public List<LevelInfoAsset> LevelList = new List<LevelInfoAsset>();

        [Serializable]
        public struct LevelInfoAsset
        {
            public int LevelIndex;
            public Transform Road;
            public int TargetScore;
            }

        public float RoadSpawnInterval(Transform road)
        {
            return road.localScale.z;
        }
        public float LevelBoundary(Transform road)
        {
            return road.localScale.x/2;
        }
        
        
    }
}