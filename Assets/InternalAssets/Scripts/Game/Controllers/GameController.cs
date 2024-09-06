using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private float accelerationStep = 0.25f, accelerationIncreaseInterval = 30f;

    public float Acceleration {  get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Acceleration = 1f;
    }

    private void Start()
    {
        StartCoroutine(AccelerationUpdating());
    }

    IEnumerator AccelerationUpdating()
    {
        while (true)
        {
            yield return new WaitForSeconds(accelerationIncreaseInterval);
            Acceleration += accelerationStep;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ScenesLoader.LoadGame();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        UIController.Instance.ShowGameOver();
    }
}
