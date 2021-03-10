using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _isGameStarted;


        //  public static bool GameStarted;

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
    }
}