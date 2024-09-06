using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullfighter : Actor
{
    private void FixedUpdate()
    {
        MoveWithCommonAcceleration(new Vector2(-moveSpeed * Time.fixedDeltaTime, 0f));
    }
}
