using System.Collections;
using System.Collections.Generic;
using Runner.Managers;
using UnityEngine;

namespace Collectables
{
public class Ball : Collectables
{
    protected override void Collect()
    {
        
        EventManager.OnCollect?.Invoke();;
        Destroy(gameObject);
        
    }
}
}