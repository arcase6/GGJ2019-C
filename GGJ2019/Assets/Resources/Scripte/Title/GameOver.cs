using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    bool xflag = false;
    int pos = 0;
    public GameObject fadeobj;
    float time = 2.0f;
    int flag = 0;
    FadeScript fade;
    float deg=0.0f;
    float ypos;
    // Start is called before the first frame update
    void Start()
    {
        fade = fadeobj.GetComponent<FadeScript>();
        fade.FadeOut();
        flag = 1;
        time = 2.0f;
        ypos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        deg += 20.0f;
        if (deg >= 360) deg -= 360.0f;
        float dy = Mathf.Sin(deg * Mathf.Deg2Rad) * 10 ;
        float x = 0;
        if(flag==0) x = Input.GetAxis("Horizontal");
        if (Mathf.Abs(x) > 0.0f)
        {
            if (xflag == false)
            {
                xflag = true;
                pos = 1 - pos;
            }
        }
        else
        {
            xflag = false;
        }
        Vector3 poss=transform.localPosition;
        poss.x = pos * 410 - 330;
        poss.y = ypos + dy;
        transform.localPosition = poss;
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
        if (Input.GetButtonDown("Jump"))
        {
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
    public void OnClick1()
    {
        if (flag == 0)
        {
            pos = 0;
            flag = 2;
            fade.gameObject.SetActive(true);
            time = 2.0f;
            fade.FadeIn();
        }
    }
    public void OnClick2()
    {
        if (flag == 0)
        {
            pos = 1;
            flag = 2;
            fade.gameObject.SetActive(true);
            time = 2.0f;
            fade.FadeIn();
        }
    }
    public void loadScene()
    {
        if(pos==0) SceneManager.LoadScene("stage1");         
        else SceneManager.LoadScene("title");
    }
}
