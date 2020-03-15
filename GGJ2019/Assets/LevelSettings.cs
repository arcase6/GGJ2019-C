using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public IntVariable StartingTime;
    public IntVariable NormalClearThreshold;
    public IntVariable PerfectClearThreshold;

    public StartSettings StartSettings;
    

    // Start is called before the first frame update
    void Start()
    {
        StartingTime.Value = StartSettings.startingTime;
        NormalClearThreshold.Value= StartSettings.normalThreshold;
        PerfectClearThreshold.Value = StartSettings.perfectClearThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class StartSettings
{
    public int startingTime = 100;
    public int normalThreshold = 20;
    public int perfectClearThreshold = 75;
}
