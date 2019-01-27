using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public GameScenes gameScenes;

    public IntVariable PerfectThreshold;
    public IntVariable NormalThreshold;
    public IntVariable CurrentTime;

    public void LoadClearScreen()
    {
        if (CurrentTime.Value > PerfectThreshold.Value)
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.PerfectScene);
        else if (CurrentTime.Value > NormalThreshold.Value)
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.ClearScene);
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.ClearScene);
    }

    public void LoadFailScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.FailScene);

    }

    public void LoadFirstLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.levels.First());
    }

    public void LoadNextLevel()
    {
        gameScenes.previousSceneIndex++;
        if (gameScenes.levels.Count < gameScenes.previousSceneIndex)
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.levels[gameScenes.previousSceneIndex]);
        else
            LoadTitleScreen();
    }

    public void LoadPreviousLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.levels[gameScenes.previousSceneIndex]);
    }

    public void LoadTitleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScenes.TitleScene);
    }
}
