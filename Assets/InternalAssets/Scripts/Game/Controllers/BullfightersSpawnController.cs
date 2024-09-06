using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    public float min, max;

    public float Next()
    {
        return Random.Range(min, max);
    }
}

public class BullfightersSpawnController : MonoBehaviour
{
    [SerializeField] private BullfighterPullObject originalPullObject;

    [SerializeField] private float spawnXOffset = 1f, minObjectsYDistance = 1f;

    [SerializeField] private FloatRange spawnTimeInterval;
    
    private float spawnXPosition = 0f, lastYSpawnPosition = 0f, verticalBound = 0f;

    void Start()
    {
        originalPullObject.Init();

        float objectHeight = originalPullObject.Bullfighter.GetVerticalScreenBound();
        verticalBound = objectHeight;

        spawnXPosition = CameraController.Instance.GetScreenWidth() / 2f + spawnXOffset;

        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnTimeInterval.Next());
        }
    }

    private void Spawn()
    {
        BullfighterPullObject newObject = originalPullObject.Pull();

        float y = 0f;
        float[] directions = Random.Range(0, 2) == 1 ? new[] { -1f, 1f } : new[] { 1f, -1f };
        foreach (float d in directions)
        {
            y = Random.Range(lastYSpawnPosition + (minObjectsYDistance * d), d * verticalBound);
            if (y >= -verticalBound && y <= verticalBound)
            {
                break;
            }
        }

        lastYSpawnPosition = y;
        newObject.transform.position = new Vector3(spawnXPosition, y, 0);
    }
}
