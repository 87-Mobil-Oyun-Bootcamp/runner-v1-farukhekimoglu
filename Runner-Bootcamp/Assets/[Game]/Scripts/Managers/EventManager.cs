using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner.Managers
{
    public static class EventManager  
    {

        public static Action GameStarted;  
        public static Action<bool> PlayerRunning;
        public static Action OnCollect;
        public static Action LevelFinish;
        public static Action<int> ShowScore;


    }
}