using System.Collections;
using UnityEngine;

public class BullfighterPullObject : PullObject<BullfighterPullObject>
{
    [Space]
    [SerializeField] private float unspawnYPosition = -5f;

    public Bullfighter Bullfighter => bullfighter;
    [SerializeField] private Bullfighter bullfighter;

    void Update()
    {
        if (transform.position.x <= unspawnYPosition)
        {
            UnpullThis();
        }
    }
}