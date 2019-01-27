using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScript : MonoBehaviour {

    public Image images;

    void Awake()
    {
        images = GetComponent<Image>();
    }

    public void FadeIn()
    {
        if (images.enabled) iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 2f, "onupdate", "SetValue"));
    }
    public void FadeOut()
    {
        if(images.enabled) iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 2f, "onupdate", "SetValue"));
    }
    public void FadeSet(float alpha, float nowalpha)
    {
        if (images.enabled) iTween.ValueTo(gameObject, iTween.Hash("from", nowalpha, "to", alpha, "time", 2f, "onupdate", "SetValue"));
    }
    public void DemoFadeOut()
    {
        if (images.enabled) iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 2f, "onupdate", "SetValue"));
    }
    void SetValue(float alpha)
    {
        images.color = new Color(0, 0, 0, alpha);
    }
    public void SetEnable()
    {
        images.enabled = true;
    }
    public void SetDisable()
    {
        images.enabled = false;
    }
}
