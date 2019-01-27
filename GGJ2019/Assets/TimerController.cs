using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public IntVariable timeRemaining;
    public bool isTimerOn;
    public GameEventNew TimeOut;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        UpdateTimerText();
        isTimerOn = true;
        InvokeRepeating("DecrementTimerIfOn", 1.0f, 1.0f);
    }

    public void StartTimer()
    {
        isTimerOn = true;
    }

    public void ResetTimer()
    {
        timeRemaining.Value = timeRemaining.StartingValue;
    }

    public void PauseTimer()
    {
        isTimerOn = false;
    }

    private void UpdateTimerText()
    {
        int minutesLeft = timeRemaining.Value / 60;
        int secondsLeft = timeRemaining.Value % 60;
        string displayString = minutesLeft.ToString("D2") + ":" + secondsLeft.ToString("D2");
        timerText.text = displayString;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerText();
        
    }

    private void DecrementTimerIfOn()
    {
        if (timeRemaining.Value > 0 && isTimerOn)
        {
            timeRemaining.Value--;
            if(timeRemaining.Value == 0)
            {
                TimeOut.Raise();
            }
        }
    }
}
