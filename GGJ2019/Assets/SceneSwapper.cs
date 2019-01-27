using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public string ClearScene;
    public string FailScene;
    public List<string> levels;


    public void LoadClearScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(ClearScene);
    }

    public void LoadFailScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(FailScene);

    }

    public void LoadMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levels.First());

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
