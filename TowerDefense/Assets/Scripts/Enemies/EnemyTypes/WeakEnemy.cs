using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemy : AbstractEnemy
{
    protected override void TargetReachedActions()
    {
        Debug.Log("Destroying weak enemy...");
        base.TargetReachedActions();
    }
}
