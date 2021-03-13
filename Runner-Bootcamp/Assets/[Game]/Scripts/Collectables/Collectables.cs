using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
    public abstract class Collectables : MonoBehaviour
    {
        private int _playerLayer = 8;

        protected abstract void Collect();


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                Collect();
            }
        }
    }
}