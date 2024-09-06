using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesLoader
{
    public static void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
