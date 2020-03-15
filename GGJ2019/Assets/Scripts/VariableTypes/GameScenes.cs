using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Game Scenes")]
public class GameScenes : ScriptableObject
{
    public string PerfectScene;
    public string ClearScene;
    public string BadEndingScene;
    public string FailScene;
    public string TitleScene;
    public List<string> levels;

    [HideInInspector]
    public int previousSceneIndex = 0;

    public void OnAfterDeserialize()
    {
        previousSceneIndex = 0;
    }
}
