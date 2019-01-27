using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject fadeobj;
    float time = 2.0f;
    int flag = 0;
    FadeScript fade;
    public SceneSwapper sceneSwapper;
    // Start is called before the first frame update
    void Start()
    {
        fade = fadeobj.GetComponent<FadeScript>();
        fade.FadeOut();
        flag = 1;
        time = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                if (flag == 1)
                {
                    fade.gameObject.SetActive(false);
                    flag = 0;
                }
                if (flag == 2)
                {
                    loadScene();

                }

            }
        }
        if(Input.GetButtonDown("Jump")){
            OnClick();

        }
    }

    public void OnClick()
    {
        if (flag == 0)
        {
            flag = 2;
            fade.gameObject.SetActive(true);
            time = 2.0f;
            fade.FadeIn();
        }
    }
    public void loadScene()
    {
        sceneSwapper.gameScenes.previousSceneIndex = 0;
        sceneSwapper.LoadFirstLevel();
    }
}
