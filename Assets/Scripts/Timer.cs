using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltTimeToCompleteQuestion = 30f;
    [SerializeField] float fltTimeToShowCorrectAnswer = 10f;

    public bool blnLoadNextQuestion;
    public float fltFillFraction;

    bool blnIsAnsweringQuestion;
    float fltTimerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        fltTimerValue = 0;
    }

    void UpdateTimer()
    {
        fltTimerValue -= Time.deltaTime;

        if(blnIsAnsweringQuestion)
        {
            if(fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToCompleteQuestion;
            }
            else
            {
                blnIsAnsweringQuestion = false;
                fltTimerValue = fltTimeToShowCorrectAnswer;
            }
        }
        else
        {
            if(fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToShowCorrectAnswer;
            }
            else
            {
                blnIsAnsweringQuestion = true;
                fltTimerValue = fltTimeToCompleteQuestion;
                blnLoadNextQuestion = true;
            }
        }
    }

}
